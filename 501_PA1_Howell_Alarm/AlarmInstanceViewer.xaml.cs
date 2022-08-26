using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AlarmInstanceViewer.xaml
    /// </summary>
    public partial class AlarmInstanceViewer : UserControl
    {
        public AlarmInstanceViewer()
        {
            InitializeComponent();
        }

        public void ViewAlarm()
        {
            EditAlarmWindow window = new EditAlarmWindow();
            window.Show();
        }

        private void AlarmPropertiesButton_Click(object sender, RoutedEventArgs e)
        {
            ViewAlarm();
        }
    }
}
