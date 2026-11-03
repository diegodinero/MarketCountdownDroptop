# 🚀 Quick Start - Get Started in 5 Minutes

## Fastest Path to Running the App

### Windows Users (Recommended)

**Step 1: Clone the Repository**
```bash
git clone https://github.com/diegodinero/MarketCountdownDroptop.git
cd MarketCountdownDroptop
git checkout feature/csharp-implementation
cd CSharp
```

**Step 2: Run the Build Script**
- Double-click `BUILD_AND_INSTALL.bat`
- Choose installation option (1 for Program Files, 2 for shortcut only)
- Script handles everything automatically!

**Step 3: Launch**
- Click the desktop shortcut or taskbar icon
- App opens with all features ready

---

## Manual Build (Alternative)

If the batch script doesn't work, follow these steps:

```bash
# Verify .NET 8.0 is installed
dotnet --version

# Build Release version
dotnet build -c Release

# Create standalone executable
dotnet publish -c Release -f net8.0-windows --self-contained -p:PublishSingleFile=true

# Run the app
.\bin\Release\net8.0-windows\publish\MarketCountdownPlugin.exe
```

---

## Integration Options

### Option A: Standalone App (Simplest)
- Just run the .exe
- No installation needed
- Works from anywhere

### Option B: Pin to Taskbar (Most Convenient)
1. Build the app (see above)
2. Right-click .exe → Create shortcut
3. Right-click shortcut → Pin to taskbar
4. Click taskbar icon to launch

### Option C: Droptop Menu (If you use Droptop)
1. Build the app
2. Copy .exe to: `C:\Program Files (x86)\Droptop\Apps\MarketCountdown\`
3. Create `manifest.ini` file (see DROPTOP_INTEGRATION_GUIDE.md)
4. Restart Droptop
5. Launch from Droptop menu

### Option D: Auto-Launch at Startup
1. Build and create shortcut
2. Move shortcut to: `C:\Users\[Your Username]\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup`
3. App launches automatically when Windows starts

---

## What You Need

- **Windows 7 SP1 or later**
- **.NET 8.0 SDK** (free, download from https://dotnet.microsoft.com/download)
- **~200 MB disk space** for standalone executable
- **Internet connection** (for forex events, not required for market display)

---

## Verify Installation

After launching, you should see:

✅ **Market Status** - Real-time display of 4 forex markets  
✅ **Countdown Timers** - Time until next market opens  
✅ **Progress Bars** - Current market session progress  
✅ **Next Event** - Upcoming forex event with countdown  
✅ **Filters** - Currency and impact level filtering  
✅ **Dark Theme** - Professional dark mode display  

---

## Features Ready to Use

| Feature | Status |
|---------|--------|
| Market monitoring | ✅ Works immediately |
| Sound alerts | ✅ Works immediately |
| Event calendar | ✅ Updates every 5 minutes |
| Filters | ✅ Configure as needed |
| Dark/Light theme | ✅ Toggle available |
| 12/24 hour time | ✅ Toggle available |

---

## Next Steps

1. **Launch the app** - See it in action
2. **Test features** - Try all filters and settings
3. **Customize** - Adjust sounds, themes, update intervals
4. **Integrate with Droptop** (optional) - See DROPTOP_INTEGRATION_GUIDE.md

---

## Troubleshooting

### .NET SDK Not Installed
- Download: https://dotnet.microsoft.com/download
- Install: Run the installer, restart terminal
- Verify: `dotnet --version`

### Build Fails
```bash
# Clean and rebuild
dotnet clean
dotnet nuget locals all --clear
dotnet build -c Release
```

### Sound Not Playing
- Check Windows volume settings
- Verify speakers/headphones connected
- Make sure "Announcer Sounds" checkbox is enabled

### Events Not Loading
- Check internet connection
- Verify Forex Factory API is accessible
- Try manual refresh

---

## Full Documentation

For complete information, see:

- **README.md** - Feature overview and usage
- **CSHARP_IMPLEMENTATION.md** - Technical details
- **DROPTOP_INTEGRATION_GUIDE.md** - All integration options

---

## Support

Having issues? Check these:

1. **Build problems** - Run: `dotnet clean && dotnet build -c Release`
2. **Runtime problems** - Check Windows volume, internet connection
3. **Droptop issues** - See DROPTOP_INTEGRATION_GUIDE.md troubleshooting section
4. **Feature questions** - See README.md or CSHARP_IMPLEMENTATION.md

---

**Status: ✅ Ready to Use**  
**Time to Launch: 5 minutes**  
**Difficulty: Easy**

Start with the batch script (`BUILD_AND_INSTALL.bat`) - it handles everything!
