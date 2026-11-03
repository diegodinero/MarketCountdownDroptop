# 🚀 Market Countdown Droptop App - START HERE

Welcome! This is your guide to getting started with the Market Countdown app for Droptop Four.

## ⏱️ Quick Links Based on Your Needs

### 🆕 **First Time Installing?**
Start with these in order:

1. **[QUICK_START.txt](QUICK_START.txt)** ← Read this first (5 min read)
   - Overview of what this app does
   - 3-step installation instructions
   - Basic troubleshooting

2. **[INSTALLATION.md](INSTALLATION.md)** ← For detailed setup
   - Step-by-step installation guide
   - Common issues and solutions
   - Folder location guide

3. **[SETUP_GUIDE.md](SETUP_GUIDE.md)** ← After installation
   - Configure time zones
   - Customize settings
   - Add custom icons

### ❓ **Need Help?**
- **Installation problems?** → [INSTALLATION.md](INSTALLATION.md)
- **Want to customize?** → [SETUP_GUIDE.md](SETUP_GUIDE.md)
- **Verify setup worked?** → [CHECKLIST.md](CHECKLIST.md)
- **Understand how it works?** → [DEVELOPER_GUIDE.md](DEVELOPER_GUIDE.md)

### 📚 **Want Full Documentation?**
Read in this order:
1. [README.md](README.md) - Complete feature overview
2. [SETUP_GUIDE.md](SETUP_GUIDE.md) - Customization guide
3. [DEVELOPER_GUIDE.md](DEVELOPER_GUIDE.md) - Technical details

### 🔍 **Looking for Something Specific?**
- **What files are included?** → [FILES_INCLUDED.md](FILES_INCLUDED.md)
- **Project status & stats?** → [SUMMARY.md](SUMMARY.md)
- **Installation checklist?** → [CHECKLIST.md](CHECKLIST.md)
- **Quick reference?** → [QUICK_START.txt](QUICK_START.txt)

---

## 📦 What's in This Package?

```
MarketCountdownDroptop/
│
├── START_HERE.md                 ← YOU ARE HERE
├── QUICK_START.txt               ← Read this first!
├── README.md                     ← Full documentation
├── INSTALLATION.md               ← Setup guide
├── SETUP_GUIDE.md               ← Customization
├── DEVELOPER_GUIDE.md           ← Technical deep dive
├── CHECKLIST.md                 ← Verification checklist
├── SUMMARY.md                   ← Project overview
├── FILES_INCLUDED.md            ← Complete file listing
│
└── MarketCountdown/             ← THE APP FOLDER
    ├── CustomApp.ini            (main config)
    ├── MainConfig.inc           (menu structure)
    ├── Variables.inc            (YOUR SETTINGS)
    ├── VariablesData.inc        (runtime data)
    ├── VariablesDefault.inc     (defaults)
    ├── README.md                (app documentation)
    ├── Folder/                  (submenu configs)
    │   ├── Folder1.ini - London
    │   ├── Folder2.ini - New York
    │   ├── Folder3.ini - Sydney
    │   ├── Folder4.ini - Tokyo
    │   ├── FolderConfig.inc
    │   └── Icons/               (5 icon folders)
    ├── @Resources/
    │   └── Scripts/
    │       ├── MarketStatus.lua
    │       ├── MarketDisplay.lua
    │       └── MarketProgress.lua
    └── Icons/                   (main menu icons)
```

---

## ⚡ 3-Minute Quick Start

