# PFA (*.PFA) - FORMAT DESCRIPTION



# HEADER VERSION 2 (latest) - ASCIIHEADV2
To export the animations in this format please set the `EXPORT FORMAT`- Box to `ASCIIHEADV2`

### FEATURES
* complete redable text (standard ASCII)
* UFT8 mode
* combines animation data and color data
* only ` \n ` line termination

### FILE VERSION IDENTIFIER
At start of the *.PFA File there must be a line `ASCIIHEADV2` for identifying the new format.

### FILE SIZE HEADER
The new format requires a before parsing, information about the number of colors and layer to allocate the right ram offset values.
This is an exaple header line : 
*  `PFA_ASCIIHEADV2_8_8_10_16_RGB_1_700_48_`
