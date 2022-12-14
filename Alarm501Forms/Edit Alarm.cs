using Core;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm501Forms
{
    public partial class Edit_Alarm : Form
    {

        private Alarm? _alarm => EditAlarmStateController.EditedAlarm;

        public Edit_Alarm()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Time;

            if (_alarm != null)
            {
                //if (_alarm.SetAlarmTime.Hour > 12)
                //{
                //    hoursUpDown.Value = _alarm.SetAlarmTime.Hour - 12;
                //    ampmcombobox.Text = "PM";
                //}
                //else
                //{
                //    ampmcombobox.Text = "AM";
                //}

                //minutesUpDown.Value = _alarm.SetAlarmTime.Minute;

                dateTimePicker1.Text = _alarm.SetAlarmTime.ToShortTimeString();
                alarmStateComboBox.Text = _alarm.State.ToString();
                titleTextBox.Text = _alarm.AlarmTitle;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (_alarm != null)
            {
                

                string title = titleTextBox.Text;
                Enum.TryParse<AlarmState>(alarmStateComboBox.Text, out var alarmStateResult);

                DateTime time = DateTime.Parse(dateTimePicker1.Text);

               // DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)hours, (int)minutesUpDown.Value, 0);

                AlarmsManager.Update(_alarm, new Alarm(Guid.NewGuid().ToString(), title, time, alarmStateResult, _alarm.AlarmCreated));
            }

            PreClose();
        }

        private void PreClose()
        {
            EditAlarmStateController.SetComplete();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            PreClose();
        }
    }
}
