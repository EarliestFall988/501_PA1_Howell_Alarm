namespace Alarm501Forms
{
    partial class Edit_Alarm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.alarmStateComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.ampmcombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.hoursUpDown = new System.Windows.Forms.NumericUpDown();
            this.minutesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hoursUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Set Alarm On Or Off?";
            // 
            // alarmStateComboBox
            // 
            this.alarmStateComboBox.FormattingEnabled = true;
            this.alarmStateComboBox.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.alarmStateComboBox.Location = new System.Drawing.Point(12, 77);
            this.alarmStateComboBox.Name = "alarmStateComboBox";
            this.alarmStateComboBox.Size = new System.Drawing.Size(200, 23);
            this.alarmStateComboBox.TabIndex = 3;
            this.alarmStateComboBox.Text = "On";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 150);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(93, 150);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ampmcombobox
            // 
            this.ampmcombobox.AutoCompleteCustomSource.AddRange(new string[] {
            "On",
            "Off"});
            this.ampmcombobox.FormattingEnabled = true;
            this.ampmcombobox.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.ampmcombobox.Location = new System.Drawing.Point(160, 33);
            this.ampmcombobox.Name = "ampmcombobox";
            this.ampmcombobox.Size = new System.Drawing.Size(52, 23);
            this.ampmcombobox.TabIndex = 8;
            this.ampmcombobox.Text = "AM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Title";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(12, 121);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 23);
            this.titleTextBox.TabIndex = 10;
            // 
            // hoursUpDown
            // 
            this.hoursUpDown.Location = new System.Drawing.Point(12, 33);
            this.hoursUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.hoursUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hoursUpDown.Name = "hoursUpDown";
            this.hoursUpDown.Size = new System.Drawing.Size(46, 23);
            this.hoursUpDown.TabIndex = 11;
            this.hoursUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hoursUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // minutesUpDown
            // 
            this.minutesUpDown.Location = new System.Drawing.Point(80, 33);
            this.minutesUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minutesUpDown.Name = "minutesUpDown";
            this.minutesUpDown.Size = new System.Drawing.Size(74, 23);
            this.minutesUpDown.TabIndex = 12;
            this.minutesUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = ":";
            // 
            // Edit_Alarm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(230, 185);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minutesUpDown);
            this.Controls.Add(this.hoursUpDown);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ampmcombobox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.alarmStateComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_Alarm";
            this.ShowIcon = false;
            this.Text = "Edit Alarm";
            ((System.ComponentModel.ISupportInitialize)(this.hoursUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private ComboBox alarmStateComboBox;
        private Button cancelButton;
        private Button OkButton;
        private ComboBox ampmcombobox;
        private Label label3;
        private TextBox titleTextBox;
        private NumericUpDown hoursUpDown;
        private NumericUpDown minutesUpDown;
        private Label label4;
    }
}