using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TitanicWeather.Models;

namespace RestClient
{
    public class Program
    {
        private static string _msg  { get; set; }

        static void Main(string[] args)
        {
            //Initialization
            Console.WriteLine("Starting");
            Worker _worker = new Worker();

            //Receive loop
            while (true)
            {
                Task.Run(() => ReceiveLoop(_worker));
                Task.Run(() => ReceiveIcon(_worker));
                Thread.Sleep(5000);
            }
        }

        /// <summary>
        /// UDP broadcaster.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="port"></param>
        public static void SendMessage(string message, int port)
        {
            //send data to the server
            byte[] data = Encoding.UTF8.GetBytes(message);
            UdpClient socket = new UdpClient();
            socket.Send(data, data.Length, "255.255.255.255", port);
        }

        /// <summary>
        /// Getting command from Rest API, resetting it and sending to Pi.
        /// </summary>
        /// <param name="worker"></param>
        public async static void ReceiveLoop(Worker worker)
        {
            int command = worker.GetCommand().Result;
            int heatingLevel = worker.GetHeatingLevel().Result;
            
            //Resetting the command to -1
            await worker.PostCommand(new Command() { integer = -1 });

            //Sending to Pi
            if (command >= 0 && command <= 2)
            {
                Console.WriteLine($"Sending {command} and {heatingLevel} to Pi");
                SendMessage(command.ToString() + " " + heatingLevel.ToString(), 5005);
            }
        }
        /// <summary>
        /// Checks if the received icon is different from the one stored in the static instance field.
        /// </summary>
        /// <param name="worker"></param>
        public async static void ReceiveIcon(Worker worker)
        {
            string iconName = worker.GetIconName().Result;

            //Sending to Pi
            if (iconName != _msg)
            {
                Console.WriteLine($"Sending {iconName} to Pi");
                _msg = iconName;
                SendMessage(IconCheck(iconName), 5006);
            }
        }
        /// <summary>
        /// Checks the name of string parameter and changes it to be compatible with Pi scripts.
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        public static string IconCheck(string iconName)
        {
            string msg = "Something went wrong buddy";

            if (iconName.Contains("clear") || iconName.Contains("fair"))
            {
                msg = "sun";
            }

            if (iconName.Contains("cloudy"))
            {
                msg = "cloudy";
            }

            if (iconName.Contains("fog"))
            {
                msg = "fog";
            }

            if (iconName.Contains("sleet"))
            {
                msg= "sleet";
            }

            if (iconName.Contains("rain"))
            {
                if (iconName.Contains("thunder"))
                {
                    msg = "storm";
                }
                else
                {
                    msg = "rain";
                }
            }
            
            if (iconName.Contains("snow"))
            {
                if (iconName.Contains("thunder"))
                {
                    msg = "snowstorm";
                }
                else
                {
                    msg = "snow";
                }
            }
            return msg;
        }
        
    }
}
