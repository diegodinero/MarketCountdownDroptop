@echo off
REM Market Countdown Plugin - Build and Install Script
REM This script builds the app and optionally installs it

echo.
echo ╔════════════════════════════════════════════════════════════════╗
echo ║    Market Countdown Plugin - Build and Install                 ║
echo ╚════════════════════════════════════════════════════════════════╝
echo.

REM Check if .NET SDK is installed
dotnet --version >nul 2>&1
if errorlevel 1 (
    echo ❌ ERROR: .NET SDK is not installed!
    echo Please download and install .NET 8.0 from:
    echo https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo ✓ .NET SDK found
echo.

REM Build the application
echo Building application...
dotnet build -c Release
if errorlevel 1 (
    echo ❌ Build failed!
    pause
    exit /b 1
)

echo ✓ Build complete
echo.

REM Publish standalone executable
echo Publishing standalone executable...
dotnet publish -c Release -f net8.0-windows --self-contained -p:PublishSingleFile=true
if errorlevel 1 (
    echo ❌ Publish failed!
    pause
    exit /b 1
)

echo ✓ Publish complete
echo.

REM Executable location
set EXE_PATH=%cd%\bin\Release\net8.0-windows\publish\MarketCountdownPlugin.exe

echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
echo ✅ BUILD SUCCESSFUL!
echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
echo.
echo Executable: %EXE_PATH%
echo.

REM Ask for installation option
echo Installation options:
echo 1. Install to Program Files (requires admin)
echo 2. Create desktop shortcut only
echo 3. Skip installation (just built)
echo.

set /p OPTION="Choose option (1-3): "

if "%OPTION%"=="1" (
    echo.
    echo Installing to Program Files...
    mkdir "C:\Program Files\MarketCountdownPlugin" 2>nul
    copy "%EXE_PATH%" "C:\Program Files\MarketCountdownPlugin\" >nul
    if errorlevel 1 (
        echo ❌ Installation failed. You may need to run as Administrator.
        pause
        exit /b 1
    )
    echo ✓ Installed to C:\Program Files\MarketCountdownPlugin
    echo.
    echo Creating desktop shortcut...
    powershell -Command "$WshShell = New-Object -ComObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut([Environment]::GetFolderPath('Desktop') + '\Market Countdown.lnk'); $Shortcut.TargetPath = 'C:\Program Files\MarketCountdownPlugin\MarketCountdownPlugin.exe'; $Shortcut.Save()"
    echo ✓ Desktop shortcut created
) else if "%OPTION%"=="2" (
    echo.
    echo Creating desktop shortcut...
    powershell -Command "$WshShell = New-Object -ComObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut([Environment]::GetFolderPath('Desktop') + '\Market Countdown.lnk'); $Shortcut.TargetPath = '%EXE_PATH%'; $Shortcut.Save()"
    echo ✓ Desktop shortcut created pointing to: %EXE_PATH%
)

echo.
echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
echo 🚀 READY TO LAUNCH!
echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
echo.
echo Next steps:
echo - Double-click the desktop shortcut to launch
echo - Or run: %EXE_PATH%
echo.
echo For Droptop integration, see: DROPTOP_INTEGRATION_GUIDE.md
echo.
pause
