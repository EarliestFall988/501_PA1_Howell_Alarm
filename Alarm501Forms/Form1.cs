using Core;

using System.Diagnostics;

namespace Alarm501Forms
{
    public partial class Form1 : Form
    {

        private Dictionary<string, Alarm> _alarmsGoingOff = new Dictionary<string, Alarm>();

        public Form1()
        {
            AlarmsManager.Initialize();
            InitializeComponent();

            editSelectedToolStripMenuItem.Enabled = false;
            removeToolStripMenuItem.Enabled = false;

            alarmSFX_label.Text = "";

            EditAlarmStateController.OnFinishAlarm += PaintListView;
            PaintListView();
            InitializeTimer();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AlarmsManager.AlarmCount == 5)
            {
                var result = MessageBox.Show("Only 5 alarms are allowed - add more?", "Question", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                }
                else if (result == DialogResult.No)
                    return;
            }

            var alarm = new Alarm(Guid.NewGuid().ToString(), "New Alarm", DateTime.Now.AddSeconds(4), AlarmState.Enabled, DateTime.Now);

            PaintListView();

            var dialogResult = EditAlarmStateController.SetEdit(alarm);

            if (dialogResult == DialogResult.OK)
            {
                AlarmsManager.Create(alarm);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("You must add alarms first before removing them", "Note");
                return;
            }

            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("You must select alarms that you want to remove first", "Note");
                return;
            }

            foreach (var x in listView1.SelectedItems)
            {
                if (x is ListViewItem item)
                {
                    string id = item.ImageKey;
                    if (id != string.Empty)
                    {
                        if (AlarmsManager.TryGetAlarmById(id, out var alarm))
                        {
                            AlarmsManager.Delete(alarm);
                        }
                    }

                    listView1.Items.Remove(item);
                }
            }
        }

        private void editSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("You can edit only one alarm at a time", "Note");
                return;
            }

            var key = listView1.SelectedItems[0].ImageKey;

            if (AlarmsManager.TryGetAlarmById(key, out var alarm))
            {
                EditAlarmStateController.SetEdit(alarm);
            }
        }

        private void alarmDropDown_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                editSelectedToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = false;
            }
            else if (listView1.SelectedItems.Count == 1)
            {
                editSelectedToolStripMenuItem.Enabled = true;
                removeToolStripMenuItem.Enabled = true;
            }
            else if (listView1.SelectedItems.Count > 1)
            {
                editSelectedToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = true;
            }
        }

        private void InitializeTimer()
        {
            var timer = new System.Timers.Timer(100);
            timer.Elapsed += CheckAlarmsComplete;
            timer.SynchronizingObject = this;
            timer.AutoReset = true;
            timer.Start();
        }

        private void CheckAlarmsComplete(object? sender, System.Timers.ElapsedEventArgs args)
        {

            var alarms = Core.AlarmsManager.AllAlarms;

            foreach (var x in alarms)
            {
                if (x.Value.State == AlarmState.Enabled && TimeSpan.Compare(DateTime.Now.TimeOfDay, x.Value.SetAlarmTime.TimeOfDay) >= 0)
                {
                    if (!_alarmsGoingOff.ContainsKey(x.Value.AlarmID))
                    {
                        SoundOff(x.Value);
                        _alarmsGoingOff.Add(x.Key, x.Value);
                    }
                }
            }
        }

        private void SoundOff(Alarm alarm)
        {
            if (alarm.State != AlarmState.Sounding_Off)
            {
                AlarmsManager.UpdateState(alarm, AlarmState.Sounding_Off);

                Debug.WriteLine(String.Join(",", _alarmsGoingOff));
                SetAlarmSoundOffActive(true);
                PaintListView();

                MessageBox.Show($"Alarm is going off:\n\'{alarm.AlarmTitle}\'", "Alarm");
            }
        }

        private void SetAlarmSoundOffActive(bool active)
        {
            snoozeToolStripMenuItem.Enabled = active;
            stopToolStripMenuItem.Enabled = active;
            largestopbutton.Enabled = active;
            alarmDropDown.Enabled = !active;
            mainSnoozeButton.Enabled = active;

            if (active) listView1.SelectedItems.Clear();

            listView1.Enabled = !active;

            if (active) alarmSFX_label.Text = "**Beep Beep**";
            else alarmSFX_label.Text = "";
        }


        public void PaintListView()
        {
            listView1.Items.Clear();

            foreach (var x in AlarmsManager.Alarms)
            {
                ListViewItem item;

                ListViewItem.ListViewSubItem[] items = new ListViewItem.ListViewSubItem[] {
                    new ListViewItem.ListViewSubItem(null, $"'{x.AlarmTitle}'"),
                    new ListViewItem.ListViewSubItem(null, x.SetAlarmTime.ToShortTimeString()),
                    new ListViewItem.ListViewSubItem(null, x.State.ToString())
                };

                item = new ListViewItem(items, x.AlarmID);
                listView1.Items.Add(item);
            }
        }


        private void Snooze()
        {
            foreach (var x in _alarmsGoingOff)
            {
                AlarmsManager.UpdateState(x.Value, AlarmState.Enabled);
                AlarmsManager.Snooze(x.Value, 3);
            }

            _alarmsGoingOff.Clear();
            SetAlarmSoundOffActive(false);

            PaintListView();
        }

        private void Stop()
        {

            foreach (var x in _alarmsGoingOff)
            {
                AlarmsManager.UpdateState(x.Value, AlarmState.Disabled);
            }

            _alarmsGoingOff.Clear();
            SetAlarmSoundOffActive(false);

            PaintListView();
        }

        private void mainSnoozeButton_Click(object sender, EventArgs e)
        {
            Snooze();
        }

        private void largestopbutton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void snoozeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Snooze();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }
    }
}