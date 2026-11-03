# Market Countdown Droptop App - Complete File Listing

## 📦 Package Contents

This package contains everything needed to install and use the Market Countdown Droptop application.

### Total: 26 Files | 3,137 Lines of Code/Documentation

---

## 📄 Root Directory Documentation

### README.md (7.5 KB)
**Main project documentation**
- Project overview and features
- Quick start instructions
- Comparison with original C# app
- Links to all other documentation

### INSTALLATION.md (5.3 KB)
**Installation and troubleshooting guide**
- Prerequisites checklist
- 3-step installation instructions
- Common installation issues and solutions
- Uninstallation instructions

### SETUP_GUIDE.md (8.5 KB)
**User configuration and customization guide**
- Pre-installation checklist
- First-time configuration steps
- Market hours reference
- Advanced customization options
- Troubleshooting tips

### DEVELOPER_GUIDE.md (9.7 KB)
**Technical documentation for developers**
- Architecture overview
- File structure explanation
- Understanding INI files and Lua scripts
- How to add new features
- Best practices for customization

### QUICK_START.txt (4.0 KB)
**Quick reference guide**
- Visual quick start overview
- 3-step installation
- Basic configuration
- Common troubleshooting
- Quick tips and tricks

### CHECKLIST.md (5.0 KB)
**Installation and setup verification checklist**
- Pre-installation checklist
- Installation steps
- Initial configuration
- Optional customization
- Verification tests

### SUMMARY.md (8.8 KB)
**Project completion and overview summary**
- Project overview
- Deliverables list
- Features implemented
- Technical architecture
- Project statistics
- Completion status

### FILES_INCLUDED.md
**This file - complete package listing**

---

## 🎯 Main App Directory: MarketCountdown/

### Configuration Files

#### CustomApp.ini (1.6 KB)
**Main application configuration**
- Rainmeter global settings
- Market measures (London, New York, Sydney, Tokyo)
- Time display setup
- UI element definitions
- Entry point for Droptop

#### MainConfig.inc (2.0 KB)
**Shared main menu configuration**
- Number of dropdown items
- Item names (London, New York, Sydney, Tokyo, Settings)
- Menu appearance settings
- Item folder mapping
- Font and styling definitions

#### VariablesDefault.inc (0.5 KB)
**Default configuration variables**
- Currency filters (AUD, CAD, CHF, CNY, EUR, GBP, JPY, NZD, USD)
- Impact level filters
- Display settings
- Color definitions
- **Note**: Users should NOT edit this file

#### Variables.inc (0.5 KB)
**User-editable persistent variables**
- Currency preferences
- Theme selection
- Time format preference
- Feature toggles
- Sound settings
- **Note**: Users SHOULD edit this file to customize

#### VariablesData.inc (0.7 KB)
**Runtime data variables**
- Current market status
- Market times
- Display values
- Hours information
- Upcoming events data
- **Note**: Auto-updated by measures

### Documentation

#### README.md (6.4 KB)
**App-specific documentation**
- Feature overview
- Installation instructions (brief)
- App structure explanation
- Configuration guide
- Market hours reference
- Troubleshooting
- Credits

---

## 📂 Folder/ Submenu Directory

### Market Submenu Files

#### Folder/Folder1.ini (1.5 KB)
**London market submenu configuration**
- Time measure for London (GMT)
- Status measure (OPEN/CLOSED logic)
- Display measure (countdown/elapsed)
- Progress measure (session %)
- Menu items display

#### Folder/Folder2.ini (1.5 KB)
**New York market submenu configuration**
- Time measure for New York (EST)
- Status, display, and progress measures
- Same structure as Folder1.ini

#### Folder/Folder3.ini (1.5 KB)
**Sydney market submenu configuration**
- Time measure for Sydney (AEDT)
- Status, display, and progress measures
- Same structure as Folder1.ini

#### Folder/Folder4.ini (1.6 KB)
**Tokyo market submenu configuration**
- Time measure for Tokyo (JST)
- Includes lunch break support
- Status, display, and progress measures
- Session 1: 09:00–11:30
- Session 2: 12:30–15:30

#### Folder/FolderConfig.inc (1.3 KB)
**Shared submenu configuration**
- Common menu styling
- String meter definitions
- Item display formatting
- Font and color settings
- Background styling

### Submenu Icons

#### Folder/Icons/1/ (placeholder)
**London market submenu icons**
- 1Icon.png through 5Icon.png (user-replaceable)
- Contains ICON_PLACEHOLDER.txt with instructions

#### Folder/Icons/2/ (placeholder)
**New York market submenu icons**
- 1Icon.png through 5Icon.png (user-replaceable)
- Contains ICON_PLACEHOLDER.txt with instructions

#### Folder/Icons/3/ (placeholder)
**Sydney market submenu icons**
- 1Icon.png through 5Icon.png (user-replaceable)
- Contains ICON_PLACEHOLDER.txt with instructions

#### Folder/Icons/4/ (placeholder)
**Tokyo market submenu icons**
- 1Icon.png through 5Icon.png (user-replaceable)
- Contains ICON_PLACEHOLDER.txt with instructions

---

## 🛠️ @Resources/Scripts/ Lua Scripts

### MarketStatus.lua (1.4 KB)
**Market open/closed status determination**
- Takes market name and hours as input
- Parses time strings (HH:MM format)
- Compares current time to market hours
- Supports single and dual sessions
- Returns: "OPEN" or "CLOSED"

