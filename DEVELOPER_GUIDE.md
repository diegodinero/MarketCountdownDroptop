# Developer Guide - Market Countdown Droptop App

This guide is for developers who want to understand, modify, or extend the Market Countdown app.

## 📚 Architecture Overview

### Technology Stack

```
├─ Rainmeter (core framework)
│  ├─ INI files (configuration & UI definition)
│  ├─ INC files (@Include for shared config)
│  └─ Lua scripts (business logic)
├─ Droptop (UI overlay framework)
│  └─ Plugin for Rainmeter
└─ Windows API (timezone/time handling)
```

### File Hierarchy

```
MarketCountdown/
├── CustomApp.ini              # Main entry point for Droptop
├── MainConfig.inc             # Shared menu configuration
├── VariablesDefault.inc       # Default variables (don't edit)
├── Variables.inc              # User settings (editable)
├── VariablesData.inc          # Runtime data (auto-generated)
├── Folder/
│   ├── Folder1.ini            # London market config
│   ├── Folder2.ini            # New York market config
│   ├── Folder3.ini            # Sydney market config
│   ├── Folder4.ini            # Tokyo market config
│   ├── FolderConfig.inc       # Shared submenu config
│   └── Icons/                 # Submenu icons
└── @Resources/
    └── Scripts/
        ├── MarketStatus.lua   # Market status logic
        ├── MarketDisplay.lua  # Countdown/elapsed logic
        └── MarketProgress.lua # Progress % logic
```

## 🔧 Understanding INI Files

### INI File Structure

```ini
[Section1]
Key1=Value1
Key2=Value2

[Section2]
Key3=Value3
```

### Common Rainmeter Sections

| Section | Purpose |
|---------|---------|
| `[Rainmeter]` | Global app settings |
| `[Variables]` | Define variables |
| `[Measure*]` | Data retrieval/calculation |
| `[Meter*]` | Visual display elements |

### Measure Types

| Type | Purpose | Example |
|------|---------|---------|
| `Time` | Get current time | Market current time |
| `Script` | Run Lua code | Market calculations |
| `String` | Static text | Display text |
| `Plugin` | Rainmeter plugins | Advanced features |

## 📝 Adding a New Market

To add a 5th market (e.g., Dubai):

### Step 1: Update MainConfig.inc

```ini
#NumberOfItems#=5
ItemIsFolder5=1
ItemName5=Dubai
ItemCommand5=[]
ItemParam5=
```

### Step 2: Create Folder5.ini

Copy `Folder/Folder1.ini` and modify for Dubai:

```ini
[MeasureDubaiTime]
Measure=Time
TimeZone=Middle East Standard Time  ; Dubai timezone
Format=%H:%M
UpdateDivider=1

[MeasureDubaiStatus]
Measure=Script
ScriptFile=#@#Scripts/MarketStatus.lua
MarketName=Dubai
MarketTimeZone=Middle East Standard Time
MarketOpen1=08:00
MarketClose1=16:00
UpdateDivider=1

; ... repeat for Display and Progress measures ...

#NumberOfItems#=5
ItemName1=Status: [MeasureDubaiStatus]
ItemName2=Time: [MeasureDubaiTime]
; ... etc ...
```

### Step 3: Add Icons

Create Dubai icons:
- `Icons/5/1Icon.png` through `5Icon.png`

### Step 4: Test

1. Reload Rainmeter
2. Verify Dubai appears in menu
3. Click to expand and verify data displays correctly

## 🐍 Understanding Lua Scripts

### Script Structure

```lua
-- This function is called when Rainmeter updates the measure
function Update()
    local marketName = SELF:GetOption('MarketName', 'London')
    local open1 = SELF:GetOption('MarketOpen1', '08:00')
    
    -- Perform calculations
    local result = DoSomething(marketName, open1)
    
    -- Return string to display
    return result
end

-- Optional: Called when script initializes
function Initialize()
    -- Setup code
end
```

### Rainmeter Lua API

```lua
-- Get measure options
value = SELF:GetOption('OptionName', 'defaultValue')

-- Log to Rainmeter
SELF:LogNotice('Message')
SELF:LogWarning('Warning message')
SELF:LogError('Error message')

-- Execute bangs (Rainmeter commands)
SELF:Bang('!RefreshApp')
```

### Current Lua Scripts

#### MarketStatus.lua
**Purpose**: Determine if market is OPEN or CLOSED

**Input**: Market hours (open1, close1, open2, close2)

**Logic**:
1. Get current time in market timezone
2. Parse time strings (HH:MM)
3. Check if current time falls within market hours
4. Return "OPEN" or "CLOSED"

