# PFA (*.PFA) - FORMAT DESCRIPTION



## HEADER VERSION 2 (latest) - ASCIIHEADV2
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

#### DETAILED EXPLANATION OF FILE SIZE HEADER
Field explanation from left to right!

* `PFA` (char[3]) is the magic word, must bew PFA
* `ASCIIHEADV2`(char[15]) the header version (this is required since file version 2)
* `8`(1 byte) is the width of the matrix (maximum width, layer width can vary)
* `8`(1 byte) is the height of the matrix (maximum height, layer height can vary)
* `10`(1 byte) is the count of layers
* `16` (1 byte) is the count of used colors
* `RGB` (char[3]) is the color address mode : can be [RGB,GRB,BGR,BRG]
* `1` (1 byte) reserved (parsing datatype)
* `700` (unsigned int) color table size (=  write offset)
* `48` (usnigend int) data table size (= write offset)

### FRAME
Describes a complete frame, with FRAME HEADER for size, opcacity and other user data.
After the FRAME HEADER fllows the data matrix with : height rows and rows collums.

* `FRAME_0_10_8_8_100_255`
* `<begin data table>`
* `color_index, color_index, color_index`
* `color_index, color_index, color_index`
* `<end data tbale>`

#### DETAILED EXPLANATION OF FRAME HEADER
Field explanation from left to right!

* `FRAME` (char[5]) start of a new data frame = magic word must be 'FRAME'
* `0` (1 byte) id/index of the frame
* `10` (1 byte) count of frames
* `8` (1 byte) width of the frame
* `8` (1 byte) height of the frame
* `100` (1 byte) animation speed/delay in ms
* `255` (1 byte) opacity of the frame : 0 = not visible, 255= 100% visible


#### DETAILED EXPLANATION OF FRAME DATE
After the Header (see below) comes the data filed, filled with color ids and seperated with `,` (collums) and with new line `\n` for the rows

