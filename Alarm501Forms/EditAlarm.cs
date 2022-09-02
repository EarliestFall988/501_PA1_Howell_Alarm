using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;

namespace Alarm501Forms
{
    /// <summary>
    /// Handles managing Application state (in this case when editing alarm or not)
    /// </summary>
    public static class EditAlarmStateController
    {
        /// <summary>
        /// The alarm being edited
        /// </summary>
        public static Alarm? EditedAlarm { get; private set; }


        public delegate void FinishAlarm();
        public static event FinishAlarm? OnFinishAlarm;

        public static DialogResult SetEdit(Alarm alarm)
        {
            EditedAlarm = alarm;
            EditedAlarm.EditingAlarm = true;

            Edit_Alarm form = new Edit_Alarm();
            return form.ShowDialog();
        }

        public static void SetComplete()
        {
            OnFinishAlarm?.Invoke();

            if (EditedAlarm != null)
            {
                EditedAlarm.EditingAlarm = false;
                EditedAlarm = null;
            }
        }
    }
}
