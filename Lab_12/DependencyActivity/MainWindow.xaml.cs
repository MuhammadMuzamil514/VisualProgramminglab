using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Initialize timer to update Currenttimeproperty
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => Currenttimeproperty = DateTime.Now;
            timer.Start();
        }

        // CLR Wrapper for Currenttimeproperty
        public DateTime Currenttimeproperty
        {
            get { return (DateTime)GetValue(CurrenttimepropertyProperty); }
            set { SetValue(CurrenttimepropertyProperty, value); }
        }

        // Dependency Property Registration with Coerce and Validation Callbacks
        public static readonly DependencyProperty CurrenttimepropertyProperty =
            DependencyProperty.Register(
                nameof(Currenttimeproperty),
                typeof(DateTime),
                typeof(MainWindow),
                new PropertyMetadata(
                    DateTime.Now,                  // Default Value
                    OnCurrenttimeChanged,          // Property Changed Callback
                    CoerceCurrenttime),            // Coerce Value Callback
                ValidateCurrenttime);             // Validation Callback

        // Property Changed Callback (Optional)
        private static void OnCurrenttimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MainWindow;
            Console.WriteLine($"Currenttimeproperty changed from {e.OldValue} to {e.NewValue}");
        }

        // Coerce Value Callback
        private static object CoerceCurrenttime(DependencyObject d, object baseValue)
        {
            var currentTime = (DateTime)baseValue;

            // Ensure the time is not in the future
            if (currentTime > DateTime.Now)
            {
                Console.WriteLine("Coerce: Adjusting future time to current time.");
                return DateTime.Now;
            }

            return currentTime;
        }

        // Validation Callback
        private static bool ValidateCurrenttime(object value)
        {
            var currentTime = (DateTime)value;

            // Validate that the date is not earlier than 2000
            if (currentTime.Year < 2023)
            {
                Console.WriteLine("Validation Failed: Date must not be before the year 2000.");
                return false;
            }

            return true;
        }
    }
}
