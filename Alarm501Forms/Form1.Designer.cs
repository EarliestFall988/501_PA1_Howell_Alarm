namespace Alarm501Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.alarmID = new System.Windows.Forms.ColumnHeader();
            this.alarmSetTime = new System.Windows.Forms.ColumnHeader();
            this.alarmState = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.alarmDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.snoozeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mainSnoozeButton = new System.Windows.Forms.Button();
            this.alarmSFX_label = new System.Windows.Forms.Label();
            this.largestopbutton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.alarmID,
            this.alarmSetTime,
            this.alarmState});
            this.listView1.Location = new System.Drawing.Point(12, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(396, 141);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // alarmID
            // 
            this.alarmID.Text = "Title";
            this.alarmID.Width = 100;
            // 
            // alarmSetTime
            // 
            this.alarmSetTime.DisplayIndex = 2;
            this.alarmSetTime.Text = "Alarm Set";
            this.alarmSetTime.Width = 100;
            // 
            // alarmState
            // 
            this.alarmState.DisplayIndex = 1;
            this.alarmState.Text = "On/Off";
            this.alarmState.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alarmDropDown,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(420, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // alarmDropDown
            // 
            this.alarmDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.alarmDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.editSelectedToolStripMenuItem});
            this.alarmDropDown.Image = ((System.Drawing.Image)(resources.GetObject("alarmDropDown.Image")));
            this.alarmDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alarmDropDown.Name = "alarmDropDown";
            this.alarmDropDown.Size = new System.Drawing.Size(40, 22);
            this.alarmDropDown.Text = "Edit";
            this.alarmDropDown.Click += new System.EventHandler(this.alarmDropDown_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeToolStripMenuItem.Text = "Remove Selected";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // editSelectedToolStripMenuItem
            // 
            this.editSelectedToolStripMenuItem.Name = "editSelectedToolStripMenuItem";
            this.editSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editSelectedToolStripMenuItem.Text = "Edit Selected";
            this.editSelectedToolStripMenuItem.Click += new System.EventHandler(this.editSelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Click += new System.EventHandler(this.toolStripSeparator1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snoozeToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(97, 22);
            this.toolStripDropDownButton1.Text = "Alarm Options";
            // 
            // snoozeToolStripMenuItem
            // 
            this.snoozeToolStripMenuItem.Enabled = false;
            this.snoozeToolStripMenuItem.Name = "snoozeToolStripMenuItem";
            this.snoozeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.snoozeToolStripMenuItem.Text = "Snooze";
            this.snoozeToolStripMenuItem.Click += new System.EventHandler(this.snoozeToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // mainSnoozeButton
            // 
            this.mainSnoozeButton.Enabled = false;
            this.mainSnoozeButton.Location = new System.Drawing.Point(12, 188);
            this.mainSnoozeButton.Name = "mainSnoozeButton";
            this.mainSnoozeButton.Size = new System.Drawing.Size(269, 23);
            this.mainSnoozeButton.TabIndex = 1;
            this.mainSnoozeButton.Text = "Snooze";
            this.mainSnoozeButton.UseVisualStyleBackColor = true;
            this.mainSnoozeButton.Click += new System.EventHandler(this.mainSnoozeButton_Click);
            // 
            // alarmSFX_label
            // 
            this.alarmSFX_label.AutoSize = true;
            this.alarmSFX_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alarmSFX_label.Location = new System.Drawing.Point(139, 214);
            this.alarmSFX_label.Name = "alarmSFX_label";
            this.alarmSFX_label.Size = new System.Drawing.Size(110, 21);
            this.alarmSFX_label.TabIndex = 2;
            this.alarmSFX_label.Text = "**Beep Beep**";
            // 
            // largestopbutton
            // 
            this.largestopbutton.Enabled = false;
            this.largestopbutton.Location = new System.Drawing.Point(287, 188);
            this.largestopbutton.Name = "largestopbutton";
            this.largestopbutton.Size = new System.Drawing.Size(121, 23);
            this.largestopbutton.TabIndex = 3;
            this.largestopbutton.Text = "Stop";
            this.largestopbutton.UseVisualStyleBackColor = true;
            this.largestopbutton.Click += new System.EventHandler(this.largestopbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 259);
            this.Controls.Add(this.largestopbutton);
            this.Controls.Add(this.alarmSFX_label);
            this.Controls.Add(this.mainSnoozeButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Alarm501";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private ColumnHeader alarmID;
        private ColumnHeader alarmState;
        private ToolStrip toolStrip1;
        private System.Windows.Forms.Timer timer1;
        private ToolStripDropDownButton alarmDropDown;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem editSelectedToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem snoozeToolStripMenuItem;
        private ColumnHeader alarmSetTime;
        private Button mainSnoozeButton;
        private Label alarmSFX_label;
        private ToolStripMenuItem stopToolStripMenuItem;
        private Button largestopbutton;
    }
}