### MarketDisplay.lua (2.5 KB)
**Countdown and elapsed time calculation**
- Shows `-HH:MM` when market is closed (time until open)
- Shows `+HH:MM` when market is open (time since open)
- Handles lunch breaks and dual sessions
- Calculates time to next market opening
- Returns: Formatted time string with +/- indicator

### MarketProgress.lua (2.4 KB)
**Session progress percentage calculation**
- Calculates elapsed time in current session
- Divides elapsed by total session duration
- Returns percentage as 0-100
- Handles dual sessions
- Clamps value between 0 and 100

---

## 🎨 Icons Directory

### Icons/ Main Menu
**Main application icons in Droptop bar**
- Location: `MarketCountdown/Icons/`
- Contains: 1Icon.png through 4Icon.png (user-replaceable)
- Also contains: ICON_PLACEHOLDER.txt with instructions

### Icon Specifications
- **Size**: 32x32 pixels
- **Format**: PNG with alpha transparency
- **Color**: White (#FFFFFF, RGB 255,255,255)
- **Recommended sources**: Flaticon.com, or create your own

---

## 📊 File Statistics

### By Type
| Type | Count | Total Size |
|------|-------|-----------|
| INI files | 5 | ~7 KB |
| INC files | 4 | ~5 KB |
| Lua scripts | 3 | ~6 KB |
| Markdown docs | 8 | ~50 KB |
| Text files | 1 | ~4 KB |
| Icon placeholders | 5 | <1 KB |
| **TOTAL** | **26** | **~73 KB** |

### By Directory
| Directory | Files | Purpose |
|-----------|-------|---------|
| Root | 8 | Documentation |
| MarketCountdown/ | 10 | Main app config |
| Folder/ | 5 | Submenu configs |
| Folder/Icons/ | 4 | Icon directories |
| @Resources/Scripts/ | 3 | Lua logic |
| Icons/ | 1 | Main icons |

### Lines of Code/Documentation
| Category | Lines |
|----------|-------|
| Configuration (INI/INC) | ~400 |
| Lua scripts | ~900 |
| Documentation (Markdown) | ~1800 |
| Total | ~3,137 |

---

## 🔍 File Dependencies

```
CustomApp.ini (main entry)
├── Rainmeter system
├── VariablesDefault.inc
├── Variables.inc
├── VariablesData.inc
├── MainConfig.inc
│   └── Folder/FolderConfig.inc
└── @Resources/Scripts/
    ├── MarketStatus.lua
    ├── MarketDisplay.lua
    └── MarketProgress.lua

Folder/Folder[1-4].ini
├── VariablesDefault.inc
├── Variables.inc
├── VariablesData.inc
├── FolderConfig.inc
└── @Resources/Scripts/
    ├── MarketStatus.lua
    ├── MarketDisplay.lua
    └── MarketProgress.lua
```

---

## 📥 Installation Files

All files should be copied to:
```
C:\Program Files\Droptop Four\@Resources\GlobalSettings\0_Community\CommunityApps\MarketCountdown\
```

### Critical Files (MUST be included)
- ✓ CustomApp.ini
- ✓ MainConfig.inc
- ✓ Variables.inc (user settings)
- ✓ VariablesDefault.inc (defaults)
- ✓ VariablesData.inc (runtime data)
- ✓ Folder/Folder[1-4].ini (market configs)
- ✓ Folder/FolderConfig.inc
- ✓ @Resources/Scripts/*.lua (all 3 scripts)

### Optional Files
- ✓ Icons (can replace with custom)
- ✓ README.md (app documentation)

### Documentation (Helpful but not required for app to run)
- README.md (root level)
- INSTALLATION.md
- SETUP_GUIDE.md
- DEVELOPER_GUIDE.md
- QUICK_START.txt
- CHECKLIST.md
- SUMMARY.md
- FILES_INCLUDED.md

---

## ✅ File Verification Checklist

Before installation, verify these files exist:

### Configuration Files
- [ ] CustomApp.ini
- [ ] MainConfig.inc
- [ ] Variables.inc
- [ ] VariablesDefault.inc
- [ ] VariablesData.inc
- [ ] Folder/Folder1.ini
- [ ] Folder/Folder2.ini
- [ ] Folder/Folder3.ini
- [ ] Folder/Folder4.ini
- [ ] Folder/FolderConfig.inc

### Script Files
- [ ] @Resources/Scripts/MarketStatus.lua
- [ ] @Resources/Scripts/MarketDisplay.lua
- [ ] @Resources/Scripts/MarketProgress.lua

### Icon Directories
- [ ] Icons/ (main menu icons)
- [ ] Folder/Icons/1/ (London submenu icons)
- [ ] Folder/Icons/2/ (New York submenu icons)
- [ ] Folder/Icons/3/ (Sydney submenu icons)
- [ ] Folder/Icons/4/ (Tokyo submenu icons)

### Documentation
- [ ] README.md (root)
- [ ] INSTALLATION.md
- [ ] SETUP_GUIDE.md
- [ ] DEVELOPER_GUIDE.md
- [ ] QUICK_START.txt
- [ ] CHECKLIST.md
- [ ] SUMMARY.md
- [ ] FILES_INCLUDED.md

---

## 🚀 Next Steps

1. **Extract** all files maintaining folder structure
2. **Copy** MarketCountdown folder to Community Apps directory
3. **Restart** Droptop
4. **Enable** app in Droptop settings
5. **Read** QUICK_START.txt for quick overview
6. **Consult** SETUP_GUIDE.md for customization

---

**Package Version**: 1.0  
**Last Updated**: November 3, 2026  
**Total Files**: 26  
**Total Size**: ~73 KB (excluding custom icons)
