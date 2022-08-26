namespace AlarmCoreTests
{
    /// <summary>
    /// Handles testing a few types of obvious input errors with alarms
    /// </summary>
    public class AlarmTests
    {

        /// <summary>
        /// Verify that alarms can be constructed sucessfully
        /// </summary>
        /// <param name="state">the different alarm states</param>
        [
            Theory,
            InlineData(AlarmState.Off),
            InlineData(AlarmState.On)
            ]
        public void AlarmDoesCreateSuccessfullyUponUserCreationWithShortConstructor(AlarmState state)
        {
            Alarm al = new Alarm(DateTime.Now, state);
        }

        /// <summary>
        /// Verify that alarms can be constructed sucessfully
        /// </summary>
        /// <param name="state">the different alarm states</param>
        [
            Theory,
            InlineData(AlarmState.Off),
            InlineData(AlarmState.On)
            ]
        public void AlarmDoesCreateSuccessfullyUponUserCreationWithDefaultConstructor(AlarmState state)
        {
            Alarm al1 = new Alarm(Guid.NewGuid().ToString(), DateTime.Now, state, DateTime.Now);
        }

        /// <summary>
        /// verify that an empty alarm id string is not allowed
        /// </summary>
        [
            Theory,
            InlineData(""),
            InlineData(" "),
            InlineData("  "),
            InlineData("           ")
            ]
        public void AlarmFailsIfIDIsEmptyOrWhiteSpace(string id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var al = new Alarm(id, DateTime.Now, AlarmState.On, DateTime.Now);
            });
        }

        /// <summary>
        /// verify that the state for the alarm is valid
        /// </summary>
        [Fact]
        public void AlarmFailsWhenAlarmStateIsNotRecognized()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var al = new Alarm(DateTime.Now, (AlarmState)100);
            });
        }
    }
}