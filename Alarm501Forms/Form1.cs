using Core;

namespace Alarm501Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EditAlarm.OnFinishAlarm += PaintListView;
            PaintListView();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AlarmFactory.AlarmCount == 5)
            {
                var result = MessageBox.Show("Only 5 alarms are allowed - add more?", "Question", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                }
                else if (result == DialogResult.No)
                    return;
            }

            AlarmFactory.Create(new Alarm(DateTime.Now, AlarmState.On));

            PaintListView();
        }

        public void PaintListView()
        {
            listView1.Items.Clear();

            foreach (var x in AlarmFactory.Alarms)
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
                        if (AlarmFactory.TryGetAlarmById(id, out var alarm))
                        {
                            AlarmFactory.Delete(alarm);
                        }
                    }

                    listView1.Items.Remove(item);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Title = "Save Alarm File";
            //dialog.InitialDirectory = AlarmFactory.Directory;
            //dialog.ShowDialog();

            //FileInfo info = new FileInfo(dialog.FileName);
            //string? directory = info.DirectoryName;
            //string? name = info.FullName;

            //if (directory != null && name != null)
            //{
            //    AlarmFactory.Directory = directory;
            //    AlarmFactory.FileName = name;
            //}
            //else
            //{
            //    MessageBox.Show("the directory is not valid", "Error");
            //}
        }

        private void editSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifyIcon icon = new NotifyIcon();
            icon.Text = "test";
            icon.Visible = true;

            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("You can edit only one alarm at a time", "Note");
                return;
            }

            var key = listView1.SelectedItems[0].ImageKey;

            if (AlarmFactory.TryGetAlarmById(key, out var alarm))
            {
                EditAlarm.SetEdit(alarm);
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void alarmDropDown_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }
    }
}