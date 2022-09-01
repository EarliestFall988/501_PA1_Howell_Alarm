using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmCoreTests
{
    /// <summary>
    /// Test the alarm factory
    /// </summary>
    public class AlarmFactoryTests
    {
        /// <summary>
        /// Adding an alarm saves to the dictionary (does not save to the file)
        /// </summary>
        [Fact]
        public void AddingAndRemovingAlarmNonPersistantSuccessful()
        {
            AlarmsManager.Clear(false); // handling persistant issues

            var alarm = new Alarm(DateTime.Now, AlarmState.Disabled);

            AlarmsManager.Create(alarm, false);
            Assert.Equal(1, AlarmsManager.AlarmCount);
            AlarmsManager.Clear(false);
            Assert.Equal(0, AlarmsManager.AlarmCount);
        }


        /// <summary>
        /// Adding two alarms saves to the dictionary (does not save to the file)
        /// </summary>
        [Fact]
        public void AddingAndRemovingTwoAlarmsNonPersistantSuccessful()
        {
            AlarmsManager.Clear(false); // handling persistant issues

            var alarm = new Alarm(DateTime.Now, AlarmState.Disabled);
            var alarm2 = new Alarm(DateTime.Now.AddHours(2), AlarmState.Enabled);

            AlarmsManager.Create(alarm, false);
            AlarmsManager.Create(alarm2, false);

            Assert.Equal(2, AlarmsManager.AlarmCount);
            AlarmsManager.Clear(false);
            Assert.Equal(0, AlarmsManager.AlarmCount);
        }

        /// <summary>
        /// Adding five alarms saves to the dictionary (does not save to the file)
        /// </summary>
        [Fact]
        public void AddingAndRemovingFiveAlarmsNonPersistantSuccessful()
        {
            AlarmsManager.Clear(false); // handling persistant issues

            var alarm = new Alarm(DateTime.Now, AlarmState.Disabled);
            var alarm2 = new Alarm(DateTime.Now.AddHours(2), AlarmState.Enabled);
            var alarm3 = new Alarm(DateTime.Now.AddHours(2), AlarmState.Enabled);
            var alarm4 = new Alarm(DateTime.Now.AddHours(2), AlarmState.Enabled);
            var alarm5 = new Alarm(DateTime.Now.AddHours(2), AlarmState.Enabled);

            AlarmsManager.Create(alarm, false);
            AlarmsManager.Create(alarm2, false);
            AlarmsManager.Create(alarm3, false);
            AlarmsManager.Create(alarm4, false);
            AlarmsManager.Create(alarm5, false);

            Assert.Equal(5, AlarmsManager.AlarmCount);
            AlarmsManager.Clear(false);
            Assert.Equal(0, AlarmsManager.AlarmCount);
        }

        /// <summary>
        /// Test that the alarms actually get save to the dict and saved to a file in the downloads folder
        /// </summary>
        [Fact]
        public void AddOneAlarmPersistantSuccessful()
        {
            AlarmsManager.Clear(false); // handling persistant issues

            var alarm = new Alarm(DateTime.Now.AddHours(1), AlarmState.Enabled);
            AlarmsManager.Create(alarm);
            Assert.Equal(1, AlarmsManager.AlarmCount);

            AlarmsManager.Clear(false);
            Assert.Equal(0, AlarmsManager.AlarmCount);

            AlarmsManager.Initialize();
            Assert.Equal(1, AlarmsManager.AlarmCount);

            AlarmsManager.RemoveFile();
        }

        /// <summary>
        /// Test that the alarms actually get save to the dict and saved to a file in the downloads folder
        /// </summary>
        [Fact]
        public void AddTenAlarmsPersistantSuccessful()
        {
            AlarmsManager.Clear(false); // handling persistant/static issues

            for (int i = 0; i < 10; i++)
            {
                var alarm = new Alarm(DateTime.Now.AddHours(i), (AlarmState)(i % 2));
                AlarmsManager.Create(alarm);
            }

            Assert.Equal(10, AlarmsManager.AlarmCount);

            AlarmsManager.Clear(false);
            Assert.Equal(0, AlarmsManager.AlarmCount);

            AlarmsManager.Initialize();
            Assert.Equal(10, AlarmsManager.AlarmCount);

           AlarmsManager.RemoveFile();
        }
    }
}
