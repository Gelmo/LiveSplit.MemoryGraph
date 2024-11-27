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
        public event EventHandler TimerResetSave;
        public event EventHandler TimerSplit;

        public Component(LiveSplitState state)
        {
            settings = new Settings();
            settings.HandleDestroyed += SettingsUpdated;
            SettingsUpdated(null, null);

            _timer.CurrentState = state;
            TimerStart += LSTimer_start;
            TimerReset += LSTimer_reset;
            TimerResetSave += LSTimer_resetsave;
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

        public MemoryWatcher<int> GameLevelMem = new MemoryWatcher<int>(new DeepPointer(IntPtr.Zero));
        public MemoryWatcher<float> GameTimeMem = new MemoryWatcher<float>(new DeepPointer(IntPtr.Zero));
        public MemoryWatcher<float> TotalRunTimeMem = new MemoryWatcher<float>(new DeepPointer(IntPtr.Zero));
        public MemoryWatcher<bool> BIsDeadMem = new MemoryWatcher<bool>(new DeepPointer(IntPtr.Zero));

        public IntPtr GWorld = IntPtr.Zero;
        public String GWorldSig = "80 7C 24 ?? 00 ?? ?? 48 8B 3D ???????? 48";
        public int GWorldOffset = 10;

        // RoboQuest.AGameState = GameState = GWorld.GameState
        public int GameState = 0x120;

        // RoboQuest.ACharacter & RoboQuest.Character_Player = PlayerCharacter = GWorld.OwningGameInstance.LocalPlayers[0].PlayerController.Character
        public int OwningGameInstance = 0x180;
        public int LocalPlayers = 0x38;
        public int PlayerZero = 0x0;
        public int PlayerController = 0x30;
        public int Character = 0x260;

        // Final offsets
        public int GameLevelOffset = 0x4A8;
        public int GameTimeOffset = 0xF68;
        public int TotalRunTimeOffset = 0xF70;
        public int BIsDeadOffset = 0x941;

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            if (process != null && !process.HasExited)
            {
                if (GWorld == IntPtr.Zero)
                {
                    GWorld = new SignatureScanner(process, process.MainModuleWow64Safe().BaseAddress, process.MainModuleWow64Safe().ModuleMemorySize).Scan(new SigScanTarget(GWorldOffset, GWorldSig) { OnFound = (p, s, ptr) => ptr + 0x4 + p.ReadValue<int>(ptr) });
                    GameLevelMem = new MemoryWatcher<int>(new DeepPointer(GWorld, GameState, GameLevelOffset));
                    GameTimeMem = new MemoryWatcher<float>(new DeepPointer(GWorld, GameState, GameTimeOffset));
                    TotalRunTimeMem = new MemoryWatcher<float>(new DeepPointer(GWorld, GameState, TotalRunTimeOffset));
                    BIsDeadMem = new MemoryWatcher<bool>(new DeepPointer(GWorld, OwningGameInstance, LocalPlayers, PlayerZero, PlayerController, Character, BIsDeadOffset));
                }

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
                    // If GameSave is enabled, save splits
                    if (settings.GameSave == true)
                    {
                        TimerResetSave?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        TimerReset?.Invoke(this, EventArgs.Empty);
                    }
                }

                // If the player has died and ResetDeath is enabled, reset the timer
                if (settings.ResetDeath == true && BIsDeadMem.Current && !BIsDeadMem.Old)
                {
                    // If DeathSave is enabled, save splits
                    if (settings.DeathSave == true)
                    {
                        TimerResetSave?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        TimerReset?.Invoke(this, EventArgs.Empty);
                    }
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
                if (System.Diagnostics.Process.GetProcessesByName("RoboQuest-Win64-Shipping").FirstOrDefault() != null)
                {
                    process = System.Diagnostics.Process.GetProcessesByName("RoboQuest-Win64-Shipping").FirstOrDefault();
                }

                if (System.Diagnostics.Process.GetProcessesByName("RoboQuest-WinGDK-Shipping").FirstOrDefault() != null)
                {
                    process = System.Diagnostics.Process.GetProcessesByName("RoboQuest-WinGDK-Shipping").FirstOrDefault();
                }
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
            _timer.Reset(false);
        }

        void LSTimer_resetsave(object sender, EventArgs e)
        {
            _timer.Reset();
        }
    }
}
