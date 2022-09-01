using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Alarm501_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void addAlarmToolStripButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem("alarm");
            item.SubItems.Add("alarm");
            item.SubItems.Add("12:20");
            listView1.Items.Add(item);
        }

        private void PaintListView()
        {

        }
    }
}
