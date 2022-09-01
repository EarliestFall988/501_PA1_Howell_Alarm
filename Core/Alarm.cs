using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core
{
    /// <summary>
    /// Handles recording an instance of an alarm clock, handling time, on/off, etc
    /// </summary>
    /// <remarks>I know we're not talking about any paradigms yet, but this is my 'record' type that just stores information</remarks>
    public class Alarm : IComparable<Alarm>, IEquatable<Alarm>
    {
        /// <summary>
        /// the 'finger print' id of the alarm, so Alarm501 knows which alarm is which when pulling it out of the text file
        /// </summary>
        [JsonPropertyName("alarm-id")]
        public string AlarmID { get; private set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// The date and time of the alarm created
        /// </summary>
        [JsonPropertyName("alarm-created")]
        public DateTime AlarmCreated { get; private set; } = DateTime.Now;

        /// <summary>
        /// The time the clock will go off
        /// </summary>
        [JsonPropertyName("alarm-set-time")]
        public DateTime SetAlarmTime { get; private set; } = DateTime.Now;

        /// <summary>
        /// The state of the alarm: is the alarm set to go off?
        /// </summary>
        /// <remarks>
        ///  Extention -> did the user acutally turn the alarm off? or did the alarm just go off indefinetly?
        /// </remarks>
        [JsonPropertyName("alarm-state")]
        public AlarmState State { get; private set; } = AlarmState.On;

        /// <summary>
        /// The name of the alarm
        /// </summary>
        public string AlarmTitle { get; set; } = "My New Alarm";

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="alarmID">the id of the alarm</param>
        /// <param name="setAlarmTime">the time the alarm will go off</param>
        /// <param name="state">the state of the alarm</param>
        [JsonConstructor()]
        public Alarm(string alarmID, string alarmTitle, DateTime setAlarmTime, AlarmState state, DateTime AlarmCreated)
        {
            PostConstructor(alarmID, alarmTitle, setAlarmTime, state, AlarmCreated);
        }

        /// <summary>
        /// Other constructor - used for creating a brand new alarm
        /// </summary>
        /// <param name="dateTime">the time the alarm will go off</param>
        /// <param name="state">the state of the alarm</param>
        public Alarm(DateTime dateTime, AlarmState state)
        {
            PostConstructor(Guid.NewGuid().ToString(), string.Empty, dateTime, state, DateTime.Now);
        }

        /// <summary>
        /// Handles information that both constructors need as well as the location for faulty input error checking
        /// </summary>
        /// <param name="state">the state of the alarm</param>
        /// <param name="setAlarmTime">the set alarm time to go off</param>
        /// <param name="alarmID">the finger print id of the alarm</param>
        /// <param name="alarmCreated">the date and time the alarm was created</param>
        /// <param name="alarmTitle">the title of the alarm</param>
        /// <remarks>
        /// Because we're using dotnet6 we don't have to worry about null references here.
        /// </remarks>
        /// <exception cref="ArgumentException">thrown when the alarm id is an empty string or when the alarm is set to go off before now</exception>
        /// <exception cref="ArgumentOutOfRangeException">thrown when the alarm state is not recognized</exception>
        private void PostConstructor(string alarmID, string alarmTitle, DateTime setAlarmTime, AlarmState state, DateTime alarmCreated)
        {
            if (alarmID.Trim().Length == 0)
                throw new ArgumentException($"The {nameof(alarmID)} parameter cannot be empty");

            if (!Enum.IsDefined(typeof(AlarmState), state))
                throw new ArgumentOutOfRangeException($"The {nameof(state)} is not recognized as a valid alarm clock state ({state.ToString()}).");

            AlarmID = alarmID;
            SetAlarmTime = setAlarmTime;
            State = state;
            AlarmCreated = alarmCreated;
            AlarmTitle = alarmTitle;
        }

        #region interface contract fulfillment

        public int CompareTo(Alarm? other)
        {
            if (other != null)
            {
                int num = AlarmCreated.CompareTo(other.AlarmCreated);
                if (num == 0)
                {
                    return AlarmID.CompareTo(other.AlarmID);
                }
                else
                {
                    return num;
                }
            }
            else
            {
                return -1;
            }
        }

        public bool Equals(Alarm? other)
        {
            if (other != null)
            {
                if (AlarmCreated == other.AlarmCreated)
                {
                    return AlarmID == other.AlarmID;
                }
            }

            return false;

        }

        #endregion
    }

    /// <summary>
    /// The state of the alarm
    /// </summary>
    public enum AlarmState
    {
        Off,
        On,
    }
}
