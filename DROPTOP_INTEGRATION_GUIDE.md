# Droptop Integration Guide for Market Countdown Plugin

## Overview

Droptop Four is a Windows taskbar overlay system based on Rainmeter. While our C# application is a standalone desktop app (not a Rainmeter skin), there are several ways to integrate it with Droptop.

---

## Integration Options

### Option 1: Droptop Menu Item (Recommended)

**How it works:** Add a custom menu item to your Droptop menu that launches the Market Countdown app.

**Steps:**

1. **Build the executable:**
   ```bash
   cd CSharp
   dotnet publish -c Release -f net8.0-windows --self-contained -p:PublishSingleFile=true
   ```

2. **Copy the executable:**
   - Copy `bin/Release/net8.0-windows/publish/MarketCountdownPlugin.exe`
   - To a permanent location, e.g., `C:\Program Files\MarketCountdownPlugin\`

3. **Create menu configuration:**
   - Find your Droptop installation folder (typically `C:\Program Files (x86)\Droptop\`)
   - Locate the `Profiles` folder in your Droptop directory
   - Create a custom menu file that references your app

4. **Add to Droptop menu:**
   - In Droptop settings, find "Custom Apps" or "Community Apps"
   - Add new app entry pointing to your executable
   - Configure launch options (window mode, arguments, etc.)

**Example Menu Configuration:**
```ini
[Market Countdown]
OnLeftClick=!Execute "C:\Program Files\MarketCountdownPlugin\MarketCountdownPlugin.exe"
Icon=MarketCountdownPlugin.ico
Text=Market Countdown
```

---

### Option 2: Taskbar Shortcut

**How it works:** Create a Windows shortcut on the taskbar that launches the app directly.

**Steps:**

1. **Create a shortcut:**
   - Right-click desktop → New → Shortcut
   - Target: `C:\Program Files\MarketCountdownPlugin\MarketCountdownPlugin.exe`
   - Name: "Market Countdown"

2. **Pin to taskbar:**
   - Right-click the shortcut → Pin to taskbar
   - Customize icon if desired

3. **Run on startup (optional):**
   - Place shortcut in: `C:\Users\[YourUsername]\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup`

---

### Option 3: Windows Task Scheduler

**How it works:** Auto-launch the app at system startup or on a schedule.

**Steps:**

1. **Open Task Scheduler:**
   - Press `Win + R`, type `taskschd.msc`, press Enter

2. **Create Basic Task:**
   - Name: "Market Countdown"
   - Trigger: "At startup"
   - Action: Start a program
   - Program/script: `C:\Program Files\MarketCountdownPlugin\MarketCountdownPlugin.exe`

3. **Configure:**
   - Set to run with highest privileges
   - Configure repeat interval if needed

---

### Option 4: Droptop Launcher Integration

**How it works:** Modify Droptop to recognize and launch your app through its launcher system.

**Requirements:**
- Droptop Four installed
- Knowledge of Droptop's plugin architecture

**Steps:**

1. **Locate Droptop plugins folder:**
   ```
   C:\Program Files (x86)\Droptop\Apps\
   ```

2. **Create app folder:**
   ```
   C:\Program Files (x86)\Droptop\Apps\MarketCountdown\
   ```

3. **Add app files:**
   - Copy `MarketCountdownPlugin.exe` to this folder
   - Create `config.ini` with app metadata:
   ```ini
   [MarketCountdown]
   Name=Market Countdown
   Author=Your Name
   Version=1.0.0
   Description=Real-time forex market monitoring with sound alerts
   LaunchPath=MarketCountdownPlugin.exe
   Icon=icon.ico
   Categories=Finance;Tools
   ```

4. **Register with Droptop:**
   - Restart Droptop
   - App should appear in Community Apps section

---

### Option 5: System Tray Integration

**How it works:** Modify the app to minimize to system tray (Windows notification area).

**Code Changes Required:**

In `MainWindow.xaml.cs`, add:

```csharp
private void Window_StateChanged(object sender, EventArgs e)
{
    if (this.WindowState == WindowState.Minimized)
    {
        this.Hide();
        this.ShowInTaskbar = false;
    }
}

private void NotifyIcon_Click(object sender, EventArgs e)
{
    if (this.IsVisible)
    {
        this.Hide();
        this.ShowInTaskbar = false;
    }
    else
    {
        this.Show();
        this.ShowInTaskbar = true;
        this.WindowState = WindowState.Normal;
    }
}
```

In `MainWindow.xaml`, add:

```xaml
<Window ... StateChanged="Window_StateChanged">
    <Grid>
        <!-- Your existing UI -->
    </Grid>
