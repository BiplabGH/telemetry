using System;
using System.Text;
using System.Threading;
using Microsoft.Azure.EventHubs;

namespace SampleEventGenerator
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    class Program
    {
        private static Guid patient;
        static void Main(string[] args)
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine("*  E V E N T  G E N E R A T O R  *");
            Console.WriteLine("************************************************************");
            Console.WriteLine();
            Console.WriteLine("Press Enter to start the generator.");
            Console.WriteLine("Press Ctrl-C to stop the generator.");
            Console.WriteLine();
            Console.ReadLine();
            Console.Write("Working....");

            patient = Guid.NewGuid();

            var random = new Random();
            var spin = new ConsoleSpiner();

            var eventHubClient = EventHubClient.CreateFromConnectionString("Endpoint=sb://simulator.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=JpwAvSGfHx1/Ic9TRd6DswiLwk2a7irWVUvHtGLk5Zo=;EntityPath=vital");

            while (true)
            {
                spin.Turn();

                try
                {
                    var deviceReading = new DeviceMessage();

                    // beging to create the simulated device message

                    Guid obj = Guid.NewGuid();
                    deviceReading.Id = obj.ToString();

                    deviceReading.Patientid = patient.ToString();

                    // generate simulated sensor readings
                    var temperature = new SensorReading
                    {
                        VitalId = SensorType.Temperature,
                        Value = random.Next(98, 105)
                    };

                    var SPO2 = new SensorReading
                    {
                        VitalId = SensorType.SPO2,
                        Value = random.Next(90, 100)
                    };

                    var pulse = new SensorReading
                    {
                        VitalId = SensorType.Pulse,
                        Value = random.Next(50, 200)
                    };

                    var minBP = new SensorReading
                    {
                        VitalId = SensorType.Diastolic,
                        Value = random.Next(80, 100)
                    };

                    var maxBP = new SensorReading
                    {
                        VitalId = SensorType.Systolic,
                        Value = random.Next(120, 160)
                    };

                    var respRate = new SensorReading
                    {
                        VitalId = SensorType.RespiratoryRate,
                        Value = random.Next(10, 40)
                    };

                    deviceReading.sensors.Add(temperature);
                    deviceReading.sensors.Add(SPO2);
                    deviceReading.sensors.Add(pulse);
                    deviceReading.sensors.Add(minBP);
                    deviceReading.sensors.Add(maxBP);
                    deviceReading.sensors.Add(respRate);

                    deviceReading.CreatedOn = DateTime.Now;

                    // serialize the message to JSON
                    var json = ModelManager.ModelToJson(deviceReading);

                    // send the message to EventHub
                    Console.WriteLine(json);
                    eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(json)));

                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }
                //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.

                Thread.Sleep(2000);
            }
        }
    }
}
