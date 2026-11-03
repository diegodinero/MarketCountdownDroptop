using System.Windows;

namespace MarketCountdownPlugin
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Initialize with dark theme by default
        }

        public void ApplyTheme(bool isDarkMode)
        {
            var theme = isDarkMode ? "Themes/DarkTheme.xaml" : "Themes/LightTheme.xaml";
            var dict = new ResourceDictionary { Source = new System.Uri(theme, System.UriKind.Relative) };
            
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(dict);
        }
    }
}
