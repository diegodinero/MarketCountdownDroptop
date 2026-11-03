# Market Countdown Droptop App

A Droptop Four community app that displays real-time forex market status, open/close times, and countdown timers for major trading sessions (London, New York, Sydney, Tokyo).

## Features

- **Real-time Market Status**: View if major forex markets are OPEN or CLOSED
- **Market Timers**: Shows time until market open (countdown) or time since market opened (elapsed)
- **Progress Bars**: Visual progress indicators for current trading sessions
- **Multiple Timezones**: Displays market hours in respective local times
- **Customizable Settings**: Filter currency pairs and economic events
- **Dark/Light Mode Support**: Toggle between dark and light themes
- **12/24 Hour Time Format**: Choose your preferred time display format
- **Sound Announcements**: Optional announcements for market events

## Installation

1. Download or clone this repository
2. Place the `MarketCountdown` folder in your Droptop Community Apps directory:
   ```
   C:\Program Files\Droptop Four\@Resources\GlobalSettings\0_Community\CommunityApps\MarketCountdown
   ```
3. Restart Droptop or reload apps
4. Click the Market Countdown icon in the Droptop bar

## App Structure

```
MarketCountdown/
├── CustomApp.ini              # Main app config (dropdown menu definition)
├── MainConfig.inc             # Main menu configuration
├── VariablesDefault.inc       # Default variables
├── Variables.inc              # User-editable persistent variables
├── VariablesData.inc          # Runtime data variables
├── Icons/                     # Main menu icons (1Icon.png - 4Icon.png)
├── Folder/
│   ├── Folder1.ini           # London market submenu
│   ├── Folder2.ini           # New York market submenu
│   ├── Folder3.ini           # Sydney market submenu
│   ├── Folder4.ini           # Tokyo market submenu
│   ├── FolderConfig.inc      # Shared submenu configuration
│   └── Icons/
│       ├── 1/                # London icons
│       ├── 2/                # New York icons
│       ├── 3/                # Sydney icons
│       └── 4/                # Tokyo icons
└── @Resources/
    └── Scripts/
        ├── MarketStatus.lua  # Determines OPEN/CLOSED status
        ├── MarketDisplay.lua # Shows countdown or elapsed time
        └── MarketProgress.lua # Calculates session progress %
```

## Configuration

### Variables.inc - User Settings

Edit `Variables.inc` to customize these settings:

```ini
[Variables]
; Currency Filters (1 = show, 0 = hide)
ShowAUD=1
ShowCAD=1
ShowCHF=1
ShowCNY=1
ShowEUR=1
ShowGBP=1
ShowJPY=1
ShowNZD=1
ShowUSD=1

; Impact Filters
ShowHighImpact=1
ShowMediumImpact=1
ShowLowImpact=1
ShowHolidayImpact=1

; Display Settings
IsDarkMode=0
Use24Hour=1
ShowNextEventToggle=1
AnnouncerSoundsEnabled=0
```

## Market Hours (EST/UTC)

| Market  | Session 1      | Session 2      | Timezone              |
|---------|----------------|----------------|-----------------------|
| London  | 08:00–17:00 UTC | —              | GMT Standard Time     |
| New York| 08:00–17:00 EST | —              | Eastern Standard Time |
| Sydney  | 07:00–16:00 AEDT| —              | AUS Eastern Standard Time |
| Tokyo   | 09:00–11:30 JST | 12:30–15:30 JST| Tokyo Standard Time   |

## How to Use

1. **Click the Market Countdown icon** in the Droptop bar to see the main menu
2. **Click each market name** to expand and see detailed information:
   - Market Status (OPEN/CLOSED)
   - Current Local Time
   - Market Hours
   - Time until next open (or time since open)
   - Session Progress Percentage
3. **Click Settings** at the bottom of the main menu to access options

## Customization

### Adding/Editing Icons

Icons are located in the `Icons/` directory and should be:
- **Format**: PNG with alpha transparency
- **Size**: 32x32 pixels
- **Color**: White (255, 255, 255) for best theme compatibility
- **Naming**: `1Icon.png`, `2Icon.png`, etc.

You can create custom icons using:
- [Flaticon.com](https://www.flaticon.com) - Free icon library
- GIMP or Photoshop
- Any image editor that supports PNG with transparency

### Editing Market Hours

To modify market hours, edit the respective `Folder/Folder#.ini` file:

```ini
[MeasureLondonStatus]
Measure=Script
ScriptFile=#@#Scripts/MarketStatus.lua
MarketName=London
MarketTimeZone=GMT Standard Time
MarketOpen1=08:00      ; <- Change this
MarketClose1=17:00     ; <- Or this
```

## Rainmeter Scripts

The app uses Lua scripts for dynamic market calculations:

### MarketStatus.lua
Determines if a market is currently OPEN or CLOSED by comparing current time to market hours.

### MarketDisplay.lua
Shows countdown (negative) or elapsed time (positive) relative to market open/close.
- `-05:30` = 5 hours 30 minutes until market opens
- `+02:15` = 2 hours 15 minutes since market opened

### MarketProgress.lua
Calculates progress through current session as percentage (0-100%).

## Troubleshooting

### Market shows incorrect status
- Check timezone settings in Windows
- Verify market hours in `Folder/Folder#.ini` files
- Check if current day is a market holiday (manually add holiday checks if needed)

### Time display is incorrect
- Ensure Windows timezone is set correctly
- Toggle `Use24Hour` in `Variables.inc` to refresh
- Restart Rainmeter/Droptop

### App doesn't appear in Droptop
- Check that folder is in correct location
- Verify folder permissions are readable
- Restart Droptop or reload apps
- Check Droptop/Rainmeter logs for errors

## Future Enhancements

- [ ] Economic calendar with upcoming events
- [ ] Holidays/Market closures database
- [ ] Audio alerts for market open/close
- [ ] Configurable market hours UI
- [ ] Color coding by market status
- [ ] Multiple timezone display support

## Credits

Ported from [MarketCountdownStandalone](https://github.com/diegodinero/MarketCountdownStandalone) C# WPF application.

**Original App**: Diego Dinero
**Droptop Port**: Copilot

## License

This Droptop app maintains the same license as the original application. Please refer to the original repository for license information.

## Support

For issues or feature requests:
1. Check the original repository: https://github.com/diegodinero/MarketCountdownStandalone
2. Refer to Droptop documentation: https://docs.droptopfour.com
3. Join the Droptop Discord community for help

---

**Version**: 1.0  
**Last Updated**: November 3, 2026  
**Rainmeter Version**: 4.3+  
**Droptop Version**: 4.0+
