# Market Countdown App - Installation & Setup Checklist

Use this checklist to ensure you've completed all necessary steps for successful installation and operation.

## ✅ Pre-Installation

- [ ] Droptop Four installed (v4.0 or later)
  - Download from: https://www.droptopfour.com
  
- [ ] Rainmeter installed (v4.3 or later)
  - Download from: https://www.rainmeter.net
  
- [ ] Windows 7 SP1 or later
  - Check Windows version in Settings
  
- [ ] Administrator access to the computer
  - May be needed to change file permissions

- [ ] Located Droptop Community Apps folder
  - Standard: `C:\Program Files\Droptop Four\@Resources\GlobalSettings\0_Community\CommunityApps\`
  - Portable: `{YourDroptopFolder}\@Resources\GlobalSettings\0_Community\CommunityApps\`

## 📦 Installation Steps

- [ ] Downloaded/cloned the repository
  - Or extracted from ZIP file

- [ ] Verified folder structure is correct
  - Main folder name: `MarketCountdown`
  - Contains: `CustomApp.ini`, `Folder/`, `@Resources/`, etc.

- [ ] Copied `MarketCountdown` folder to Community Apps directory
  - NOT the parent folder, just `MarketCountdown/`
  - Result: `...\CommunityApps\MarketCountdown\`

- [ ] Set folder permissions (if needed)
  - Right-click folder → Properties → Security
  - Ensure your user has "Read" and "Read & Execute" permissions

- [ ] Fully exited Droptop
  - Right-click taskbar icon → Exit
  - Verify it's no longer in system tray

- [ ] Reopened Droptop
  - Wait 10 seconds for apps to load
  - Market Countdown should appear in app list

- [ ] Enabled Market Countdown in Droptop settings
  - Click settings (gear icon)
  - Go to "Apps"
  - Check "Market Countdown"
  - Icon appears in Droptop bar

## ⚙️ Initial Configuration

- [ ] Verified Windows timezone settings
  - Settings → Time & language → Date & time
  - Timezone matches your location
  - "Set time automatically" is enabled

- [ ] Synchronized system time (if needed)
  - Settings → Time & language → Date & time
  - Click "Sync now" button

- [ ] Tested the app
  - Click Market Countdown icon in Droptop bar
  - Menu appears with London, New York, Sydney, Tokyo
  - Click each market to verify data displays

## 🎯 Optional: User Customization

- [ ] Reviewed SETUP_GUIDE.md for options
  - Read before making changes

- [ ] Edited Variables.inc file (optional)
  - Time format (Use24Hour)
  - Dark mode (IsDarkMode)
  - Currency filters (Show[Currency])
  - Other preferences

- [ ] Added custom icons (optional)
  - Found or created 32x32 PNG icons
  - Placed in Icons/ folders
  - Verified they're white color and transparent background

- [ ] Customized market hours (if needed)
  - Edited Folder/Folder#.ini files
  - Changed MarketOpen1, MarketClose1, etc.
  - Restarted Rainmeter to apply changes

## 🧪 Verification

- [ ] Market Countdown appears in Droptop bar
  - Visible when Droptop is opened

- [ ] Clicking icon opens dropdown menu
  - Shows all four markets

- [ ] Clicking markets displays information
  - Status (OPEN/CLOSED)
  - Current time
  - Market hours
  - Time until/since open
  - Progress %

- [ ] Data updates regularly
  - Time changes every second
  - Status updates based on market hours
  - Time values count down/up

- [ ] Correct timezone is displayed
  - Times match your location

- [ ] Settings menu accessible (if applicable)
  - Right-click app → Settings (if configured)

## 🆘 Troubleshooting (if needed)

- [ ] Checked INSTALLATION.md for common issues
  - Covers most setup problems

- [ ] Viewed Rainmeter log for errors
  - Right-click Rainmeter → Open Log
  - Looked for "MarketCountdown" related messages

- [ ] Verified folder location one more time
  - Checked exact path matches requirements

- [ ] Restarted Rainmeter (if issues persist)
  - Right-click Rainmeter → Restart Rainmeter

- [ ] Checked Windows timezone after restart
  - Settings → Time & language
  - Ensured no changes occurred

- [ ] Tested in Rainmeter directly (if Droptop issues)
  - Helps isolate Droptop vs. app issues

## 📚 Documentation Review

- [ ] Read QUICK_START.txt for overview
  - Fast summary of what to do

- [ ] Read README.md for full documentation
  - Features and capabilities

- [ ] Read SETUP_GUIDE.md for configuration help
  - How to customize the app

- [ ] Bookmarked INSTALLATION.md for troubleshooting
  - Helpful reference if issues arise

- [ ] Read DEVELOPER_GUIDE.md (if interested)
  - Understanding the architecture

## 🚀 Ready to Use!

Once all checkboxes are complete, you're ready to:

1. Monitor forex market status in real-time
2. View market hours and countdown timers
3. Track progress through trading sessions
4. Customize display to your preferences
5. Use as a trading companion

---

## 📞 If You're Still Having Issues

**Check Documentation First**
1. QUICK_START.txt - Quick overview
2. INSTALLATION.md - Setup & troubleshooting
3. SETUP_GUIDE.md - Configuration help
4. README.md - Feature documentation

**Search for Help**
- Droptop Discord: https://discord.gg/droptop
- Rainmeter Forum: https://forum.rainmeter.net
- Original App: https://github.com/diegodinero/MarketCountdownStandalone

**Verify Your Setup**
- Droptop version: 4.0+
- Rainmeter version: 4.3+
- Windows version: 7 SP1+
- Folder location: Exactly as specified
- File permissions: Read + Read & Execute

---

**Congratulations! 🎉**

You're now ready to use Market Countdown to monitor forex market status and timings!

**Version**: 1.0  
**Last Updated**: November 3, 2026
