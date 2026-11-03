# Market Countdown Plugin - Complete C# Version

This is a **complete, feature-parity port** of the MarketCountdownStandalone C# WPF application to a standalone desktop application optimized for Droptop Four integration.

## 🎯 Features Implemented

### ✅ Market Monitoring (100% Complete)
- Real-time display of 4 major forex markets (London, New York, Sydney, Tokyo)
- Live market status (OPEN/CLOSED)
- Local time in each market timezone
- Market operating hours with lunch breaks (Tokyo)
- Session elapsed time (+HH:MM) or countdown to open (-HH:MM)
- Progress bar showing session completion percentage

### ✅ Sound Alerts (100% Complete)
- **5-minute warning**: "fiveminutesremaining.wav"
- **2-minute warning**: "undertaker.wav"  
- **Event trigger**: "rolereveal.wav"
- Announcer sounds toggle (enable/disable all sounds)
- Smart sound management - prevents duplicate sounds, clears old events
- Pre-play validation ensures sounds only play for visible currencies

### ✅ Forex Events Calendar (100% Complete)
- Fetches live forex events from Forex Factory (https://nfs.faireconomy.media/ff_calendar_thisweek.xml)
- Displays next upcoming event with countdown timer
- Event details: Currency, Title, Impact level, Forecast, Previous
- Updates every 5 minutes automatically
- Impact level indicators (High, Medium, Low, Holiday)

### ✅ Currency Filtering (100% Complete)
- Filter events by 9 major currencies:
  - USD, EUR, GBP, CAD, CHF, AUD, CNY, NZD, JPY
- Individual checkboxes for each currency
- Sounds only play for enabled currencies
- Real-time filtering of event list

### ✅ Impact Level Filtering (100% Complete)
- Filter events by impact type
- High, Medium, Low, Holiday events
- Toggle to show/hide each impact level
- Affects both sound alerts and event list display

### ✅ Theme Support (100% Complete)
- Dark mode (default) with professional color scheme
- Light mode option
- All UI elements properly themed
- Smooth theme switching without app restart

### ✅ Display Options (100% Complete)
- 12-hour vs 24-hour time format toggle
- Show/Hide next event section via expand/collapse
- Collapsible sections for filters (Currency, Impact)

### ✅ User Interface (100% Complete)
- Modern, clean WPF interface
- Market cards with status indicators
- Expandable/collapsible filter sections
- Event list with all relevant details
- Real-time countdown timers
- Professional color scheme with accent highlights

## 📁 Project Structure

```
MarketCountdownPlugin/
├── MarketCountdownPlugin.csproj    # Project file (.NET 6.0 WPF)
├── MarketCountdownViewModel.cs      # Complete business logic
│   ├── MarketCountdownViewModel     # Main view model (627 lines from original)
│   ├── MarketCountdownCoreVM        # Market core logic
│   └── ForexEvent                   # Event model
├── MainWindow.xaml                  # UI Layout
├── MainWindow.xaml.cs               # UI Code-behind
├── App.xaml                         # Application config
├── App.xaml.cs                      # Application logic
├── Converters.cs                    # Value converters (Status, Visibility)
├── Themes/
│   ├── DarkTheme.xaml               # Dark theme colors
│   └── LightTheme.xaml              # Light theme colors
└── Resources/
    ├── fiveminutesremaining.wav     # 5-min sound
    ├── undertaker.wav               # 2-min sound
    ├── rolereveal.wav               # Event trigger sound
    └── raidentorpedo.wav            # Bonus sound (feedback)
```

## 🛠️ Building the Project

### Requirements
- .NET 6.0 SDK or later
- Windows 7 SP1 or later
- Visual Studio 2022 (or VS Code with C# extension)

### Build Steps

```bash
# Navigate to project directory
cd MarketCountdownPlugin

# Restore dependencies
dotnet restore

# Build the project
dotnet build -c Release

# Run the application
dotnet run

# Publish for distribution
dotnet publish -c Release -f net6.0-windows --self-contained
```

### Alternative: Visual Studio Build
1. Open `MarketCountdownPlugin.csproj` in Visual Studio 2022
2. Right-click project → Build
3. Press F5 to run with debugger

## 🚀 Installation for Droptop Four

### Option 1: Run as Standalone App (Recommended)
1. Build the application (see Building section above)
2. Create a shortcut to `bin\Release\net6.0-windows\publish\MarketCountdownPlugin.exe`
3. Pin shortcut to taskbar
4. Or run during Windows startup via Task Scheduler

### Option 2: Droptop Launcher
1. Create a Droptop custom menu item that launches this app
2. Reference the built executable path
3. Run as a modal or floating window

### Option 3: Integration with Droptop Plugins
1. Place executable in Droptop's plugins directory
2. Configure Droptop to launch via menu integration
3. Customize launch behavior via Droptop settings

## 📋 Features Comparison

| Feature | Original WPF | C# Plugin | Droptop Rainmeter |
|---------|------------|----------|-----------------|
| Market Status | ✅ | ✅ | ✅ |
| Market Times | ✅ | ✅ | ✅ |
| Progress Bars | ✅ | ✅ | ✅ |
| Sound Alerts | ✅ | ✅ | ❌ |
| Event Scraping | ✅ | ✅ | ❌ |
| Currency Filter | ✅ | ✅ | ⚠️ |
| Impact Filters | ✅ | ✅ | ⚠️ |
| Theme Toggle | ✅ | ✅ | ⚠️ |
| Event List | ✅ | ✅ | ❌ |
| UI Customization | ✅ | ✅ | ⚠️ |

✅ = Fully Implemented | ⚠️ = Partial | ❌ = Not Supported

## 🔊 Sound System Details

### How Sound Alerts Work
1. **Background Service**: DispatcherTimer updates every second
2. **Event Tracking**: Maintains dictionary of played sounds by event + currency
3. **Smart Playback**: Plays sounds only once per event/currency combination
4. **Visibility Check**: Validates currency is still checked before playing (5-second buffer)
5. **Cleanup**: Automatically removes old event tracking data after 1 hour

### Sound Timings
- **-00:05:00**: "fiveminutesremaining.wav" (5 minutes before event)
- **-00:02:00**: "undertaker.wav" (2 minutes before event)
- **00:00:00**: "rolereveal.wav" (event occurrence)

### Customization
To change sounds, replace the .wav files in `Resources/` folder with your own audio files.

## 🔍 Event Details

### Data Source
- **URL**: https://nfs.faireconomy.media/ff_calendar_thisweek.xml
- **Refresh Rate**: Every 5 minutes
- **Timezone**: Converted to Eastern Standard Time (EST)

### Event Information Displayed
- **Currency**: ISO code (USD, EUR, GBP, etc.)
- **Title**: Event name (e.g., "Nonfarm Payroll")
- **Impact**: High/Medium/Low/Holiday
- **Forecast**: Expected value
- **Previous**: Previous period value
- **Time**: Local time in event's timezone

## 🎨 Customization

### Change Colors
Edit `Themes/DarkTheme.xaml` or `Themes/LightTheme.xaml`:
```xaml
<SolidColorBrush x:Key="AccentBrush">#00B4D8</SolidColorBrush>
```

### Change Update Intervals
In `MarketCountdownViewModel.cs`:
```csharp
_timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(5) }; // Event fetch
_countdownTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), ...); // Display update
```

### Modify Market Hours
In `MarketCountdownCoreVM._markets` array:
```csharp
new MarketInfo("London", "GMT Standard Time", 
    TimeSpan.FromHours(8), TimeSpan.FromHours(17))
```

## 🐛 Troubleshooting

### Sounds Not Playing
- Verify .wav files exist in Resources/ folder
- Check Windows volume settings
- Ensure AnnouncerSoundsEnabled checkbox is checked
- Check event has High or Medium impact

### Events Not Loading
- Verify internet connection
- Check if Forex Factory API is accessible
- Look in Visual Studio Output window for exceptions
- Try manually fetching (click refresh button)

### Market Times Incorrect
- Verify system timezone is set correctly
- Check Windows clock synchronization
- Verify market timezone IDs are valid

### Performance Issues
- Reduce update interval (trade-off between accuracy and CPU)
- Disable sound alerts
- Filter to fewer currencies
- Close other applications

## 📦 Distribution

### Create Installer
```bash
dotnet publish -c Release -f net6.0-windows --self-contained -p:PublishSingleFile=true
```

This creates a standalone executable that doesn't require .NET runtime installation.

### GitHub Release
1. Push code to GitHub
2. Create a Release
3. Upload `MarketCountdownPlugin.exe` (standalone build)
4. Include README and installation instructions

## 🔒 Security Notes

- Application connects to Forex Factory API (faireconomy.media)
- No personal data is transmitted
- All processing happens locally
- No telemetry or tracking

## 📄 License

This application is based on the MarketCountdownStandalone project.
See LICENSE file for details.

## 🤝 Contributing

Contributions welcome! Areas for enhancement:
- Additional sound options
- More market pairs
- Alternative event sources
- Mobile/Mac versions
- System tray integration

## 📞 Support

For issues or feature requests:
1. Check Troubleshooting section above
2. Review console output for errors
3. Check Forex Factory API status
4. Open GitHub issue with:
   - Windows version
   - .NET version (dotnet --version)
   - Error message from console
   - Steps to reproduce

## 🎉 Changelog

### Version 1.0.0
- Complete feature-parity with original C# WPF app
- Sound alerts system
- Event calendar integration
- Currency and impact filtering
- Dark/Light theme support
- 24/12 hour time format
- Real-time countdown timers
- Progress bars for each market

---

**Status**: ✅ Production Ready  
**Last Updated**: November 3, 2024  
**Version**: 1.0.0

This is a complete, standalone C# application that does NOT require Rainmeter, Droptop, or any other dependencies.
Run it as a normal Windows desktop application!
