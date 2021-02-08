using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventGenerator
{
    public enum SensorType { NotSet = 0, Temperature = 3, SPO2 = 1, Pulse = 3, Diastolic = 5, Systolic = 4, RespiratoryRate = 2 }

    public class SensorReading
    {
        public SensorType VitalId { get; set; }
        public float Value { get; set; }
    }

    public class SensorReadings : List<SensorReading>
    {
    }

    public class DeviceMessage
    {
        public DeviceMessage()
        {
            CreatedOn = new DateTime();
            sensors = new SensorReadings();
        }

        public string Id { get; set; }
        public string Patientid { get; set; }
        public DateTime CreatedOn { get; set; }

        /*public double Temperature { get; set; }
        public double SPO2 { get; set; }
        public int Pulse { get; set; }
        public int MinBloodPressure { get; set; }
        public int MaxBloodPressure { get; set; }
        public int RespiratoryRate { get; set; }*/


        public SensorReadings sensors { get; set; }
    }
}
