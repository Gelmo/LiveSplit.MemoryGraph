using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace LiveSplit.Roboquest
{
    public class Component : IComponent
    {
        private Settings settings;
        private Watchers _Watchers;

        public string ComponentName => "Roboquest";

        public float PaddingTop => 0;
        public float PaddingLeft => 0;
        public float PaddingBottom => 0;
        public float PaddingRight => 0;

        public float VerticalHeight => settings.GraphHeight + 2 * settings.VerticalMargins;
        public float MinimumWidth => settings.GraphWidth + 2 * settings.HorizontalMargins;
        public float HorizontalWidth => settings.GraphWidth + 2 * settings.HorizontalMargins;
        public float MinimumHeight => settings.GraphHeight + 2 * settings.VerticalMargins;

        public IDictionary<string, Action> ContextMenuControls => null;
        bool firstLoad = true;

        private int graphHeight;
        private int graphWidth;
        private int drawCounter = 0;                                        //For smoothing out
        private float avaragedValue;                                    //For smoothing out

        private Queue<float> PastValues { get; } = new Queue<float>();
        private float? _localMax = 0;
        private float LocalMax => _localMax ?? (_localMax = PastValues.Max()).Value;
        private float _AnimSpeed;
        private float AnimSpeed
        {
            get => _AnimSpeed;
            set
            {
                if (settings.LocalMax)
                {
                    PastValues.Enqueue(value);

                    if (!_localMax.HasValue || value == _localMax)
                    {
                        while (PastValues.Count > graphWidth)
                        {
                            PastValues.Dequeue();
                        }
                    }
                    else if (value > _localMax)
                    {
                        _localMax = value;

                        while (PastValues.Count > graphWidth)
                        {
                            PastValues.Dequeue();
                        }
                    }
                    else
                    {
                        while (PastValues.Count > graphWidth)
                        {
                            // Don't bother recalculating the Max() until it looks like we've dequeued the Max value().
                            if (PastValues.Dequeue() == _localMax)
                            {
                                _localMax = null;
                            }
                        }
                    }
                }

                _AnimSpeed = value;
            }
        }

        private System.Diagnostics.Process process;

        private Bitmap bmpBuffer;
        private Graphics gBuffer;

        private Brush graphBrush;
        private StringFormat valueTextFormat;
        private StringFormat descriptiveTextFormat;
        private PointF[] polygon_points;
        private Pen graphPen;

        public Component(LiveSplitState state)
        {
            valueTextFormat = new StringFormat(StringFormatFlags.NoWrap)
            {
                LineAlignment = StringAlignment.Center
            };

            descriptiveTextFormat = new StringFormat(StringFormatFlags.NoWrap)
            {
                LineAlignment = StringAlignment.Center
            };

            graphBrush = Brushes.Transparent;
            polygon_points = new PointF[4] { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), };  //LB, LU, RU, RB
            graphPen = new Pen(graphBrush);

            settings = new Settings();
            settings.HandleDestroyed += SettingsUpdated;
            SettingsUpdated(null, null);
        }

        private void SettingsUpdated(object sender, EventArgs e)
        {
            if (graphHeight != settings.GraphHeight || graphWidth != settings.GraphWidth)
            {
                graphHeight = settings.GraphHeight;
                graphWidth = settings.GraphWidth;

                bmpBuffer = new Bitmap(graphWidth, graphHeight);
                gBuffer = Graphics.FromImage(bmpBuffer);

                gBuffer.Clear(Color.Transparent);
                gBuffer.CompositingMode = CompositingMode.SourceCopy;

            }

            _Watchers = new Watchers();
        }

        private static Color Blend(IEnumerable<Color> colors, float amount, bool sillyColors)
        {
            if (float.IsNaN(amount) || amount <= 0 || colors.Count() == 1)
            {
                // If the amount is in error, default to the first color.
                return colors.First();
            }

            if (amount >= 1)
            {
                if (!sillyColors)
                {
                    // No need to blend: we know the last color will provide 100% of the value.
                    return colors.Last();
                }
                else
                {
                    return BlendTwo(colors.Reverse().Skip(1).First(), colors.Last(), amount);
                }
            }

            // Stretch the amount to cover then range (0, colors.Count() - 1).
            var floatingIndex = amount * (colors.Count() - 1);

            // Pick the highest index as the above value rounded up: [1, colors.Count() - 1]
            var index = (int)Math.Ceiling(floatingIndex);

            var color1 = colors.Skip(index - 1).First();
            var color2 = colors.Skip(index).First();

            // Blend with the decimal part of the floatingIndex.
            return BlendTwo(color1, color2, floatingIndex - (index - 1));
        }

        private static Color BlendTwo(Color zeroColor, Color oneColor, double amount)
        {
            byte a = (byte)((oneColor.A * amount) + zeroColor.A * (1 - amount));
            byte r = (byte)((oneColor.R * amount) + zeroColor.R * (1 - amount));
            byte g = (byte)((oneColor.G * amount) + zeroColor.G * (1 - amount));
            byte b = (byte)((oneColor.B * amount) + zeroColor.B * (1 - amount));
            return Color.FromArgb(a, r, g, b);
        }

        public void DrawGraph(Graphics g, LiveSplitState state, float width, float height)
        {
            if (firstLoad)
            {
                SettingsUpdated(null, null);
                firstLoad = false;
            }
            // figure out where to draw the graph
            RectangleF graphRect = new RectangleF
            {
                Y = (height - graphHeight) / 2,
                Width = graphWidth,
                Height = graphHeight
            };
            if ((settings.DescriptiveTextPosition == Position.Left && settings.ValueTextPosition == Position.Right) ||
                (settings.DescriptiveTextPosition == Position.Right && settings.ValueTextPosition == Position.Left))
            {
                graphRect.X = (width - graphWidth) / 2;
            }
            else if (settings.DescriptiveTextPosition == Position.Left ||
                     settings.ValueTextPosition == Position.Left)
            {
                graphRect.X = width - graphWidth - settings.HorizontalMargins;
            }
            else
            {
                graphRect.X = settings.HorizontalMargins;
            }

            // shall there be text left or right of the graph?
            bool descriptiveNextToGraph = (settings.DescriptiveTextPosition == Position.Left ||
                                           settings.DescriptiveTextPosition == Position.Right);
            bool valueNextToGraph = (settings.ValueTextPosition == Position.Left ||
                                     settings.ValueTextPosition == Position.Right);

            // calculate relative value between 0 and 1
            float relativeValue = (AnimSpeed - settings.MinimumValue) / (settings.MaximumValue - settings.MinimumValue);
            float relativeValueClamped = Math.Min(1.0f, Math.Max(0.0f, relativeValue));

            // create brush
            switch (settings.GraphGradient)
            {
                case GraphGradientType.Plain:
                    graphBrush = new SolidBrush(settings.GraphColorsEnumeration.First());
                    graphPen.Brush = graphBrush;
                    break;
                case GraphGradientType.Horizontal:
                case GraphGradientType.Vertical:
                    if (settings.GraphColorsEnumeration.Count() <= 1)
                    {
                        graphBrush = new SolidBrush(settings.GraphColorsEnumeration.First());
                    }
                    else
                    {
                        var color_blend = new ColorBlend
                        {
                            Colors = settings.GraphColorsEnumeration.Reverse().ToArray()
                        };
                        int position = 0;
                        color_blend.Positions = color_blend.Colors.Select(
                            x => position++ / (color_blend.Colors.Length - 1f)).ToArray();

                        LinearGradientBrush gradient_graph_brush;
                        if (settings.GraphGradient == GraphGradientType.Horizontal)
                        {
                            gradient_graph_brush = new LinearGradientBrush(
                                graphRect, Color.Black, Color.Black, LinearGradientMode.Horizontal);
                        }
                        else
                        {
                            gradient_graph_brush = new LinearGradientBrush(
                                new Point(0, 0), new Point(0, graphHeight), Color.Black, Color.Black);
                        }
                        graphBrush = gradient_graph_brush;
                    }
                    graphPen.Brush = graphBrush;
                    break;
                case GraphGradientType.ByValue:
                    graphBrush = new SolidBrush(Blend(settings.GraphColorsEnumeration,
                                                relativeValue, settings.GraphSillyColors));
                    graphPen.Brush = graphBrush;
                    break;
            }

            // draw actual graph
            switch (settings.GraphStyle)
            {
                #region Filled_Graph
                case GraphStyle.FilledGraph:
                    gBuffer.DrawImageUnscaled(bmpBuffer, -1, 0);
                    gBuffer.FillRectangle(Brushes.Transparent, graphWidth - 1, 0, 1, graphHeight);

                    if (AnimSpeed > settings.MinimumValue)
                    {
                        gBuffer.FillRectangle(graphBrush,
                                              graphWidth - 1, (1 - relativeValueClamped) * graphHeight,
                                              1, relativeValueClamped * graphHeight);
                    }

                    if (descriptiveNextToGraph || valueNextToGraph)
                    {
                        g.DrawImageUnscaled(bmpBuffer, (int)graphRect.X, (int)graphRect.Y);
                    }
                    else
                    {
                        g.DrawImage(bmpBuffer, settings.HorizontalMargins, settings.VerticalMargins,
                                    width - 2 * settings.HorizontalMargins, height - 2 * settings.VerticalMargins);
                    }
                    break;
                #endregion
                #region SingleBar
                case GraphStyle.SingleBar:
                    if (AnimSpeed > settings.MinimumValue)
                    {
                        RectangleF barRect;
                        if (descriptiveNextToGraph || valueNextToGraph)
                        {
                            barRect = graphRect;
                        }
                        else
                        {
                            barRect = g.ClipBounds;
                            barRect.X += settings.HorizontalMargins;
                            barRect.Y += settings.VerticalMargins;
                            barRect.Width -= 2 * settings.HorizontalMargins;
                            barRect.Height -= 2 * settings.VerticalMargins;
                        }

                        barRect.Width *= relativeValueClamped;
                        g.FillRectangle(graphBrush, barRect);
                    }
                    break;
                #endregion
                #region Polygonal
                case GraphStyle.Polygonal:
                    gBuffer.DrawImageUnscaled(bmpBuffer, -1, 0);
                    gBuffer.FillRectangle(Brushes.Transparent, graphWidth - 1, 0, 1, graphHeight);

                    avaragedValue += relativeValueClamped;

                    if (drawCounter == 10)
                    {
                        avaragedValue /= 10.0f;
                        //LU, LL, RB, RU
                        //X,Y, width, height
                        polygon_points[0].X = graphWidth - 11;
                        polygon_points[0].Y = polygon_points[3].Y;
                        polygon_points[1].X = graphWidth - 11;
                        polygon_points[1].Y = graphHeight;
                        polygon_points[2].X = graphWidth;
                        polygon_points[2].Y = graphHeight;
                        polygon_points[3].X = graphWidth;
                        if (AnimSpeed > settings.MinimumValue)
                            polygon_points[3].Y = graphHeight - (avaragedValue * graphHeight);
                        else
                            polygon_points[3].Y = graphHeight;
                        gBuffer.FillPolygon(graphBrush, polygon_points);
                        avaragedValue = 0;
                        drawCounter = 0;
                    }
                    else
                        drawCounter++;




                    if (descriptiveNextToGraph || valueNextToGraph)
                    {
                        g.DrawImageUnscaled(bmpBuffer, (int)graphRect.X, (int)graphRect.Y);
                    }
                    else
                    {
                        g.DrawImage(bmpBuffer, settings.HorizontalMargins, settings.VerticalMargins,
                                    width - 2 * settings.HorizontalMargins, height - 2 * settings.VerticalMargins);
                    }
                    break;
                #endregion
                #region PolygonalOverflow
                case GraphStyle.PolygonalOverflow:
                    gBuffer.DrawImageUnscaled(bmpBuffer, -1, 0);
                    gBuffer.FillRectangle(Brushes.Transparent, graphWidth - 1, 0, 1, graphHeight);


                    //LU, LL, RB, RU
                    //X,Y, width, height
                    polygon_points[0].X = graphWidth - 15;
                    polygon_points[0].Y = polygon_points[3].Y;
                    polygon_points[1].X = graphWidth - 15;
                    polygon_points[1].Y = graphHeight;
                    polygon_points[2].X = graphWidth;
                    polygon_points[2].Y = graphHeight;
                    polygon_points[3].X = graphWidth;
                    if (AnimSpeed > settings.MinimumValue)
                        polygon_points[3].Y = graphHeight - (relativeValueClamped * graphHeight);
                    else
                        polygon_points[3].Y = graphHeight;
                    gBuffer.FillPolygon(graphBrush, polygon_points);

                    if (descriptiveNextToGraph || valueNextToGraph)
                    {
                        g.DrawImageUnscaled(bmpBuffer, (int)graphRect.X, (int)graphRect.Y);
                    }
                    else
                    {
                        g.DrawImage(bmpBuffer, settings.HorizontalMargins, settings.VerticalMargins,
                                    width - 2 * settings.HorizontalMargins, height - 2 * settings.VerticalMargins);
                    }
                    break;
                    #endregion
            }

            // draw descriptive text
            if (settings.DescriptiveTextPosition != Position.None)
            {
                switch (settings.DescriptiveTextPosition)
                {
                    case Position.Left:
                    case Position.LeftInGraph:
                        descriptiveTextFormat.Alignment = StringAlignment.Near;
                        break;
                    case Position.Right:
                    case Position.RightInGraph:
                        descriptiveTextFormat.Alignment = StringAlignment.Far;
                        break;
                    case Position.CenterInGraph:
                        descriptiveTextFormat.Alignment = StringAlignment.Center;
                        break;
                }

                Font font = (settings.DescriptiveTextOverrideFont ?
                             settings.DescriptiveTextFont :
                             state.LayoutSettings.TextFont);
                Brush brush = new SolidBrush(settings.DescriptiveTextOverrideColor ?
                                             settings.DescriptiveTextColor :
                                             state.LayoutSettings.TextColor);
                RectangleF rect = descriptiveNextToGraph ? g.ClipBounds : graphRect;
                rect.X += 5;
                rect.Width -= 10;
                g.DrawString(settings.DescriptiveText, font, brush, rect, descriptiveTextFormat);
            }

            // draw value text
            if (settings.ValueTextPosition != Position.None)
            {
                switch (settings.ValueTextPosition)
                {
                    case Position.Left:
                    case Position.LeftInGraph:
                        valueTextFormat.Alignment = StringAlignment.Near;
                        break;
                    case Position.Right:
                    case Position.RightInGraph:
                        valueTextFormat.Alignment = StringAlignment.Far;
                        break;
                    case Position.CenterInGraph:
                        valueTextFormat.Alignment = StringAlignment.Center;
                        break;
                }

                Font font = (settings.ValueTextOverrideFont ?
                             settings.ValueTextFont :
                             state.LayoutSettings.TextFont);
                Brush brush = new SolidBrush(settings.ValueTextOverrideColor ?
                                             settings.ValueTextColor :
                                             state.LayoutSettings.TextColor);
                RectangleF rect = valueNextToGraph ? g.ClipBounds : graphRect;
                rect.X += 5;
                rect.Width -= 10;
                string str;
                str = AnimSpeed.ToString("n" + settings.ValueTextDecimals);
                if (settings.LocalMax)
                {
                    str += " (" + LocalMax.ToString("n" + settings.ValueTextDecimals) + ")";
                }
                g.DrawString(str, font, brush, rect, valueTextFormat);
            }
        }

        private void DrawBackground(Graphics g, LiveSplitState state, float width, float height)
        {
            if ((settings.BackgroundColor.A == 0 || settings.BackgroundGradient != GradientType.Plain) &&
                settings.BackgroundColor2.A == 0)
            {
                bool horizontal = (settings.BackgroundGradient == GradientType.Horizontal);
                bool plain = (settings.BackgroundGradient == GradientType.Plain);
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new PointF(0, 0),
                    horizontal ? new PointF(width, 0) : new PointF(0, height),
                    settings.BackgroundColor,
                    plain ? settings.BackgroundColor : settings.BackgroundColor2);
                g.FillRectangle(gradientBrush, 0, 0, width, height);
            }
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            DrawBackground(g, state, width, VerticalHeight);
            DrawGraph(g, state, width, VerticalHeight);
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            DrawBackground(g, state, HorizontalWidth, height);
            DrawGraph(g, state, HorizontalWidth, height);
        }

        class Watchers : MemoryWatcherList
        {
            public MemoryWatcher<float> AnimSpeed { get; }

            public Watchers()
            {
                AnimSpeed = new MemoryWatcher<float>(new DeepPointer(0x04EA8110, 0x30, 0x758, 0x4E48)) { Name = "AnimSpeed" };
            }
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            if (process != null && !process.HasExited &&
                string.Equals(process.ProcessName, settings.ProcessName, StringComparison.OrdinalIgnoreCase))
            {
                _Watchers.AnimSpeed.Update(process);

                AnimSpeed = _Watchers.AnimSpeed.Current;

                invalidator?.Invalidate(0, 0, width, height);
            }
            else
            {
                process = System.Diagnostics.Process.GetProcessesByName(settings.ProcessName).FirstOrDefault();
            }
        }

        public System.Windows.Forms.Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            this.settings.SetSettings(settings);
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            return settings.GetSettings(document);
        }

        public int GetSettingsHashCode()
        {
            return settings.GetSettingsHashCode();
        }

        protected virtual void Dispose(bool disposing)
        {
            bmpBuffer.Dispose();
            valueTextFormat.Dispose();
            descriptiveTextFormat.Dispose();
            graphBrush.Dispose();
            settings.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
