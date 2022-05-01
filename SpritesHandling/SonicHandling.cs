using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LiveSplit.Roboquest
{
    class SonicHandling
    {
        public SonicHandlingSizes[] idle;
        public SonicHandlingSizes[] idle_foot;
        public SonicHandlingSizes[] walking;
        public SonicHandlingSizes[] running;
        public SonicHandlingSizes[] idle_frustrated;
        public SonicHandlingSizes[] sonic_sprint;

        private enum SonicStatesIDs : int
        {
            idle,
            idle_foot,
            idle_frustrated,
            walking,
            running,
            sprinting
        };

        public int sonic_state;
        private int previous_sonic_state;
        public int sonic_repetition;
        public int sonic_frame;

        public SonicHandling()
        {
            idle = new SonicHandlingSizes[11];
            for (int i = 0; i < idle.Length; i++)
            {
                idle[i] = new SonicHandlingSizes(i * 36, 0, 36, 46);
            }

            idle_foot = new SonicHandlingSizes[]            //foot animation (animated at draw/3)
            {
                new SonicHandlingSizes(572, 0, 36, 46),
                new SonicHandlingSizes(608, 0, 36, 46),
                new SonicHandlingSizes(644, 0, 36, 46),
                new SonicHandlingSizes(644, 0, 36, 46),
                new SonicHandlingSizes(608, 0, 36, 46),
                new SonicHandlingSizes(644, 0, 36, 46),
                new SonicHandlingSizes(608, 0, 36, 46),
                new SonicHandlingSizes(644, 0, 36, 46),
                new SonicHandlingSizes(644, 0, 36, 46),
                new SonicHandlingSizes(608, 0, 36, 46),
                new SonicHandlingSizes(572, 0, 36, 46),
                new SonicHandlingSizes(572, 0, 36, 46),
            };

            walking = new SonicHandlingSizes[16];
            for (int i = 0; i < walking.Length; i++)
            {
                walking[i] = new SonicHandlingSizes(i / 2 * 36 + 680, 0, 36, 46);
            }

            running = new SonicHandlingSizes[8];
            for (int i = 0; i < running.Length; i++)
            {
                running[i] = new SonicHandlingSizes(i * 36 + 680, 0, 36, 46);
            }

            idle_frustrated = new SonicHandlingSizes[80];
            for (int i = 0; i < 40; i++)
            {
                idle_frustrated[i] = new SonicHandlingSizes(i * 36, 47, 36, 46);
            }
            for (int i = 0; i < 40; i++)
            {
                idle_frustrated[i + 40] = new SonicHandlingSizes(i * 36, 94, 36, 46);
            }

            sonic_sprint = new SonicHandlingSizes[4];
            for (int i = 0; i < sonic_sprint.Length; i++)
            {
                sonic_sprint[i] = new SonicHandlingSizes(i * 36 + 1004, 0, 36, 46);
            }

            sonic_state = 0;
            sonic_repetition = 0;
            sonic_frame = 0;
        }

        public Bitmap GetBitmap(float relativeValue)
        {
            sonic_frame++;
            if (relativeValue < 0.01)
            {
                if (sonic_repetition == 0 && sonic_state != (int)SonicStatesIDs.idle_foot && sonic_state != (int)SonicStatesIDs.idle_frustrated)
                    sonic_state = (int)SonicStatesIDs.idle;
                if (sonic_repetition == 6 * idle.Length)
                    sonic_state = (int)SonicStatesIDs.idle_foot;
                if (sonic_repetition == 6 * idle.Length + 2 * idle_foot.Length)
                    sonic_state = (int)SonicStatesIDs.idle_frustrated;
                if (sonic_repetition == 6 * idle.Length + 2 * idle_foot.Length + idle_frustrated.Length)
                {
                    sonic_state = 0;
                    sonic_repetition = 0;
                }


                sonic_repetition++;
            }
            else if (relativeValue > 0 && relativeValue < 0.3f)
            {
                sonic_state = (int)SonicStatesIDs.walking;
            }
            else if (relativeValue > 0.3f && relativeValue < 0.75f)
            {
                sonic_state = (int)SonicStatesIDs.running;
            }
            else
            {
                sonic_state = (int)SonicStatesIDs.sprinting;
            }

            if (previous_sonic_state == (int)SonicStatesIDs.walking && sonic_state == (int)SonicStatesIDs.running)       //this and next one for smoothing out transitions between half speed and full speed running loop
            {
                sonic_frame = sonic_frame / 2;
            }
            else if (previous_sonic_state == (int)SonicStatesIDs.running && sonic_state == (int)SonicStatesIDs.walking)
            {
                sonic_frame = sonic_frame * 2;
            }
            else if (previous_sonic_state != sonic_state)            //for reseting to frame 0 of each loop
            {
                sonic_frame = 0;
            }
            previous_sonic_state = sonic_state;


            //Get a frame from sprite sheet
            if (sonic_state == (int)SonicStatesIDs.idle)
            {
                if (sonic_frame >= idle.Length)
                    sonic_frame = 0;
                return CropBitmap(Properties.Resources.sonic_spirtes, GetArray(idle, sonic_frame));
            }
            else if (sonic_state == (int)SonicStatesIDs.idle_foot)
            {
                if (sonic_frame >= idle_foot.Length)
                    sonic_frame = 0;
                return CropBitmap(Properties.Resources.sonic_spirtes, GetArray(idle_foot, sonic_frame));
            }
            else if (sonic_state == (int)SonicStatesIDs.idle_frustrated)
            {
                if (sonic_frame >= idle_frustrated.Length)
                    sonic_frame = 0;
                return CropBitmap(Properties.Resources.sonic_spirtes, GetArray(idle_frustrated, sonic_frame));
            }
            else if (sonic_state == (int)SonicStatesIDs.walking)
            {
                if (sonic_frame >= walking.Length)
                    sonic_frame = 0;
                sonic_repetition = 0;
                return CropBitmap(Properties.Resources.sonic_spirtes, GetArray(walking, sonic_frame));
            }
            else if (sonic_state == (int)SonicStatesIDs.running)
            {
                if (sonic_frame >= running.Length)
                    sonic_frame = 0;
                sonic_repetition = 0;
                return CropBitmap(Properties.Resources.sonic_spirtes, GetArray(running, sonic_frame));
            }
            else
            {
                if (sonic_frame >= sonic_sprint.Length)
                    sonic_frame = 0;
                sonic_repetition = 0;
                return CropBitmap(Properties.Resources.sonic_spirtes, GetArray(sonic_sprint, sonic_frame));
            }
        }

        private int[] GetArray(SonicHandlingSizes[] source, int frame)
        {
            return new int[] { source[frame].left, source[frame].top, source[frame].width, source[frame].height };
        }

        private static Bitmap CropBitmap(Bitmap bitmap, int[] array)
        {
            return bitmap.Clone(new Rectangle(array[0], array[1], array[2], array[3]), bitmap.PixelFormat);
        }
    }

    class SonicHandlingSizes
    {
        public int top;
        public int left;
        public int width;
        public int height;

        public SonicHandlingSizes(int x, int y, int w, int h)
        {
            left = x;
            top = y;
            width = w;
            height = h;
        }
    }
}
