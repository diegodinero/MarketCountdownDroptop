# Installation Guide for Market Countdown Droptop App

## Prerequisites

- **Droptop Four** v4.0 or later ([Download](https://www.droptopfour.com))
- **Rainmeter** v4.3 or later ([Download](https://www.rainmeter.net))
- Windows 7 SP1 or later

## Installation Steps

### Method 1: Community Apps Folder (Recommended)

1. **Locate Droptop Community Apps folder**:
   - Default location: `C:\Program Files\Droptop Four\@Resources\GlobalSettings\0_Community\CommunityApps\`
   - If using portable version: `{PortablePath}\@Resources\GlobalSettings\0_Community\CommunityApps\`

2. **Copy the MarketCountdown folder**:
   - Download or clone this repository
   - Copy the `MarketCountdown` folder to the Community Apps directory
   - Result: `C:\...\CommunityApps\MarketCountdown\`

3. **Refresh Droptop**:
   - Close Droptop (right-click taskbar icon → Exit)
   - Reopen Droptop
   - The Market Countdown app should appear in the app list

4. **Add to Droptop bar**:
   - Click Droptop settings icon
   - Navigate to "Apps" section
   - Check "Market Countdown" to enable
   - The app icon will appear in the Droptop bar

### Method 2: Manual Rainmeter Installation

1. **Locate Rainmeter Skins folder**:
   - Default: `C:\Users\{YourUsername}\Documents\Rainmeter\Skins\`

2. **Create app folder**:
   - Create: `Rainmeter\Skins\MarketCountdown\`

3. **Copy files**:
   - Copy all app files to `MarketCountdown\`

4. **Load in Rainmeter**:
   - Open Rainmeter
   - Find "MarketCountdown" in the skins list
   - Click "CustomApp.ini" and select "Load"

## First Time Setup

1. **Check timezone settings**:
   - Open Windows Settings → Time & language
   - Ensure timezone is set correctly for your location
   - Market times are relative to this setting

2. **Customize variables** (Optional):
   - Right-click app in Droptop → Settings
   - Or manually edit `Variables.inc`
   - Adjust currency filters, time format, etc.

3. **Select market icons** (Optional):
   - Replace PNG files in `Icons/` folder
   - Files should be 32x32 pixels, white color, PNG format
   - See README.md for icon resources

## Troubleshooting Installation

### App doesn't appear in Droptop

**Solution 1**: Verify folder location
```
✓ Path should be: ...\CommunityApps\MarketCountdown\
✓ Must contain: CustomApp.ini and other required files
✗ Don't use: ...\CommunityApps\MarketCountdown\MarketCountdown\
```

**Solution 2**: Check folder permissions
- Right-click folder → Properties → Security
- Ensure your user has "Read" and "Read & Execute" permissions
- Click "Edit" → Select your user → Check "Read" and "Read & Execute"

**Solution 3**: Restart Droptop
```
1. Right-click Droptop taskbar icon
2. Click "Exit"
3. Reopen Droptop
4. Wait 10 seconds for app to load
```

### Error: "Rainmeter Script Error"

**Solution 1**: Check Lua script paths
- Verify `@Resources\Scripts\` folder exists
- Confirm all `.lua` files are present:
  - MarketStatus.lua
  - MarketDisplay.lua
  - MarketProgress.lua

**Solution 2**: Check Rainmeter logs
```
1. Right-click Rainmeter icon (system tray)
2. Select "Open Log"
3. Look for error messages related to Market Countdown
4. Share log with support if needed
```

### Market shows incorrect time

**Solution 1**: Verify timezone
- Windows Settings → Time & language → Date & time
- Check "Set time automatically" is enabled
- Verify timezone matches your location

**Solution 2**: Sync system time
```
1. Right-click system time in taskbar
2. Select "Adjust date/time"
3. Click "Sync now"
4. Restart Droptop
```

**Solution 3**: Check market hours configuration
- Edit `Folder\Folder1.ini` (for London market)
- Verify `MarketOpen1` and `MarketClose1` are correct
- Repeat for other markets (Folder2, Folder3, Folder4)

### App loads but doesn't refresh

**Solution 1**: Check update interval
- Edit `CustomApp.ini`
- Find `Update=` line
- Ensure it's set to a reasonable value (1000 = 1 second)

**Solution 2**: Restart Rainmeter
```
1. Right-click Rainmeter (system tray)
2. Click "Restart Rainmeter"
3. Reload the app
```

## Uninstallation

### Method 1: From Droptop
1. Open Droptop settings
2. Go to "Apps" section
3. Uncheck "Market Countdown"
4. Delete the `MarketCountdown` folder from Community Apps

### Method 2: Manual
1. Navigate to: `C:\...\CommunityApps\`
2. Right-click `MarketCountdown` folder
3. Select "Delete"

## Next Steps

- Read [README.md](README.md) for feature documentation
- Customize [Variables.inc](Variables.inc) for your preferences
- Check [Droptop documentation](https://docs.droptopfour.com) for advanced customization

## Support Resources

| Resource | Link |
|----------|------|
| Droptop Documentation | https://docs.droptopfour.com |
| Rainmeter Documentation | https://docs.rainmeter.net |
| Original App Repository | https://github.com/diegodinero/MarketCountdownStandalone |
| Droptop Discord | https://discord.gg/droptop |

## Still Having Issues?

1. **Check Droptop logs**:
   ```
   C:\Program Files\Droptop Four\@Resources\
   ```

2. **Check Rainmeter logs**:
   ```
   Right-click Rainmeter → Open Log
   ```

3. **Verify file structure** using the structure diagram in README.md

4. **Test Rainmeter directly**:
   - Load the app in Rainmeter (not through Droptop)
   - This helps isolate Droptop-specific issues

---

**Version**: 1.0  
**Last Updated**: November 3, 2026
