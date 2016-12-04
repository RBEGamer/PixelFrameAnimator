# PFA (*.PFA) - FORMAT DESCRIPTION



# HEADER VERSION 2 (latest) - ASCIIHEADV2
To export the animations in this format please set the `EXPORT FORMAT`- Box to `ASCIIHEADV2`

### FEATURES
* complete redable text (standard ASCII)
* UFT8 mode
* combines animation data and color data
* only ` \n ` line termination
* the headers will be split by a `_`
* the matrix data will be split by a `,`

### FILE VERSION IDENTIFIER
At start of the *.PFA File there must be a line `ASCIIHEADV2` for identifying the new format.

### FILE SIZE HEADER
The new format requires a before parsing, information about the number of colors and layer to allocate the right ram offset values.
This is an example header line : 
*  `PFA_ASCIIHEADV2_8_8_10_16_RGB_1_700_48_`

#### DETAILED EXPLANATION 
* `PFA` is the magic word
* `ASCIIHEADV2` the header version (this is required since file version 2)
* `8` is the width of the matrix (maximum width, layer width can vary)
