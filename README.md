# LiveSplit.Roboquest

This [LiveSplit](https://livesplit.org) component will eventually provide a variety of features related to the game [Roboquest](https://store.steampowered.com/app/692890/Roboquest/).

This preview will be updated soon...
![preview.png](/images/preview.png)

## Features

### Current

- Show the player's horizontal speed on a configurable graph

### In-progress

- Autosplit functionality (deprecate the [ASL file](https://github.com/Gelmo/Roboquest-AutoSplitter))
- Configurable option to reset the timer upon death
- Configurable option to reset the timer when restarting the run in-game, when you leave the Game Over screen, or when you go to Basecamp

### Planned

- Show the player's chosen class
- Automatically/dynamically adjust the defined title/splits (mid-run) based on the route taken
- Choose which title/splits to use from the component settings
- Show an icon (or change the theme/layout) when in certain scenarios (boss, swarm, challenge room, etc)
- Show time/collectible grade. I'll only add this if the devs are okay with it, since it's already shown in the game itself. The only reason to include it here would be for people that will be covering the in-game grade interface with LiveSplit in their recordings/streams.
- Show perks/items. Again, only if the devs approve. This would be for people that will be covering the in-game perks/items interface with LiveSplit in their recordings/streams.
- Show health (including minions/drones?). Again, only if the devs approve. This would be for people that will be covering the in-game healthbar interface with LiveSplit in their recordings/streams.
- Maybe integrated configurable timers (the goal is to have everything needed, such as timers, configurable from a single tab/component)
- Support sub-level splits
- Support single-level runs

## Installation

Download [`Components/LiveSplit.Roboquest.dll`](https://github.com/Gelmo/LiveSplit.Roboquest/raw/roboquest/Components/LiveSplit.Roboquest.dll) and move/copy it into the `Components` directory within your LiveSplit folder. You can then add it to your LiveSplit layout (after restarting LiveSplit), from the `Other` category.

## Usage

- Open LiveSplit
- Right-click LiveSplit's window
- Press `Edit Layout`
- Press the `+` icon at the top-left of the `Layout Editor` window
- From the context menu that appeared, go to `Other` and then left-click `Roboquest` in the secondary context menu
- Double-click the new `Roboquest` entry in the main section of the `Layout Editor` window. In the new `Layout Settings` window, you should be on the `Roboquest` tab
- Press the `Update XML file` button
- Select the correct version of the game from the drop-down menu next to `Game:` (this is to allow support for public test versions in the future)
- Adjust any other settings as desired
- Press `OK`
- You should configure LiveSplit to use `Game Time` if you will only be showing one timer

## Notes:

- Currently, this does not keep track of the route you have taken; you should title and organize your runs as appropriate. The autosplit functionality will only work (properly) if you have the correct number of splits configured.
- Splits for each route can be found at [the Roboquest page on speedrun.com](https://www.speedrun.com/roboquest) in [the Resources section](https://www.speedrun.com/roboquest/resources).
- There are two additional (WIP) options:
  - `Automatically reset timer upon death`
    - (Default: Disabled) - When enabled, your LiveSplit timer will reset as soon as you die in-game
  - `Automatically reset timer when restarting the run in-game, when you leave the Game Over screen, or when you go to Basecamp`
    - (Default: Enabled) - When enabled, your LiveSplit timer will reset when you restart the run via the in-game menu, when you leave the Game Over screen after death, or when you go to Basecamp
- The font used in the preview above (WIP) is `Hemi Head Rg BoldItalic`

## Credits

- [SphereMJ / kugelrund](https://www.twitch.tv/spheremj) - They are responsible for a significant majority of the code in this component. [Here is a link to the component from which this was forked.](https://github.com/kugelrund/LiveSplit.MemoryGraph)
- [SuicideMachine](https://www.twitch.tv/suicidemachine) - Credited in the original component.
- [TravisDaily](https://github.com/TravisDaily) - Credited in the original component.
- [LongerWarrior](https://github.com/LongerWarrior) - Provided me with a significant amount of information that was required for making the original ASL script. Also reviewed the script at multiple stages to help improve the quality, size, performance, and maintainability.
- [Sotumney](https://www.twitch.tv/sotumney) - Managing the speedrunning community for Roboquest.
- [dmgvol](https://github.com/Dmgvol) - Pointer path improvements in a previous version.
- [Ero](https://github.com/just-ero) - Helped me learn the basics of memory analysis for games in Unreal Engine 4, also showed me how to update this more easily in the future. More recently, helped me significantly improve my understanding.
- [Tedder](https://github.com/TheTedder) - Helped me understand more about pointers in general.
- [Speedrun Tool Development server on Discord](https://discord.gg/N6wv8pW) - Helped with initial research, general questions, and brainstorming. Very active community that helped me hit the ground running.
- [Roboquest community on Discord](https://discord.gg/roboquest) - This is a welcoming community that is easy to be a part of, and I would not have been interested in speedrunning this if that were not the case.
