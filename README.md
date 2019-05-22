# SA2SaveUtility
A save utility for editing Sonic Adventure 2 PC and Xbox 360/PS3 Chao save files.

## Supports:
Editing PC and Xbox 360/PS3 chao save files, also allows saving of files to either platform allowing for converting platform.
Saving/loading/duplicating individual chao.

## How to use
1. Load your choice of save file (this file will be saved in the /backups folder, the name will be prefixed with the date and time of loading the file). For console saves you will need to extract the savedata.bin from the save file retreived from your console. The application should determine what type of save you're using and populate the UI accordingly.
2. Make any changes you'd like.
3. If using a chao save, you can click "Chao". this offers saving and duplicating the currently selected chao or allows you to load a .chao file into the selected chao slot.
4. Save your edited file, you have the choice of PC save or Console save. For console saves you'll have to rehash and resign the save for your selected console. If you're saving a Main save as a Console save, you can choose to append the current save tab to an existing file(console saves are an array of multiple saves on a single file).

## To Do
More things to edit on Main Saves
Gamecube support
Toggle between realistic and unrealistic chao values, currently mainly supports realistic values.
SADX Support(Unsure on this, once SA2 support is fully complete I may explore adding SADX althought this may have to be a seperate application).

## Images
#### Main
![Main Main Tab](https://dev.froody.tech/SA2SaveUtility/img/Main_Main.png)
![Main Missions Tab](https://dev.froody.tech/SA2SaveUtility/img/Main_Missions.png)
![Main Kart Tab](https://dev.froody.tech/SA2SaveUtility/img/Main_Kart.png)
![Main Boss Tab](https://dev.froody.tech/SA2SaveUtility/img/Main_Boss.png)
![Main Chao Tab](https://dev.froody.tech/SA2SaveUtility/img/Main_Chao.png)
#### Chao
![Chao General Tab](https://dev.froody.tech/SA2SaveUtility/img/Chao_General.png)
![Chao Stats Tab](https://dev.froody.tech/SA2SaveUtility/img/Chao_Stats.png)
![Chao Appearance Tab](https://dev.froody.tech/SA2SaveUtility/img/Chao_Appearance.png)
![Chao Evolution Tab](https://dev.froody.tech/SA2SaveUtility/img/Chao_Evolution.png)
![Chao Character Bonds Tab](https://dev.froody.tech/SA2SaveUtility/img/Chao_CharacterBonds.png)
![Chao Personality Tab](https://dev.froody.tech/SA2SaveUtility/img/Chao_Personality.png)
![Chao Health Tab](https://dev.froody.tech/SA2SaveUtility/img/Chao_Health.png)
![Chao DNA Tab](https://dev.froody.tech/SA2SaveUtility/img/Chao_DNA.png)

## Credits
#### Froody
Tool creation, offset gathering (primarily main save offsets).
#### Fusion (https://chao.tehfusion.co.uk/chao-hacking/)
Some chao offsets obtained from Fusion's chao documentation.
#### MainMemory
Providing me with information regarding how the Main calculates it's hashsum.
#### Icon
https://github.com/feathericons/feather#feather
