using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Media;
using System.IO;
using System.Collections.Generic;

namespace MarketCountdownPlugin
{
    /// <summary>
    /// Main ViewModel - Complete port of MarketCountdownStandalone C# WPF app
    /// Includes all features: markets, events, sounds, currency filtering, theme toggle
    /// </summary>
    public class MarketCountdownViewModel : INotifyPropertyChanged
    {
        private static readonly string[] ImpactOrder = { "High", "Medium", "Low", "Holiday" };
        public MarketCountdownCoreVM MarketVM { get; } = new MarketCountdownCoreVM();

        public ObservableCollection<ForexEvent> UpcomingEvents { get; }
            = new ObservableCollection<ForexEvent>();

        // ==== CURRENCY FILTERS ====
        private bool _showUSD = true;
        private bool _showEUR = true;
        private bool _showGBP = true;
        private bool _showCAD = true;
        private bool _showCHF = true;
        private bool _showAUD = true;
        private bool _showCNY = true;
        private bool _showNZD = true;
        private bool _showJPY = true;

        public bool ShowUSD
        {
            get => _showUSD;
            set { if (SetProperty(ref _showUSD, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }
        public bool ShowEUR
        {
            get => _showEUR;
            set { if (SetProperty(ref _showEUR, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }
        public bool ShowGBP
        {
            get => _showGBP;
            set { if (SetProperty(ref _showGBP, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }
        public bool ShowCAD
        {
            get => _showCAD;
            set { if (SetProperty(ref _showCAD, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }
        public bool ShowCHF
        {
            get => _showCHF;
            set { if (SetProperty(ref _showCHF, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }
        public bool ShowAUD
        {
            get => _showAUD;
            set { if (SetProperty(ref _showAUD, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }
        public bool ShowCNY
        {
            get => _showCNY;
            set { if (SetProperty(ref _showCNY, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }
        public bool ShowNZD
        {
            get => _showNZD;
            set { if (SetProperty(ref _showNZD, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }
        public bool ShowJPY
        {
            get => _showJPY;
            set { if (SetProperty(ref _showJPY, value)) { RefreshNextEvent(); ClearPlayedSoundsForHiddenCurrencies(); } }
        }

        private bool IsCurrencyVisible(string c) => c switch
        {
            "USD" => ShowUSD, "EUR" => ShowEUR, "GBP" => ShowGBP, "CAD" => ShowCAD,
            "CHF" => ShowCHF, "AUD" => ShowAUD, "CNY" => ShowCNY, "NZD" => ShowNZD,
            "JPY" => ShowJPY, _ => false
        };

        // ==== IMPACT FILTERS ====
        private bool _showHighImpact = true;
        private bool _showMediumImpact = true;
        private bool _showLowImpact = true;
        private bool _showHolidayImpact = true;

        public bool ShowHighImpact
        {
            get => _showHighImpact;
            set { if (SetProperty(ref _showHighImpact, value)) RefreshNextEvent(); }
        }
        public bool ShowMediumImpact
        {
            get => _showMediumImpact;
            set { if (SetProperty(ref _showMediumImpact, value)) RefreshNextEvent(); }
        }
        public bool ShowLowImpact
        {
            get => _showLowImpact;
            set { if (SetProperty(ref _showLowImpact, value)) RefreshNextEvent(); }
        }
        public bool ShowHolidayImpact
        {
            get => _showHolidayImpact;
            set { if (SetProperty(ref _showHolidayImpact, value)) RefreshNextEvent(); }
        }

        private bool IsImpactVisible(string impact) => impact switch
        {
            "High" => ShowHighImpact, "Medium" => ShowMediumImpact, "Low" => ShowLowImpact,
            "Holiday" => ShowHolidayImpact, _ => false
        };

        // ==== THEME & DISPLAY ====
        private bool _isDarkMode = true;
        public bool IsDarkMode
        {
            get => _isDarkMode;
            set { if (SetProperty(ref _isDarkMode, value)) { } }
        }

        private bool _use24Hour = true;
        public bool Use24Hour
        {
            get => _use24Hour;
            set
            {
                if (SetProperty(ref _use24Hour, value))
                {
                    MarketVM.Use24Hour = value;
                    RefreshEventTimeStrings();
                    RefreshNextEvent();
                }
            }
        }

        private bool _announcerSoundsEnabled = true;
        public bool AnnouncerSoundsEnabled
        {
            get => _announcerSoundsEnabled;
            set { SetProperty(ref _announcerSoundsEnabled, value); }
        }

        private bool _showNextEventToggle = true;
        public bool ShowNextEventToggle
        {
            get => _showNextEventToggle;
            set { SetProperty(ref _showNextEventToggle, value); }
        }

        // ==== SOUND SYSTEM ====
        private Dictionary<string, HashSet<int>> _playedSounds = new Dictionary<string, HashSet<int>>();
        private SoundPlayer _currentPlayer;

        private const double FIVE_MINUTE_THRESHOLD = 5.0;
        private const double FIVE_MINUTE_WINDOW = 4.916;
        private const double TWO_MINUTE_THRESHOLD = 2.0;
        private const double TWO_MINUTE_WINDOW = 1.916;

        public string TodayDate => DateTime.Now.ToString("d MMM");

        // ==== NEXT EVENT ====
        public ForexEvent NextEvent
        {
            get
            {
                var now = DateTime.Now;
                var future = UpcomingEvents.Where(e =>
                    e.Occurrence >= now && IsCurrencyVisible(e.Currency) && IsImpactVisible(e.Impact)).ToList();

                if (!future.Any()) return null;

                var nextTime = future.Min(e => e.Occurrence);
                return future.Where(e => e.Occurrence == nextTime)
                    .OrderBy(e => Array.IndexOf(ImpactOrder, e.Impact))
                    .First();
            }
        }

        public string NextEventText => NextEvent != null
            ? $"{NextEvent.Currency} — {NextEvent.Title}"
            : "No upcoming event";

        public string NextEventCountdown
        {
            get
            {
                if (NextEvent == null) return "";
                var span = NextEvent.Occurrence - DateTime.Now;
                if (span <= TimeSpan.Zero) return "00:00:00";
                return $"{(int)span.TotalHours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
            }
        }

        private const string XmlFeedUrl = "https://nfs.faireconomy.media/ff_calendar_thisweek.xml";
        private readonly DispatcherTimer _timer;
        private DispatcherTimer _countdownTimer;

        public MarketCountdownViewModel()
        {
            MarketVM.Use24Hour = _use24Hour;
            
            // Fetch events every 5 minutes
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(5) };
            _timer.Tick += async (_, __) => await FetchEventsAsync();
            _timer.Start();

            // Update countdown every second
            _countdownTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal,
                (_, __) =>
                {
                    OnPropertyChanged(nameof(NextEvent));
                    OnPropertyChanged(nameof(NextEventText));
                    OnPropertyChanged(nameof(NextEventCountdown));
                    OnPropertyChanged(nameof(TodayDate));
                    CheckAndPlayAnnouncerSounds();
                },
                Dispatcher.CurrentDispatcher);
            _countdownTimer.Start();

            _ = FetchEventsAsync();
        }

        private string FormatEventTime(DateTime value)
            => Use24Hour ? value.ToString("HH:mm") : value.ToString("hh:mm tt");

        private void RefreshEventTimeStrings()
        {
            if (UpcomingEvents.Count == 0) return;
            var snapshot = UpcomingEvents.ToList();
            UpcomingEvents.Clear();
            foreach (var ev in snapshot)
            {
                ev.Time = FormatEventTime(ev.Occurrence);
                UpcomingEvents.Add(ev);
            }
        }

        private void RefreshNextEvent()
        {
            OnPropertyChanged(nameof(NextEvent));
            OnPropertyChanged(nameof(NextEventText));
            OnPropertyChanged(nameof(NextEventCountdown));
        }

        public void ClearPlayedSoundsForHiddenCurrencies()
        {
            var keysToRemove = _playedSounds.Keys
                .Where(k => !IsCurrencyVisible(k.Split('_')[0]))
                .ToList();

            foreach (var key in keysToRemove)
                _playedSounds.Remove(key);
        }

        private void CheckAndPlayAnnouncerSounds()
        {
            if (!AnnouncerSoundsEnabled) return;

            var now = DateTime.Now;
            var evt = NextEvent;
            if (evt == null || !IsCurrencyVisible(evt.Currency)) return;
            if (evt.Impact != "High" && evt.Impact != "Medium") return;

            var timeUntil = evt.Occurrence - now;
            string eventKey = $"{evt.Currency}_{evt.Title}_{evt.Occurrence:yyyyMMddHHmm}";

            if (!_playedSounds.ContainsKey(eventKey))
                _playedSounds[eventKey] = new HashSet<int>();

            if (timeUntil.TotalMinutes <= FIVE_MINUTE_THRESHOLD && timeUntil.TotalMinutes > FIVE_MINUTE_WINDOW && !_playedSounds[eventKey].Contains(5))
            {
                if (IsCurrencyVisible(evt.Currency))
                {
                    PlaySoundWithPreCheck("fiveminutesremaining.wav", evt.Currency, 5);
                    _playedSounds[eventKey].Add(5);
                }
            }
            else if (timeUntil.TotalMinutes <= TWO_MINUTE_THRESHOLD && timeUntil.TotalMinutes > TWO_MINUTE_WINDOW && !_playedSounds[eventKey].Contains(2))
            {
                if (IsCurrencyVisible(evt.Currency))
                {
                    PlaySoundWithPreCheck("undertaker.wav", evt.Currency, 2);
                    _playedSounds[eventKey].Add(2);
                }
            }
            else if (timeUntil.TotalSeconds <= 3 && timeUntil.TotalSeconds > 0 && !_playedSounds[eventKey].Contains(0))
            {
                if (IsCurrencyVisible(evt.Currency))
                {
                    PlaySoundWithPreCheck("rolereveal.wav", evt.Currency, 0);
                    _playedSounds[eventKey].Add(0);
                }
            }

            // Cleanup old events
            var keysToRemove = _playedSounds.Keys.Where(k =>
            {
                var parts = k.Split('_');
                if (parts.Length >= 3 && DateTime.TryParseExact(parts[parts.Length - 1], "yyyyMMddHHmm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var eventTime))
                {
                    return eventTime < now.AddHours(-1);
                }
                return false;
            }).ToList();

            foreach (var key in keysToRemove)
                _playedSounds.Remove(key);
        }

        private void PlaySoundWithPreCheck(string fileName, string currency, int soundType)
        {
            Task.Delay(5000).ContinueWith(_ =>
            {
                if (IsCurrencyVisible(currency))
                    PlaySound(fileName);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void PlaySound(string fileName)
        {
            try
            {
                string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);
                if (File.Exists(soundPath))
                {
                    _currentPlayer = new SoundPlayer(soundPath);
                    _currentPlayer.Play();
                }
            }
            catch { }
        }

        private async Task FetchEventsAsync()
        {
            try
            {
                using var http = new HttpClient();
                var xmlText = await http.GetStringAsync(XmlFeedUrl);
                var doc = XDocument.Parse(xmlText);

                var estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

                var all = doc.Descendants("event")
                    .Select(x =>
                    {
                        var date = DateTime.ParseExact(
                            x.Element("date")!.Value.Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture);
                        var timePart = DateTime.ParseExact(
                            x.Element("time")!.Value.Trim(), "h:mmtt", CultureInfo.InvariantCulture);

                        var utcDt = DateTime.SpecifyKind(
                            new DateTime(date.Year, date.Month, date.Day, timePart.Hour, timePart.Minute, 0),
                            DateTimeKind.Utc);
                        var estDt = TimeZoneInfo.ConvertTimeFromUtc(utcDt, estZone);

                        return new ForexEvent
                        {
                            Date = date,
                            Time = FormatEventTime(estDt),
                            Currency = x.Element("country")!.Value.Trim(),
                            Title = x.Element("title")!.Value.Trim(),
                            Impact = x.Element("impact")!.Value.Trim(),
                            Forecast = x.Element("forecast")?.Value.Trim(),
                            Previous = x.Element("previous")?.Value.Trim(),
                            Occurrence = estDt,
                        };
                    })
                    .OrderBy(e => e.Occurrence)
                    .ToList();

                UpcomingEvents.Clear();
                foreach (var ev in all)
                    UpcomingEvents.Add(ev);
            }
            catch { }
        }

        // ==== PROPERTY CHANGE SUPPORT ====
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T backingField, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (Equals(backingField, value)) return false;
            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    /// <summary>
    /// Core market status viewmodel - handles 4 markets
    /// </summary>
    public class MarketCountdownCoreVM : INotifyPropertyChanged
    {
        private class MarketInfo
        {
            public string Name { get; }
            public string TimeZoneId { get; }
            public TimeSpan Open1 { get; }
            public TimeSpan Close1 { get; }
            public TimeSpan? Open2 { get; }
            public TimeSpan? Close2 { get; }

            public MarketInfo(string name, string tz, TimeSpan open1, TimeSpan close1, TimeSpan? open2 = null, TimeSpan? close2 = null)
            {
                Name = name;
                TimeZoneId = tz;
                Open1 = open1;
                Close1 = close1;
                Open2 = open2;
                Close2 = close2;
            }
        }

        private readonly MarketInfo[] _markets = new[]
        {
            new MarketInfo("London", "GMT Standard Time", TimeSpan.FromHours(8), TimeSpan.FromHours(17)),
            new MarketInfo("New York", "Eastern Standard Time", TimeSpan.FromHours(8), TimeSpan.FromHours(17)),
            new MarketInfo("Sydney", "AUS Eastern Standard Time", TimeSpan.FromHours(7), TimeSpan.FromHours(16)),
            new MarketInfo("Tokyo", "Tokyo Standard Time",
                TimeSpan.FromHours(9), TimeSpan.FromHours(11).Add(TimeSpan.FromMinutes(30)),
                TimeSpan.FromHours(12).Add(TimeSpan.FromMinutes(30)), TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(30)))
        };

        public bool Use24Hour { get; set; } = true;

        // Local times
        public string LondonLocalTime => FormatMarketTime(ToLocal(_markets[0]));
        public string NewYorkLocalTime => FormatMarketTime(ToLocal(_markets[1]));
        public string SydneyLocalTime => FormatMarketTime(ToLocal(_markets[2]));
        public string TokyoLocalTime => FormatMarketTime(ToLocal(_markets[3]));

        // Hours
        public string LondonHours => FormatHours(_markets[0]);
        public string NewYorkHours => FormatHours(_markets[1]);
        public string SydneyHours => FormatHours(_markets[2]);
        public string TokyoHours => FormatHours(_markets[3]);

        // Status
        public string LondonStatus => IsOpen(_markets[0]) ? "OPEN" : "CLOSED";
        public string NewYorkStatus => IsOpen(_markets[1]) ? "OPEN" : "CLOSED";
        public string SydneyStatus => IsOpen(_markets[2]) ? "OPEN" : "CLOSED";
        public string TokyoStatus => IsOpen(_markets[3]) ? "OPEN" : "CLOSED";

        // Display
        public string LondonDisplay => GetDisplay(_markets[0]);
        public string NewYorkDisplay => GetDisplay(_markets[1]);
        public string SydneyDisplay => GetDisplay(_markets[2]);
        public string TokyoDisplay => GetDisplay(_markets[3]);

        // Progress
        public double LondonProgress => ComputeProgress(_markets[0]);
        public double NewYorkProgress => ComputeProgress(_markets[1]);
        public double SydneyProgress => ComputeProgress(_markets[2]);
        public double TokyoProgress => ComputeProgress(_markets[3]);

        private DateTime ToLocal(MarketInfo market)
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(market.TimeZoneId);
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, tz);
        }

        private bool IsOpen(MarketInfo market)
        {
            var local = ToLocal(market);
            var time = local.TimeOfDay;
            return (time >= market.Open1 && time < market.Close1) ||
                   (market.Open2 != null && time >= market.Open2 && time < market.Close2);
        }

        private string FormatMarketTime(DateTime dt)
            => Use24Hour ? dt.ToString("HH:mm") : dt.ToString("hh:mm tt");

        private string FormatHours(MarketInfo market)
        {
            if (market.Open2 == null)
                return $"{market.Open1:hh\\:mm} - {market.Close1:hh\\:mm}";
            return $"{market.Open1:hh\\:mm} - {market.Close1:hh\\:mm} & {market.Open2:hh\\:mm} - {market.Close2:hh\\:mm}";
        }

        private string GetDisplay(MarketInfo market)
        {
            var local = ToLocal(market);
            var time = local.TimeOfDay;

            if (time >= market.Open1 && time < market.Close1)
            {
                var elapsed = time - market.Open1;
                return $"+{elapsed.Hours:D2}:{elapsed.Minutes:D2}";
            }

            if (market.Open2 != null && time >= market.Open2 && time < market.Close2)
            {
                var elapsed = time - market.Open2;
                return $"+{elapsed.Hours:D2}:{elapsed.Minutes:D2}";
            }

            TimeSpan? nextOpen = null;
            if (time < market.Open1)
                nextOpen = market.Open1 - time;
            else if (market.Open2 != null && time >= market.Close1 && time < market.Open2)
                nextOpen = market.Open2 - time;
            else if (time >= market.Close1 && (market.Open2 == null || time >= market.Close2))
            {
                var tomorrow = market.Open1.Add(TimeSpan.FromHours(24));
                nextOpen = tomorrow - time;
            }

            if (nextOpen.HasValue)
                return $"-{nextOpen.Value.Hours:D2}:{nextOpen.Value.Minutes:D2}";

            return "---";
        }

        private double ComputeProgress(MarketInfo market)
        {
            var local = ToLocal(market);
            var time = local.TimeOfDay;

            if (time >= market.Open1 && time < market.Close1)
            {
                var elapsed = (time - market.Open1).TotalSeconds;
                var total = (market.Close1 - market.Open1).TotalSeconds;
                return Math.Clamp(elapsed / total * 100, 0, 100);
            }

            if (market.Open2 != null && time >= market.Open2 && time < market.Close2)
            {
                var elapsed = (time - market.Open2).TotalSeconds;
                var total = (market.Close2 - market.Open2).TotalSeconds;
                return Math.Clamp(elapsed / total * 100, 0, 100);
            }

            return 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class ForexEvent : INotifyPropertyChanged
    {
        private string _time;
        public DateTime Date { get; set; }
        public string Time
        {
            get => _time;
            set { _time = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time))); }
        }
        public string Currency { get; set; } = "";
        public string Title { get; set; } = "";
        public string Impact { get; set; } = "";
        public string Forecast { get; set; }
        public string Previous { get; set; }
        public DateTime Occurrence { get; set; }
        public bool IsPast => Occurrence < DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
