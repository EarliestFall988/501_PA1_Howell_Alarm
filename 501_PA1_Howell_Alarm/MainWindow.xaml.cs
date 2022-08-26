using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _501_PA1_Howell_Alarm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;

            InitializeComponent();
            Core.AlarmFactory.Initialize();
            Paint();

            Core.AlarmFactory.OnAddAlarm += AddAlarm;
            Core.AlarmFactory.OnRemoveAlarm += RemoveAlarm;
            Core.AlarmFactory.OnClearAlarms += ClearAlarms;
        }

        private IEnumerable<Core.Alarm> Alarms => Core.AlarmFactory.Alarms;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Set all compoenents in xaml
        /// </summary>
        private void Paint()
        {
            HandleAlarmEnableActions();
            SetItemsInTheList();
            Debug.WriteLine("painting");
        }

        /// <summary>
        /// Set the alarm actions if they can be enabled or not
        /// </summary>
        private void HandleAlarmEnableActions()
        {

            if (Core.AlarmFactory.AlarmCount > 0)
            {
                alarmSummary.Visibility = Visibility.Visible;
            }
            else
            {
                alarmSummary.Visibility = Visibility.Hidden;
            }

            AlarmActions.RemoveAlarm.IsEnabled = Core.AlarmFactory.AlarmCount > 0;
            AlarmActions.AddAlarm.IsEnabled = Core.AlarmFactory.AlarmCount < 5;
        }

        private void SetItemsInTheList()
        {
            alarmSummary.Items.Clear();

            foreach (var x in Core.AlarmFactory.Alarms)
            {
                AlarmInstanceViewer viewer = new AlarmInstanceViewer();
                viewer.AlarmPropertiesButton.IsEnabled = false;
                viewer.AlarmPropertiesButton.Content = x.SetAlarmTime.ToShortTimeString();
                viewer.DataContext = x;
                alarmSummary.Items.Add(x);
            }
        }

        private void AddAlarm(Core.Alarm alarm)
        {
            Paint();
        }

        private void RemoveAlarm(Core.Alarm alarm)
        {
            Paint();
        }

        private void ClearAlarms()
        {
            Paint();
        }

        public void EditButtonClick(object? sender, RoutedEventArgs args)
        {
            var obj = args.OriginalSource;

            if (obj is Button button)
            {
                if (button.DataContext is Core.Alarm al)
                {
                    OpenWindow(al);
                }
                else
                {
                    Debug.WriteLine(button.DataContext);
                }
            }
            else
            {
                Debug.WriteLine(obj);
            }
        }

        public void OpenWindow(Core.Alarm alarm)
        {
            EditAlarmWindow window = new EditAlarmWindow();
            window.Show();
            window.SetAlarmContext(alarm);
        }
    }
}
