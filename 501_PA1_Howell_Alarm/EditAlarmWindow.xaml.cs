﻿using System;
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
using System.Windows.Shapes;

namespace _501_PA1_Howell_Alarm
{
    /// <summary>
    /// Interaction logic for EditAlarmWindow.xaml
    /// </summary>
    public partial class EditAlarmWindow : Window
    {
        public EditAlarmWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void SetAlarmContext(Core.Alarm alarm)
        {
            this.DataContext = alarm;
        }
    }
}