### Step 1: Copy the App (1 minute)
1. Copy the **`MarketCountdown`** folder
2. Paste into: `C:\Program Files\Droptop Four\@Resources\GlobalSettings\0_Community\CommunityApps\`
3. Result: `.../CommunityApps/MarketCountdown/` ✓

### Step 2: Restart Droptop (1 minute)
1. Right-click Droptop in taskbar
2. Click "Exit"
3. Reopen Droptop
4. Wait 10 seconds

### Step 3: Enable & Use (1 minute)
1. Click Droptop settings (gear icon)
2. Go to "Apps" → Check "Market Countdown"
3. Click the icon in Droptop bar
4. Done! 🎉

---

## 📖 Document Guide

| Document | Read Time | Purpose | When to Read |
|----------|-----------|---------|--------------|
| **START_HERE.md** | 2 min | Navigation guide | Right now! |
| **QUICK_START.txt** | 5 min | Quick overview | Before installing |
| **INSTALLATION.md** | 10 min | Detailed setup | During installation |
| **SETUP_GUIDE.md** | 15 min | Customization | After installation |
| **README.md** | 10 min | Full documentation | If you want details |
| **DEVELOPER_GUIDE.md** | 15 min | Technical info | If you're a developer |
| **CHECKLIST.md** | 10 min | Verification | To confirm setup worked |
| **SUMMARY.md** | 10 min | Project overview | For project info |
| **FILES_INCLUDED.md** | 10 min | File listing | To understand package |

---

## ❓ Common Questions

### Q: Do I need to install anything else?
**A:** Just Droptop and Rainmeter (most Windows users have Rainmeter for other apps).
- Droptop: https://www.droptopfour.com
- Rainmeter: https://www.rainmeter.net

### Q: Will this work on Windows 11?
**A:** Yes! Works on Windows 7 SP1 through Windows 11.

### Q: How do I customize it?
**A:** Edit `MarketCountdown/Variables.inc` file. See [SETUP_GUIDE.md](SETUP_GUIDE.md) for options.

### Q: Can I add custom icons?
**A:** Yes! Replace PNG files in the `Icons/` folders. See [SETUP_GUIDE.md](SETUP_GUIDE.md) for details.

### Q: What if something goes wrong?
**A:** See [INSTALLATION.md](INSTALLATION.md) troubleshooting section.

### Q: Is this the same as the original app?
**A:** Similar, but for the taskbar. Original was a standalone Windows app. This runs inside Droptop. See [README.md](README.md) for comparison.

### Q: Can I contribute or modify it?
**A:** Yes! See [DEVELOPER_GUIDE.md](DEVELOPER_GUIDE.md) for technical details.

---

## 🎯 What This App Does

Displays forex market status in your Windows taskbar:
- ✅ Shows if each market is OPEN or CLOSED
- ✅ Displays current time in each market timezone
- ✅ Counts down to market open
- ✅ Shows time since market opened
- ✅ Displays progress through session
- ✅ Works for: London, New York, Sydney, Tokyo

---

## 📱 Where to Get Help

### Installation Issues?
1. Check [INSTALLATION.md](INSTALLATION.md) troubleshooting
2. Verify folder location is correct
3. Restart Droptop completely

### Customization Questions?
1. Read [SETUP_GUIDE.md](SETUP_GUIDE.md)
2. Check [MarketCountdown/README.md](MarketCountdown/README.md)
3. Look at Variables.inc comments

### Technical Questions?
1. Read [DEVELOPER_GUIDE.md](DEVELOPER_GUIDE.md)
2. Check Lua script comments
3. Review INI file structure

### Still Stuck?
- **Droptop Discord**: https://discord.gg/droptop
- **Rainmeter Forum**: https://forum.rainmeter.net
- **Original App**: https://github.com/diegodinero/MarketCountdownStandalone

---

## ✅ Next Steps

1. **Read** [QUICK_START.txt](QUICK_START.txt) (5 minutes)
2. **Follow** [INSTALLATION.md](INSTALLATION.md) (10 minutes)
3. **Customize** [SETUP_GUIDE.md](SETUP_GUIDE.md) (optional)
4. **Enjoy!** Market monitoring in your taskbar 🚀

---

## 🎉 Ready?

👉 **Start with**: [QUICK_START.txt](QUICK_START.txt)

Or jump to:
- 🚀 **Installation**: [INSTALLATION.md](INSTALLATION.md)
- ⚙️ **Configuration**: [SETUP_GUIDE.md](SETUP_GUIDE.md)
- 📚 **Full Docs**: [README.md](README.md)

---

**Version**: 1.0 | **Status**: Ready to Use  
**Support**: Check documentation files above | **Discord**: https://discord.gg/droptop

Happy market monitoring! 📈
