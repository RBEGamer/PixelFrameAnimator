# PixelFrameAnimator
A animation design tool for the weather frame project.
But with the easy to parse export formats, you can it use easily in other projects.
Please see the WeaterhFrame project:
https://github.com/RBEGamer/WeatherFrame

# FEATURES
* Easy pixelart creation up to 256x256 pixels.
* Singleframe BMP import
* Multiframe BMP import
* Colortable creator/editor
* Export directly to the WeatherFrame
* ASCII and BINARY export modes
* RAM space calculator
* Export frames as multiframe BMP
* Different simple ASCII and binary based export formats (see the export area below)
* Project files can be open with the VisualStudio for Mac Preview

# EXPORT
There are multible export formats avariable :
* `PFA` used in the WeatherFrameProject and this are the ProjectFiles for this tools, please note the `PFA_FORMAT_DESCRIPTION.md`
* `CSV` export the colortable and data as CSV
* `BMP` export the frames as single frame bitmap or as spritesheet bitmap


# IMPORT RESTRICTIONS

## SINGLE FRAME BMP
* the size must be equal with the matrix size in the settings

## MULTI FRAME BMP
* the single frames must have the size of the matrix (see settings tab)
* support multi row/collum

## ASE (ASEPRITE) PROJECT IMPORT
The ASE imported is WIP!
* Imports only the new ASE project files ( Aseprite > V1.2)
* Currently only projects in RGB Mode (raw, not compressed), no masks (will be ignored), blend mode = normal



# SCREENSHOTS
### SAMPLE FRAME
![Gopher image](/documentation/screenshots/sample_1.PNG)

### COLOR TABLE AND CUSTOM COLORS
![Gopher image](/documentation/screenshots/sample_2_add_custom_color.PNG)

### SAMPLE EXPORTED DATA [ASCII MODE, COLORTABLE, HEADER V1 8Byte]
![Gopher image](/documentation/screenshots/sample_3_exported_data.PNG)


# TODO
* create .net core export library