**Limitations**:
- Uses simplified time calculation (doesn't handle timezone offsets perfectly)
- Doesn't account for market holidays
- Monday-Friday assumption

#### MarketDisplay.lua
**Purpose**: Show countdown or elapsed time

**Format**:
- `-HH:MM` = time until market opens
- `+HH:MM` = time since market opened

**Logic**:
1. Get current time
2. If market is open: calculate elapsed time
3. If market is closed: calculate time to next open
4. Format as +/- HH:MM

#### MarketProgress.lua
**Purpose**: Calculate session progress as percentage

**Output**: 0-100 representing progress through session

**Logic**:
1. Get current session duration
2. Get elapsed time in session
3. Calculate percentage (elapsed / total * 100)
4. Clamp to 0-100%

## 🎨 Customization Points

### Adding Features

#### Option 1: Add New Market
Follow the "Adding a New Market" section above.

#### Option 2: Add New Filter Type
1. Add variable in `Variables.inc`:
   ```ini
   ShowNewFeature=1
   ```
2. Update filter logic in submenu INI files
3. Implement filtering in Lua scripts if needed

#### Option 3: Add Sound/Alert
1. Add audio file to `@Resources/`
2. Reference in Lua script:
   ```lua
   os.execute('powershell -c (New-Object Media.SoundPlayer \"path\\to\\sound.wav\").PlaySync()')
   ```

### Modifying Appearance

#### Change Colors
Edit `VariablesDefault.inc`:
```ini
[Variables]
ColorBackground=40,40,40,200
ColorText=255,255,255,255
```

#### Change Fonts
Edit `MainConfig.inc` or `FolderConfig.inc`:
```ini
FontName=Arial
FontSize=12
FontColor=255,255,255
```

#### Change Layout
Modify meter positions in INI files:
```ini
[MeterItem1]
X=10          ; Horizontal position
Y=10          ; Vertical position
W=280         ; Width
H=30          ; Height
```

## 🧪 Testing & Debugging

### Enable Debug Logging

Add to any INI file:
```ini
[Rainmeter]
Debug=1
```

### View Rainmeter Log

```
Right-click Rainmeter → Open Log
```

### Test Lua Scripts

In Rainmeter console:
```lua
print(tostring(value))
```

### Common Issues

| Problem | Solution |
|---------|----------|
| Measure not updating | Check `UpdateDivider` value |
| Lua script error | Check Rainmeter log for error message |
| Variables not changing | Check if Variables.inc is @Included |
| Icon not showing | Verify PNG is 32x32 and white color |

## 📊 Data Flow Example

Here's what happens when you click a market:

```
1. Click "London" in Droptop bar
   ↓
2. Rainmeter loads Folder1.ini
   ↓
3. Measures in Folder1.ini execute:
   - MeasureLondonTime (runs Time measure) → "13:45"
   - MeasureLondonStatus (runs MarketStatus.lua) → "OPEN"
   - MeasureLondonDisplay (runs MarketDisplay.lua) → "+05:30"
   - MeasureLondonProgress (runs MarketProgress.lua) → "65"
   ↓
4. Rainmeter renders meters (String displays)
   ↓
5. Droptop displays dropdown menu with:
   - Status: OPEN
   - Time: 13:45
   - Hours: 08:00–17:00
   - Next Open: +05:30
   - Progress: 65%
```

## 🔗 API References

### Rainmeter
- [Rainmeter Docs](https://docs.rainmeter.net)
- [Measures](https://docs.rainmeter.net/manual/measures/)
- [Meters](https://docs.rainmeter.net/manual/meters/)
- [Lua API](https://docs.rainmeter.net/manual/lua-scripting/)

### Droptop
- [Droptop Docs](https://docs.droptopfour.com)
- [Community Apps](https://docs.droptopfour.com/community-apps/)

### Windows Timezones
- [TimeZoneInfo Class](https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo)
- [Windows Timezone IDs](https://support.microsoft.com/en-us/help/973627)

## 🚀 Advanced Customization

### Adding Economic Calendar Integration

1. Fetch events from API (requires plugin or external script)
2. Parse economic events
3. Store in VariablesData.inc
4. Display in new submenu

Example structure:
```
Folder5.ini - Economic Calendar submenu
├── Event1: USD CPI (12:30 EST)
├── Event2: EUR Unemployment (10:00 GMT)
└── Event3: JPY Trade Balance (08:30 JST)
```

### Adding Custom Alerts

1. Create alert script in `@Resources/Scripts/Alerts.lua`
2. Check for market open/close events
3. Execute notification or sound
4. Store alert state in Variables.inc

### Adding Settings UI

Droptop can display a settings menu through context menus:

```ini
[Rainmeter]
ContextTitle=Market Countdown Settings
ContextAction=[!CommandMeasure MeasureSettings "OpenSettings"]
```

## 🔐 Best Practices

### Performance
- Use appropriate `UpdateDivider` values (1-60 seconds)
- Avoid heavy calculations in frequently-called measures
- Cache results when possible

### Maintainability
- Use descriptive variable names
- Add comments in complex Lua scripts
- Keep INI files organized

### Compatibility
- Test with Rainmeter 4.3+
- Support Windows 7 SP1+
- Avoid platform-specific features

## 📦 Packaging & Distribution

### Before Release
1. Test all features thoroughly
2. Verify all files are included
3. Update version number
4. Test installation in fresh environment

### File Checklist
- [ ] All .ini files
- [ ] All .inc files
- [ ] All .lua scripts
- [ ] All icon files (or placeholder instructions)
- [ ] All documentation files
- [ ] No temporary or debug files

### Documentation Checklist
- [ ] README.md updated
- [ ] SETUP_GUIDE.md comprehensive
- [ ] INSTALLATION.md detailed
- [ ] Version number consistent

## 🤝 Contributing

1. Fork repository
2. Create feature branch
3. Make changes with comments
4. Test thoroughly
5. Update documentation
6. Submit pull request

## 📞 Support

- **Issues**: Check existing GitHub issues
- **Questions**: Ask in Droptop Discord
- **Bug Reports**: Include Rainmeter log output

---

**Version**: 1.0  
**Last Updated**: November 3, 2026
