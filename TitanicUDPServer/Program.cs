using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Globalization;
using TitanicWeather.Models;
using TitanicWeather.Managers;
using TitanicWeather.TitanicContext;
using TitanicWeather;
using RestClient;

namespace TitanicUDPServer
{
    public static class Program
    {
        private static TitanicManagerDB managerDB = new TitanicManagerDB();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Titanic UDP Server");
            //initialize
            UdpClient socket = new UdpClient();
            socket.Client.Bind(new IPEndPoint(IPAddress.Any, 65000));
            Worker _worker = new Worker();

            while (true)
            {
                //receieve data
                IPEndPoint from = null;
                byte[] data = socket.Receive(ref from);

                string dataString = Encoding.UTF8.GetString(data);
                string[] measArray = dataString.Split(',');

                Console.WriteLine("Received from Sense Hat: " + dataString /*+ " - " + from.Address*/);

                Measurement newMeasure = new Measurement()
                {
                    DateAndTime = DateTime.Now,
                    Temperature = Math.Round(decimal.Parse(measArray[0], CultureInfo.InvariantCulture), 1),
                    Humidity = Math.Round(decimal.Parse(measArray[1], CultureInfo.InvariantCulture), 1),
                    Pressure = Math.Round(decimal.Parse(measArray[2], CultureInfo.InvariantCulture), 1)
                };
                AddMeasurementToDB(newMeasure);
                PostHeatingLevel(_worker, int.Parse(measArray[3]));
            }
        }

        public static void AddMeasurementToDB(Measurement measurement)
        {
            managerDB.Add(measurement);
        }

        /// <summary>
        /// Calls the worker's post method if the Pi didn't send a signal not to.
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="_integer"></param>
        public static void PostHeatingLevel(Worker worker, int _integer)
        {
            //-1 is the case if we run the script in Pi manually, so we don't want to update the heating level 
            if (_integer != -1)
            {
                worker.PostHeatingLevel(new HeatingLevel() { integer = _integer });
            }
        }
        
    }
}
