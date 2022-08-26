using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core
{
    /// <summary>
    /// This class handles and creates alarms, it is static because there should only be one alarm factory per program instance
    /// </summary>
    public static class AlarmFactory
    {

        /// <summary>
        /// Handles the list of created alarms using the alarm id (fingerprint) as the key
        /// </summary>
        /// <remarks>
        /// Made private because we do not want anyone/anything to alter reference type lists and dictionaries. (Making this public could cause some unintended side effects)
        /// </remarks>
        private static Dictionary<string, Alarm> CreatedAlarms { get; set; } = new Dictionary<string, Alarm>();

        /// <summary>
        /// The count of created alarms
        /// </summary>
        public static int AlarmCount => CreatedAlarms.Count;

        /// <summary>
        /// Enumerate through the list of alarms
        /// </summary>
        public static IEnumerable<Alarm> Alarms => CreatedAlarms.Values;


        /// <summary>
        /// Get an array of all alarms
        /// </summary>
        public static KeyValuePair<string, Alarm>[] AllAlarms
        {
            get
            {
                return CreatedAlarms.ToArray();
            }
        }

        /// <summary>
        /// The directory of the file path
        /// </summary>
        private static readonly string _directory = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";

        /// <summary>
        /// The alarms save file path, saved to the downloads folder where it can be quickly found and deleted
        /// </summary>
        private static readonly string _saveFilePath = _directory + @"pa1_howell_alarms.txt";

        public delegate void AddAlarm(Alarm alarm);
        public delegate void RemoveAlarm(Alarm alarm);
        public delegate void ClearAlarms();

        public static event AddAlarm? OnAddAlarm;
        public static event RemoveAlarm? OnRemoveAlarm;
        public static event ClearAlarms? OnClearAlarms;


        /// <summary>
        /// Add a new alarm
        /// </summary>
        /// <param name="alarm">the alarm</param>
        /// <param name="serializeChanges">should we serlize the changes?</param>
        public static void Create(Alarm alarm, bool serializeChanges = true)
        {
            CreatedAlarms.Add(alarm.AlarmID, alarm);

            OnAddAlarm?.Invoke(alarm);

            if (serializeChanges)
                Serialize();
        }

        /// <summary>
        /// remove the alarm
        /// </summary>
        /// <param name="alarm">the alarm</param>
        ///  /// <param name="serializeChanges">should we save the changes?</param>
        public static void Delete(Alarm alarm, bool serializeChanges = true)
        {

            CreatedAlarms.Remove(alarm.AlarmID);

            OnRemoveAlarm?.Invoke(alarm);

            if (serializeChanges)
                Serialize();
        }

        /// <summary>
        /// Clear the dictionary
        /// </summary>
        /// <param name="serializeChanges">save changes?</param>
        public static void Clear(bool serializeChanges = true)
        {
            CreatedAlarms.Clear();

            OnClearAlarms?.Invoke();

            if (serializeChanges)
                Serialize();
        }

        /// <summary>
        /// Make sure the json is written indented for the grader to view
        /// </summary>
        /// <returns>returns the json serializer options</returns>
        private static JsonSerializerOptions GetJsonDocInfo()
        {

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true; // easier for the grader to read the json file

            return options;
        }

        /// <summary>
        /// Update an existing alarm
        /// </summary>
        /// <remarks>
        ///  Used after the user finished editing an existing alarm, or snoozed the alarm for example. 
        /// </remarks>
        /// <param name="oldAlarm">the old alarm</param>
        /// <param name="newAlarm">the new alarm</param>
        public static void Update(Alarm oldAlarm, Alarm newAlarm)
        {
            string id = oldAlarm.AlarmID;

            var resultAlarm = new Alarm(id, newAlarm.SetAlarmTime, newAlarm.State, newAlarm.AlarmCreated);

            Delete(oldAlarm, false);
            Create(resultAlarm, false);

            Serialize();
        }

        /// <summary>
        /// Initalize the factory
        /// </summary>
        public static void Initialize()
        {
            Deserialize();
        }

        /// <summary>
        /// Delete the file where the alarm clocks are being saved
        /// </summary>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static void RemoveFile()
        {
            if (!Directory.Exists(_directory))
                throw new DirectoryNotFoundException($"Cannot find the downloads folder to store the alarms persistantly ({_directory})");

            if(File.Exists(_saveFilePath))
            {
                File.Delete(_saveFilePath);
            }
        }

        /// <summary>
        /// Serialize the changes
        /// </summary>
        /// <exception cref="DirectoryNotFoundException">cannot find the downloads directory</exception>
        private static void Serialize()
        {

            string jsonStr = JsonSerializer.Serialize(CreatedAlarms, GetJsonDocInfo());

            if (!Directory.Exists(_directory))
                throw new DirectoryNotFoundException($"Cannot find the downloads folder to store the alarms persistantly ({_directory})");

            if (File.Exists(_saveFilePath))
                File.Delete(_saveFilePath);

            using (Stream str = File.Create(_saveFilePath))
            {
                using (StreamWriter writer = new StreamWriter(str))
                {
                    writer.Write(jsonStr);
                }
            }

        }

        /// <summary>
        /// Deserialize the file (if it exists) otherwise create a new dictionary
        /// </summary>
        /// <exception cref="DirectoryNotFoundException">thrown when the donwloads directory is not found</exception>
        private static void Deserialize()
        {
            if (!Directory.Exists(_directory))
                throw new DirectoryNotFoundException($"Cannot find the downloads folder to store the alarms persistantly ({_directory})");

            StringBuilder jsonBuilder = new StringBuilder();

            using (StreamReader reader = new StreamReader(File.Open(_saveFilePath, FileMode.Open)))
            {
                while (!reader.EndOfStream)
                {
                    jsonBuilder.AppendLine(reader.ReadLine());
                }
            }

            if (jsonBuilder.Length > 0)
            {
                var alarms = JsonSerializer.Deserialize<Dictionary<string, Alarm>>(jsonBuilder.ToString(), GetJsonDocInfo());

                if (alarms != null)
                {
                    CreatedAlarms = alarms;
                    return;
                }
            }

            CreatedAlarms = new Dictionary<string, Alarm>();
        }
    }
}
