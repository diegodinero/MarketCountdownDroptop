; Folder Config - Shared config for all submenus

[Rainmeter]
ContextTitle=Market Countdown Settings
ContextAction=[!CommandMeasure MeasureSettings "OpenSettings"]

; Number of dividers
#NumberOfDividers#=0

; Background and styling
BGColor=40,40,40,200

; Fonts
FontName=Segoe UI
FontSize=11
FontColor=255,255,255

;---Meter Definitions---

[MeterBackground]
Meter=Image
X=0
Y=0
W=350
H=200
SolidColor=#BGColor#

; String displays for each item
[MeterItem1]
Meter=String
X=15
Y=10
W=330
H=25
Text=#ItemName1#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1

[MeterItem2]
Meter=String
X=15
Y=40
W=330
H=25
Text=#ItemName2#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1

[MeterItem3]
Meter=String
X=15
Y=70
W=330
H=25
Text=#ItemName3#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1

[MeterItem4]
Meter=String
X=15
Y=100
W=330
H=25
Text=#ItemName4#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1

[MeterItem5]
Meter=String
X=15
Y=130
W=330
H=25
Text=#ItemName5#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1
