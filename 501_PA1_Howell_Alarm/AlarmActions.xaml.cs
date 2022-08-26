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
    /// Interaction logic for AlarmActions.xaml
    /// </summary>
    public partial class AlarmActions : UserControl
    {
        public AlarmActions()
        {
            InitializeComponent();
        }

        private void AddAlarm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Core.AlarmFactory.Create(new Core.Alarm(DateTime.Now, Core.AlarmState.On));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void RemoveAlarm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var alarm = Core.AlarmFactory.AllAlarms[0];
                Core.AlarmFactory.Delete(alarm.Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }
    }
}
