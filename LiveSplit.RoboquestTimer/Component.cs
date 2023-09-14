using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace LiveSplit.RoboquestTimer
{
    public class Component : IComponent
    {
        private Settings settings;

        public string ComponentName => "Roboquest Timer";

        public float PaddingTop => 0;
        public float PaddingLeft => 0;
        public float PaddingBottom => 0;
        public float PaddingRight => 0;

        public float VerticalHeight => 0;
        public float MinimumWidth => 0;
        public float HorizontalWidth => 0;
        public float MinimumHeight => 0;

        public IDictionary<string, Action> ContextMenuControls => null;

        private System.Diagnostics.Process process;

        private TimerModel _timer = new TimerModel();
        public event EventHandler TimerStart;
        public event EventHandler TimerReset;
        public event EventHandler TimerSplit;

        public Component(LiveSplitState state)
        {
            settings = new Settings();
            settings.HandleDestroyed += SettingsUpdated;
            SettingsUpdated(null, null);

            _timer.CurrentState = state;
            TimerStart += LSTimer_start;
            TimerReset += LSTimer_reset;
            TimerSplit += LSTimer_split;
        }

        private void SettingsUpdated(object sender, EventArgs e)
        {
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
        }

        public MemoryWatcher<int> GameLevelMem = new MemoryWatcher<int>(new DeepPointer(0x04EA8110, 0x30, 0xA98, 0x420));
        public MemoryWatcher<float> GameTimeMem = new MemoryWatcher<float>(new DeepPointer(0x04EA8110, 0x30, 0xA98, 0xAC8));
        public MemoryWatcher<float> TotalRunTimeMem = new MemoryWatcher<float>(new DeepPointer(0x04EA8110, 0x30, 0xA98, 0xAD0));
        public MemoryWatcher<bool> BIsDeadMem = new MemoryWatcher<bool>(new DeepPointer(0x04EA8110, 0x30, 0x758, 0x8A2));

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            if (process != null && !process.HasExited)
            {
                GameLevelMem.Update(process);
                GameTimeMem.Update(process);
                TotalRunTimeMem.Update(process);
                BIsDeadMem.Update(process);

                state.SetGameTime(TimeSpan.FromSeconds(GameTimeMem.Current));

                // If the in-game time is running and the in-game time was previously 0, start the timer
                if (GameTimeMem.Current > 0 && GameTimeMem.Old == 0)
                {
                    TimerStart?.Invoke(this, EventArgs.Empty);
                    state.SetGameTime(TimeSpan.FromSeconds(GameTimeMem.Current));
                }

                // If the in-game timer is set to 0 and ResetGame is enabled, reset the timer. This occurs when restarting the run in-game, when you leave the Game Over screen, or when you go to Basecamp
                if (settings.ResetGame == true && GameTimeMem.Current == 0 && GameTimeMem.Old == 0)
                {
                    TimerReset?.Invoke(this, EventArgs.Empty);
                }

                // If the player has died and ResetDeath is enabled, reset the timer
                if (settings.ResetDeath == true && BIsDeadMem.Current && !BIsDeadMem.Old)
                {
                    TimerReset?.Invoke(this, EventArgs.Empty);
                }

                // If the game has updated TotalRunTime and the player has not died, split. This should only occur on the final split
                if (TotalRunTimeMem.Current > 0 && TotalRunTimeMem.Old == 0 && !BIsDeadMem.Current)
                {
                    TimerSplit?.Invoke(this, EventArgs.Empty);
                }
                // Otherwise, if the current level differs from the level in the previous loop, split
                else if (GameLevelMem.Current != GameLevelMem.Old)
                {
                    TimerSplit?.Invoke(this, EventArgs.Empty);
                }

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
            settings.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void LSTimer_start(object sender, EventArgs e)
        {
            _timer.Start();
        }

        void LSTimer_split(object sender, EventArgs e)
        {
            _timer.Split();
        }

        void LSTimer_reset(object sender, EventArgs e)
        {
            _timer.Reset();
        }
    }
}
