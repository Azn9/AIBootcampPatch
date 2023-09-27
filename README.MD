# AIBootcampPatch

This is a patch for AIBootcamp. It enables the use of arrow keys to move forward or backward in a replay without having to use the mouse.

## Installation

/!\ Do NOT replace the original AIBootcamp, the patched one CAN'T be used to run the simulation, only to view replays!

### Automatic
1. Unzip the .zip I sent on Discord
2. Replace the default app used to open .replay files with the RUN.bat file found in the unzipped folder.

### Manual
1. Download MelonLoader from [here](https://github.com/HerpDerpinstine/MelonLoader/releases/latest/download/MelonLoader.Installer.exe)
2. Run the installer and select the AIBootcamp.exe file.
3. Download the latest release from [here](https://github.com/Azn9/AIBootcampPatch/releases/latest/download/AIBootcampPatch.dll) (or build it yourself, see below)
4. Move the .dll in the "Mods" folder created by MelonLoader in the AIBootcamp folder.
5. In the AIBootcamp install folder, create a file named "RUN.bat" with the following content:
```
@echo off

CD /D %~dp0
start AIBootcamp2.exe %1
```
6. Replace the default app used to open .replay files with the RUN.bat file you just created.

## Building
You can build the patch yourself by cloning the repo  and opening the solution. You will need to add the following references:
- Assembly-CSharp
- MelonLoader
- UnityEngine
- UnityEngine.CoreModule
- UnityEngine.InputModule
- UnityEngine.UI

These can be found in the `AIBootCamp\MelonLoader\Managed` folder.