</Window>
```

---

## Recommended Setup

**For most users, we recommend:**

### Basic Setup (5 minutes)
1. Build the app: `dotnet publish -c Release -f net8.0-windows --self-contained -p:PublishSingleFile=true`
2. Create shortcut to the .exe
3. Pin to taskbar
4. Done! Run it whenever you need forex monitoring

### Advanced Setup (with Droptop)
1. Create custom Droptop menu item
2. Configure launch options
3. Add to your Droptop profile
4. Launch from Droptop menu like other apps

---

## Droptop Compatibility

**Important Notes:**

- This C# app runs independently from Droptop
- It's NOT a Rainmeter skin
- Droptop doesn't need to be running for the app to work
- The app works as a standalone desktop application

**Window Management:**
- App creates its own window (not overlaid on taskbar)
- Can be positioned/sized like any other window
- Can be minimized/maximized normally

**Performance:**
- No Rainmeter overhead
- Native Windows desktop app performance
- Minimal CPU/memory usage
- Real audio playback (Rainmeter limitation overcome)

---

## Troubleshooting Integration

### App Won't Launch from Droptop
1. Verify executable path is correct
2. Check file permissions (might need Admin)
3. Ensure .NET 8.0 runtime installed
4. Test launching .exe directly first

### Multiple Instances
- By default, multiple windows can open
- To limit to 1 instance, modify `App.xaml.cs`:
```csharp
if (Process.GetProcessesByName("MarketCountdownPlugin").Length > 1)
{
    MessageBox.Show("Application already running!");
    Environment.Exit(0);
}
```

### Taskbar Icon Issues
- Right-click app → Pin to taskbar
- Customize icon in shortcut properties
- Use custom .ico file for app icon

### Memory/CPU Issues
- Close unnecessary background apps
- Reduce event update frequency (change timer interval in ViewModel)
- Disable sound alerts if not needed
- Filter to fewer currencies

---

## Advanced Customization

### Custom App Icon
1. Create icon file: `icon.ico` (256x256 recommended)
2. Place in app directory
3. Update .csproj:
```xml
<PropertyGroup>
  <ApplicationIcon>icon.ico</ApplicationIcon>
</PropertyGroup>
```

### Auto-Launch at Startup
**Option A (Shortcut method):**
- Place shortcut in `Startup` folder (see Option 3 above)

**Option B (Registry):**
- Create registry entry: `HKCU\Software\Microsoft\Windows\CurrentVersion\Run`
- Add key: `MarketCountdown` = `C:\Program Files\MarketCountdownPlugin\MarketCountdownPlugin.exe`

**Option C (Task Scheduler):**
- See Option 3 above

### Custom Launch Arguments
Future enhancement to add command-line arguments:
```csharp
// In App.xaml.cs OnStartup:
string[] args = Environment.GetCommandLineArgs();
if (args.Contains("--minimize"))
    MainWindow.WindowState = WindowState.Minimized;
if (args.Contains("--dark"))
    ViewModel.IsDarkMode = true;
```

Then launch as: `MarketCountdownPlugin.exe --minimize --dark`

---

## Step-by-Step: Quick Integration

### 1. Build
```bash
cd CSharp
dotnet publish -c Release -f net8.0-windows --self-contained -p:PublishSingleFile=true
```

### 2. Install
```powershell
# Create program folder
mkdir "C:\Program Files\MarketCountdownPlugin"

# Copy executable
copy "bin\Release\net8.0-windows\publish\MarketCountdownPlugin.exe" "C:\Program Files\MarketCountdownPlugin\"
```

### 3. Create Shortcut
- Right-click desktop → New → Shortcut
- Location: `C:\Program Files\MarketCountdownPlugin\MarketCountdownPlugin.exe`
- Name: `Market Countdown`
- Click Finish

### 4. Pin to Taskbar (Optional)
- Right-click shortcut → Pin to taskbar

### 5. Run!
- Click taskbar icon to launch
- App opens as normal Windows desktop window

---

## Droptop Menu Integration (Advanced)

If you want to add it to your Droptop menu alongside other apps:

1. **Find Droptop folder:**
   - Default: `C:\Program Files (x86)\Droptop\`

2. **Create app folder:**
   ```
   C:\Program Files (x86)\Droptop\Apps\MarketCountdown
   ```

3. **Add files:**
   - `MarketCountdownPlugin.exe` (from published build)
   - `manifest.ini` (see below)

4. **Create manifest.ini:**
   ```ini
   [MarketCountdown]
   Name=Market Countdown
   Description=Real-time forex market monitoring with sound alerts
   Version=1.0.0
   Author=Your Name
   RunOnLoad=0
   LaunchApp=MarketCountdownPlugin.exe
   AppPath=.
   Icon=icon.ico
   ```

5. **Restart Droptop**
   - Right-click Droptop menu
   - Select "Community Apps" or "Refresh Apps"
   - Market Countdown should appear

---

## FAQ

**Q: Will this work without Droptop installed?**  
A: Yes! This is a standalone Windows app. Droptop is completely optional.

**Q: Can I run multiple instances?**  
A: Yes, by default. Modify App.xaml.cs if you want to limit to 1.

**Q: Does the app require admin privileges?**  
A: No, but Task Scheduler might prompt for elevated permissions.

**Q: Can I use this on a Mac/Linux?**  
A: Not directly. Requires Windows. Could port to Avalonia for cross-platform support (future enhancement).

**Q: What's the minimum Windows version?**  
A: Windows 7 SP1 or later.

**Q: Does the app work offline?**  
A: Markets display offline. Events require internet for Forex Factory API.

**Q: Can I disable sounds?**  
A: Yes, uncheck "Announcer Sounds" in the UI.

**Q: How do I update the app?**  
A: Simply replace the .exe with a newer version.

---

## Summary

**Simplest Integration:** Create Windows shortcut → Pin to taskbar → Done!

**For Droptop Users:** Add to Droptop menu via custom app entry

**Auto-Launch:** Use Windows startup folder or Task Scheduler

**System Tray:** Modify code to minimize to system tray (future enhancement)

---

**Important:** This C# application is completely independent from Droptop. Droptop is optional for launching the app. The app works perfectly as a standalone desktop application.

Choose whichever integration method best fits your workflow!
