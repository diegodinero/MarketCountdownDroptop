# Market Countdown App Setup Guide

Welcome to the Market Countdown Droptop App! This guide will help you set up and customize the app.

## 📋 Pre-Installation Checklist

Before installing, ensure you have:

- [ ] Droptop Four installed (v4.0+)
- [ ] Rainmeter installed (v4.3+)
- [ ] Windows 7 SP1 or later
- [ ] Administrator access to install
- [ ] Located your Droptop Community Apps folder

## 🚀 Quick Installation (2 minutes)

### Step 1: Locate Your Community Apps Folder

**Standard Installation** (Droptop installed normally):
```
C:\Program Files\Droptop Four\@Resources\GlobalSettings\0_Community\CommunityApps\
```

**Portable Installation** (Droptop folder unpacked manually):
```
{YourDroptopFolder}\@Resources\GlobalSettings\0_Community\CommunityApps\
```

### Step 2: Copy MarketCountdown Folder

1. Download or clone this repository
2. Copy the `MarketCountdown` folder (not just the files inside)
3. Paste into your Community Apps folder
4. Result should be: `..\CommunityApps\MarketCountdown\` ✓

### Step 3: Restart Droptop

1. Right-click Droptop in system tray
2. Click "Exit"
3. Reopen Droptop
4. Wait 10 seconds for app to load

### Step 4: Enable the App

1. Click Droptop settings icon (gear)
2. Go to "Apps" section
3. Check "Market Countdown"
4. The app icon appears in Droptop bar! 🎉

## ⚙️ First Time Configuration

### 1. Verify Your Timezone

The app displays market times based on your system timezone:

1. **Windows Settings** → Time & language → Date & time
2. Ensure "Set time automatically" is **enabled**
3. Verify your timezone is correct (affects all market time calculations)
4. Restart the app after any timezone changes

### 2. Customize User Settings

Edit `MarketCountdown/Variables.inc` to set your preferences:

```ini
[Variables]
; Time Format
Use24Hour=1          ; 1 = 23:45 format, 0 = 11:45 PM format
IsDarkMode=0         ; 1 = dark theme, 0 = light theme

; Currency Filters (1 = show, 0 = hide)
ShowAUD=1            ; Australian Dollar
ShowCAD=1            ; Canadian Dollar
ShowCHF=1            ; Swiss Franc
ShowCNY=1            ; Chinese Yuan
ShowEUR=1            ; Euro
ShowGBP=1            ; British Pound
ShowJPY=1            ; Japanese Yen
ShowNZD=1            ; New Zealand Dollar
ShowUSD=1            ; US Dollar

; Economic Events
ShowHighImpact=1     ; Show high impact events
ShowMediumImpact=1   ; Show medium impact events
ShowLowImpact=1      ; Show low impact events
ShowHolidayImpact=1  ; Show holiday impact events

; Features
ShowNextEventToggle=1
AnnouncerSoundsEnabled=0
```

### 3. Add Custom Icons (Optional)

Icons are located in:
- Main menu: `MarketCountdown/Icons/`
- Submenus: `MarketCountdown/Folder/Icons/1/`, `2/`, `3/`, `4/`

**To add custom icons**:
1. Create or download 32x32 PNG icons (white color, transparent background)
2. Save as `1Icon.png`, `2Icon.png`, etc.
3. Replace the placeholder files in each `Icons/` folder
4. Restart Droptop

**Icon sources**:
- [Flaticon.com](https://flaticon.com) - Free icons
- Create your own in GIMP, Photoshop, or Paint.NET

## 📖 Using the App

### Main Menu
Click the Market Countdown icon in Droptop bar to see:
- London
- New York
- Sydney
- Tokyo
- ⚙ Settings

### Market Submenus
Click on any market name to expand and see:
1. **Status**: OPEN or CLOSED
2. **Time**: Current local time in that market
3. **Hours**: Regular market hours
4. **Next Open**: Countdown (-HH:MM) or elapsed (+HH:MM)
5. **Progress**: % through current session

### Understanding Display Values

| Display | Meaning |
|---------|---------|
| `-05:30` | Market opens in 5 hours 30 minutes |
| `+02:15` | Market has been open for 2 hours 15 minutes |
| `OPEN` | Market is currently open for trading |
| `CLOSED` | Market is not currently open |
| `75%` | Session is 75% complete |

## 🎯 Market Hours Reference

All times are listed in the respective market's local timezone:

| Market  | Hours | Timezone | Status |
|---------|-------|----------|--------|
| London  | 08:00–17:00 | GMT (UTC+0) | Monday–Friday |
| New York| 08:00–17:00 | EST (UTC-5) | Monday–Friday |
| Sydney  | 07:00–16:00 | AEDT (UTC+11) | Monday–Friday |
| Tokyo   | 09:00–11:30<br/>12:30–15:30 | JST (UTC+9) | Monday–Friday |

*Note: Tokyo has a lunch break (11:30–12:30)*

## 🔧 Advanced Configuration

### Customizing Market Hours

Edit `MarketCountdown/Folder/Folder#.ini` to change market hours:

