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
            AlarmFactory.Clear(false); // handling persistant issues

            var alarm = new Alarm(DateTime.Now, AlarmState.Off);

            AlarmFactory.Create(alarm, false);
            Assert.Equal(1, AlarmFactory.AlarmCount);
            AlarmFactory.Clear(false);
            Assert.Equal(0, AlarmFactory.AlarmCount);
        }


        /// <summary>
        /// Adding two alarms saves to the dictionary (does not save to the file)
        /// </summary>
        [Fact]
        public void AddingAndRemovingTwoAlarmsNonPersistantSuccessful()
        {
            AlarmFactory.Clear(false); // handling persistant issues

            var alarm = new Alarm(DateTime.Now, AlarmState.Off);
            var alarm2 = new Alarm(DateTime.Now.AddHours(2), AlarmState.On);

            AlarmFactory.Create(alarm, false);
            AlarmFactory.Create(alarm2, false);

            Assert.Equal(2, AlarmFactory.AlarmCount);
            AlarmFactory.Clear(false);
            Assert.Equal(0, AlarmFactory.AlarmCount);
        }

        /// <summary>
        /// Adding five alarms saves to the dictionary (does not save to the file)
        /// </summary>
        [Fact]
        public void AddingAndRemovingFiveAlarmsNonPersistantSuccessful()
        {
            AlarmFactory.Clear(false); // handling persistant issues

            var alarm = new Alarm(DateTime.Now, AlarmState.Off);
            var alarm2 = new Alarm(DateTime.Now.AddHours(2), AlarmState.On);
            var alarm3 = new Alarm(DateTime.Now.AddHours(2), AlarmState.On);
            var alarm4 = new Alarm(DateTime.Now.AddHours(2), AlarmState.On);
            var alarm5 = new Alarm(DateTime.Now.AddHours(2), AlarmState.On);

            AlarmFactory.Create(alarm, false);
            AlarmFactory.Create(alarm2, false);
            AlarmFactory.Create(alarm3, false);
            AlarmFactory.Create(alarm4, false);
            AlarmFactory.Create(alarm5, false);

            Assert.Equal(5, AlarmFactory.AlarmCount);
            AlarmFactory.Clear(false);
            Assert.Equal(0, AlarmFactory.AlarmCount);
        }

        /// <summary>
        /// Test that the alarms actually get save to the dict and saved to a file in the downloads folder
        /// </summary>
        [Fact]
        public void AddOneAlarmPersistantSuccessful()
        {
            AlarmFactory.Clear(false); // handling persistant issues

            var alarm = new Alarm(DateTime.Now.AddHours(1), AlarmState.On);
            AlarmFactory.Create(alarm);
            Assert.Equal(1, AlarmFactory.AlarmCount);

            AlarmFactory.Clear(false);
            Assert.Equal(0, AlarmFactory.AlarmCount);

            AlarmFactory.Initialize();
            Assert.Equal(1, AlarmFactory.AlarmCount);

            AlarmFactory.RemoveFile();
        }

        /// <summary>
        /// Test that the alarms actually get save to the dict and saved to a file in the downloads folder
        /// </summary>
        [Fact]
        public void AddTenAlarmsPersistantSuccessful()
        {
            AlarmFactory.Clear(false); // handling persistant/static issues

            for (int i = 0; i < 10; i++)
            {
                var alarm = new Alarm(DateTime.Now.AddHours(i), (AlarmState)(i % 2));
                AlarmFactory.Create(alarm);
            }

            Assert.Equal(10, AlarmFactory.AlarmCount);

            AlarmFactory.Clear(false);
            Assert.Equal(0, AlarmFactory.AlarmCount);

            AlarmFactory.Initialize();
            Assert.Equal(10, AlarmFactory.AlarmCount);

           AlarmFactory.RemoveFile();
        }
    }
}
