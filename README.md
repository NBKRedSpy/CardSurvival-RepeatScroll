# Repeat Scroll
Allows holding a scroll key down to continiously scroll a card line.
Also has an option to change the scroll speed (disabled by default).

# Settings
|Name|Default|Description|
|--|--|--|
|ScrollRepeatDelay|250|When holding the scroll key down, indicates how often the scroll will repeat|
|ScrollSpeedMilliseconds|0|The amount of time that a scroll will take to complete.  Use zero for the game's default speed.|

# Changing the Configuration
All options are contained in the config file which is located at ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx\config\RepeatScroll.cfg```.

The .cfg file will not exist until the mod is installed and then the game is run.

To reset the config, delete the config file.  A new config will be created the next time the game is run.

# Installation 
This section describes how to manually install the mod.

If using the Vortex mod manager from NexusMods, these steps are not needed.  

## Overview
This mod requires the BepInEx mod loader.

## BepInEx Setup
If BepInEx has already been installed, skip this section.

Download BepInEx from https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x64_5.4.21.0.zip

* Extract the contents of the BepInEx zip file into the game's directory:
```<Steam Directory>\steamapps\common\Card Survival Tropical Island```

    __Important__:  The .zip file *must* be extracted to the root folder of the game.  If BepInEx was extracted correctly, the following directory will exist: ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx```.  This is a common install issue.

* Run the game.  Once the main menu is shown, exit the game.
    
* In the BepInEx folder, there will now be a "plugins" directory.

## Mod Setup
* Download the RepeatScroll.zip.  
    * If on Nexumods.com, download from the Files tab.
    * Otherwise, download from https://github.com/NBKRedSpy/CardSurvival-RepeatScroll/releases/

* Extract the contents of the zip file into the ```BepInEx/plugins``` folder.

* Run the Game.  The mod will now be enabled.

# Uninstalling

## Uninstall
This resets the game to an unmodded state.

Delete the BepInEx folder from the game's directory
```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx```

## Uninstalling This Mod Only

This method removes this mod, but keeps the BepInEx mod loader and any other mods.

Delete the ```RepeatScroll.dll``` from the ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx\plugins``` directory.

# Compatibility
Safe to add and remove from existing saves.

# Credits

<a href="https://www.flaticon.com/free-icons/curve-arrow" title="curve arrow icons">Curve arrow icons created by Kharisma - Flaticon</a>

# Change Log 
## 1.0.0  
* Initial Release