**For London** (`Folder1.ini`):
```ini
[MeasureLondonStatus]
MarketOpen1=08:00    ; Change opening time
MarketClose1=17:00   ; Change closing time
```

**For Tokyo with lunch** (`Folder4.ini`):
```ini
[MeasureTokyoStatus]
MarketOpen1=09:00
MarketClose1=11:30
MarketOpen2=12:30    ; Lunch break ends
MarketClose2=15:30
```

### Changing Theme Colors

Edit `MarketCountdown/VariablesDefault.inc`:

```ini
[Variables]
ColorHigh=255,0,0          ; Red for high impact
ColorMedium=255,165,0      ; Orange for medium impact
ColorLow=0,128,0           ; Green for low impact
ColorHoliday=0,0,255       ; Blue for holidays
ColorNeutral=169,169,169   ; Gray for neutral
```

**Color format**: RGB values (0-255 each)
- Red: 255,0,0
- Green: 0,255,0
- Blue: 0,0,255
- White: 255,255,255
- Black: 0,0,0

### Enabling/Disabling Features

In `Variables.inc`, toggle these settings:

```ini
ShowNextEventToggle=1      ; Show next economic event
AnnouncerSoundsEnabled=0   ; Play sound on market events
```

## 🔍 Troubleshooting

### App doesn't appear in Droptop bar

**Check 1**: Verify file location
```
✓ Correct: C:\...\CommunityApps\MarketCountdown\
✗ Wrong: C:\...\CommunityApps\MarketCountdown\MarketCountdown\
```

**Check 2**: Verify folder permissions
1. Right-click `MarketCountdown` folder
2. Properties → Security → Edit
3. Select your user → Check "Read" and "Read & Execute"
4. Click OK

**Check 3**: Restart properly
1. Close Droptop completely
2. Wait 5 seconds
3. Reopen Droptop
4. Wait 10 seconds for apps to load

### Market shows CLOSED when it should be OPEN

**Check 1**: Verify Windows timezone
- Settings → Time & language → Date & time
- Ensure timezone matches your location

**Check 2**: Check system time sync
- Click system time → "Adjust date/time"
- Enable "Set time automatically"
- Click "Sync now"

**Check 3**: Verify market hours in config
- Edit `Folder/Folder1.ini` for London
- Check `MarketOpen1` and `MarketClose1` values
- Repeat for other markets

### Wrong time displayed

**Solution 1**: Toggle time format
- Edit `Variables.inc`
- Change `Use24Hour=1` to `Use24Hour=0` (or vice versa)
- Restart Droptop

**Solution 2**: Restart Rainmeter
- Right-click Rainmeter (system tray)
- Click "Restart Rainmeter"

### App shows error messages

**Check Rainmeter logs**:
1. Right-click Rainmeter
2. Select "Open Log"
3. Look for "MarketCountdown" errors
4. Share errors in Droptop Discord if needed

## 📞 Getting Help

### Documentation
- **Installation**: See `INSTALLATION.md`
- **Features**: See `MarketCountdown/README.md`
- **Droptop**: https://docs.droptopfour.com
- **Rainmeter**: https://docs.rainmeter.net

### Support Communities
- **Droptop Discord**: https://discord.gg/droptop
- **Rainmeter Forum**: https://forum.rainmeter.net
- **Original App**: https://github.com/diegodinero/MarketCountdownStandalone

## ✨ Tips & Tricks

### Tip 1: Use Favorites
- Right-click specific markets to add to favorites
- Quick access without opening main menu

### Tip 2: Customize for Your Trading Times
- Edit market hours if you trade different sessions
- Save changes and restart

### Tip 3: Monitor Multiple Timezones
- Each market shows local time and global position
- Useful for coordinating international trading

### Tip 4: Sound Notifications
- Enable `AnnouncerSoundsEnabled=1` for alerts
- Get notified when markets open/close

### Tip 5: Minimize Clutter
- Hide unwanted currencies with `Show[Currency]=0`
- Reduce visual information to only what you need

## 🚀 Next Steps

1. **Customize Variables.inc** for your preferences
2. **Add custom icons** if desired
3. **Adjust market hours** if you trade non-standard sessions
4. **Enable notifications** if you want alerts
5. **Join Discord community** for advanced tips

## 📝 Version Info

- **App Version**: 1.0
- **Compatible with**: Droptop 4.0+, Rainmeter 4.3+
- **Last Updated**: November 3, 2026
- **Original App**: [MarketCountdownStandalone](https://github.com/diegodinero/MarketCountdownStandalone)

---

**Happy trading! 📈**

Need help? Check the troubleshooting section or visit the Droptop Discord community.
