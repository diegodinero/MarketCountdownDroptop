# Market Countdown - Droptop Four App

A complete port of the [MarketCountdownStandalone](https://github.com/diegodinero/MarketCountdownStandalone) C# WPF application to **Droptop Four**, a Windows taskbar overlay enhancement using Rainmeter.

> **Note**: This is a Droptop/Rainmeter-based port of the original C# application, designed to display market status directly in your Windows taskbar.

## 🎯 What's This App Do?

Display real-time forex market status and countdown timers for major trading sessions:

- **London** (GMT 08:00–17:00)
- **New York** (EST 08:00–17:00)
- **Sydney** (AEDT 07:00–16:00)
- **Tokyo** (JST 09:00–11:30 / 12:30–15:30)

Features include:
- ✅ Real-time OPEN/CLOSED status
- ✅ Time until market opens or time since opened
- ✅ Visual progress bars for trading sessions
- ✅ Multiple timezone support
- ✅ Persistent user settings
- ✅ Dark/light mode
- ✅ 12/24 hour time format

## 📦 What You Get

```
MarketCountdownDroptop/
├── MarketCountdown/           # Main app folder (install this to Droptop)
│   ├── CustomApp.ini          # Main app config
│   ├── MainConfig.inc         # Menu structure
│   ├── Folder/                # Market submenus (London, NY, Sydney, Tokyo)
│   ├── @Resources/Scripts/    # Lua scripts for market logic
│   ├── Icons/                 # App and submenu icons
│   └── README.md              # Feature documentation
├── INSTALLATION.md            # Step-by-step installation guide
└── README.md                  # This file
```

## 🚀 Quick Start

### Prerequisites
- **Droptop Four** v4.0+ ([Download](https://www.droptopfour.com))
- **Rainmeter** v4.3+ ([Download](https://www.rainmeter.net))
- Windows 7 SP1 or later

### Installation

1. **Clone or download** this repository
2. **Copy the `MarketCountdown` folder** to:
   ```
   C:\Program Files\Droptop Four\@Resources\GlobalSettings\0_Community\CommunityApps\
   ```
3. **Restart Droptop** (or restart Rainmeter)
4. **Enable in Droptop settings** → Apps → Market Countdown
5. **Click the icon** in the Droptop bar to use!

📖 See [INSTALLATION.md](INSTALLATION.md) for detailed setup and troubleshooting.

## 📋 Configuration

Edit `MarketCountdown/Variables.inc` to customize:

```ini
[Variables]
; Display format
Use24Hour=1          ; 1 = 24-hour, 0 = 12-hour AM/PM
IsDarkMode=0         ; 1 = dark theme, 0 = light theme

; Currency & event filters
ShowAUD=1
ShowCAD=1
ShowCHF=1
; ... etc for other currencies ...

; Features
ShowNextEventToggle=1
AnnouncerSoundsEnabled=0
```

## 📁 App Structure

| File | Purpose |
|------|---------|
| `CustomApp.ini` | Main app definition (dropdown menu) |
| `MainConfig.inc` | Shared menu configuration |
| `Folder/Folder1-4.ini` | Submenus for each market |
| `Folder/FolderConfig.inc` | Shared submenu configuration |
| `VariablesDefault.inc` | Default variable values |
| `Variables.inc` | User-editable persistent variables |
| `VariablesData.inc` | Runtime data variables |
| `@Resources/Scripts/` | Lua scripts for market calculations |
| `Icons/` | PNG icon files (32x32, white) |

## 🔧 How It Works

### Architecture

1. **Rainmeter INI/INC files** define the UI structure and menus
2. **Lua scripts** handle market calculations:
   - `MarketStatus.lua` - Determines OPEN/CLOSED
   - `MarketDisplay.lua` - Calculates countdown/elapsed time
   - `MarketProgress.lua` - Calculates session progress percentage
3. **Variables files** store configuration and runtime data

### Data Flow

```
CustomApp.ini (Main menu)
    ↓
    ├→ Folder1.ini (London market)
    ├→ Folder2.ini (New York market)
    ├→ Folder3.ini (Sydney market)
    └→ Folder4.ini (Tokyo market)
        ↓
        └→ Lua scripts process time/status
            ↓
            → Display results in dropdown menus
```

## 🎨 Customization

### Custom Icons
- Replace PNG files in `Icons/` folder
- Required specs: 32x32 pixels, white color, transparent background
- Source: [Flaticon.com](https://flaticon.com) or create your own

### Market Hours
Edit `Folder/Folder#.ini` for each market:
```ini
[MeasureLondonStatus]
MarketOpen1=08:00      ; Change opening time
MarketClose1=17:00     ; Change closing time
MarketOpen2=           ; Optional: lunch break start (Tokyo)
MarketClose2=          ; Optional: lunch break end (Tokyo)
```

### Color Scheme
Edit `VariablesDefault.inc`:
```ini
[Variables]
ColorHigh=255,0,0
ColorMedium=255,165,0
ColorLow=0,128,0
ColorHoliday=0,0,255
```

## 📚 Documentation

- [MarketCountdown/README.md](MarketCountdown/README.md) - Full feature documentation
- [INSTALLATION.md](INSTALLATION.md) - Installation & troubleshooting
- [Droptop Docs](https://docs.droptopfour.com) - Official Droptop documentation
- [Rainmeter Docs](https://docs.rainmeter.net) - Official Rainmeter documentation

## 🔄 Comparison: Original vs Port

| Aspect | Original (C#/WPF) | Droptop Port |
|--------|-------------------|--------------|
| **Platform** | Standalone Windows app | Droptop/Rainmeter overlay |
| **Display** | Separate window | Taskbar dropdown menu |
| **System Resources** | Higher | Lower |
| **Always On** | Optional | Always in Droptop bar |
| **Customization** | UI dialogs | Config file editing |
| **Installation** | .exe installer | Copy folder |
| **Features** | All original features | Core market display, event calendar excluded |

## ⚙️ Troubleshooting

### Common Issues

**App doesn't appear in Droptop**
- Verify folder is in correct location
- Check folder permissions
- Restart Droptop

**Market shows wrong status**
- Verify Windows timezone
- Check market hours in config files
- Restart Rainmeter

**Time display incorrect**
- Verify timezone in Windows Settings
- Ensure system time is synchronized
- Restart the app

See [INSTALLATION.md](INSTALLATION.md) for detailed troubleshooting.

## 🤝 Contributing

This is a port of the original [MarketCountdownStandalone](https://github.com/diegodinero/MarketCountdownStandalone) application.

To contribute:
1. Fork this repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This Droptop app maintains the same license as the original application. Refer to the original repository for license details.

## 🙏 Credits

- **Original Application**: [Diego Dinero](https://github.com/diegodinero) - MarketCountdownStandalone
- **Port to Droptop**: Copilot
- **Droptop Framework**: [Cariboudjan](https://github.com/Cariboudjan) & Droptop community
- **Rainmeter**: [jsmorley](https://github.com/jsmorley) & Rainmeter community

## 📞 Support

### Getting Help

1. **Installation issues**: See [INSTALLATION.md](INSTALLATION.md)
2. **Feature questions**: Check [MarketCountdown/README.md](MarketCountdown/README.md)
3. **Technical help**:
   - [Droptop Discord](https://discord.gg/droptop)
   - [Rainmeter Community](https://forum.rainmeter.net)
4. **Original app issues**: [MarketCountdownStandalone Issues](https://github.com/diegodinero/MarketCountdownStandalone/issues)

## 🔗 Links

- **Droptop**: https://www.droptopfour.com
- **Rainmeter**: https://www.rainmeter.net
- **Original Repository**: https://github.com/diegodinero/MarketCountdownStandalone
- **Icon Source**: https://flaticon.com

---

**Version**: 1.0  
**Status**: Stable  
**Last Updated**: November 3, 2026  
**Compatibility**: Windows 7 SP1+, Droptop 4.0+, Rainmeter 4.3+
