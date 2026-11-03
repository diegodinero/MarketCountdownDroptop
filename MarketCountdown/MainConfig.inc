;Main Config Include

[Rainmeter]
ContextTitle=Market Countdown Settings
ContextAction=[!CommandMeasure MeasureSettings "OpenSettings"]

; Number of menu items (markets: London, NY, Sydney, Tokyo)
#NumberOfItems#=4

; Number of dividers
#NumberOfDividers#=0

; Enable folders for submenus (each market has trading info)
ItemIsFolder1=1
ItemIsFolder2=1
ItemIsFolder3=1
ItemIsFolder4=1

; Item names that appear in dropdown
ItemName1=London
ItemName2=New York
ItemName3=Sydney
ItemName4=Tokyo

; Item commands (folders will open submenus)
ItemCommand1=[]
ItemCommand2=[]
ItemCommand3=[]
ItemCommand4=[]

; Item parameters
ItemParam1=
ItemParam2=
ItemParam3=
ItemParam4=

; Background and styling
BGColor=40,40,40,200

; Fonts
FontName=Segoe UI
FontSize=11
FontColor=255,255,255

; Icons (numbered 1Icon.png to 4Icon.png)
; These are located in the Icons folder
IconColor=255,255,255,255
IconSize=32

;---Meter Definitions---

[MeterBackground]
Meter=Image
X=0
Y=0
W=300
H=#ItemHeight#
SolidColor=#BGColor#

[MeterDividerBackground]
Meter=Image
X=0
Y=0
W=300
H=1
SolidColor=100,100,100,100

;---String Display---

[MeterItem1]
Meter=String
X=50
Y=0
W=250
H=30
Text=#ItemName1#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1

[MeterItem2]
Meter=String
X=50
Y=30
W=250
H=30
Text=#ItemName2#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1

[MeterItem3]
Meter=String
X=50
Y=60
W=250
H=30
Text=#ItemName3#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1

[MeterItem4]
Meter=String
X=50
Y=90
W=250
H=30
Text=#ItemName4#
FontFace=#FontName#
FontSize=#FontSize#
FontColor=#FontColor#
StringAlign=LeftCenter
AntiAlias=1

; Settings Button
[MeterSettings]
Meter=String
X=10
Y=125
W=280
H=25
Text=⚙ Settings
FontFace=#FontName#
FontSize=10
FontColor=200,200,200,255
StringAlign=Center
AntiAlias=1
LeftMouseUpAction=[!CommandMeasure MeasureSettings "OpenSettings"]
