using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;

namespace Alarm501Forms
{
    public static class EditAlarm
    {

        public static Alarm? EditedAlarm { get; private set; }

        public delegate void FinishAlarm();
        public static event FinishAlarm? OnFinishAlarm;

        public static void SetEdit(Alarm alarm)
        {
            EditedAlarm = alarm;

            Edit_Alarm form = new Edit_Alarm();
            form.ShowDialog();
        }

        public static void SetComplete()
        {
            OnFinishAlarm?.Invoke();
        }
    }
}
