using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TitanicWeather.Models;

namespace RestClient
{
    /// <summary>
    /// Class with get and post methods for the Rest API
    /// </summary>
    public class Worker
    {
        public async Task<int> GetCommand()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await
                    client.GetAsync("https://titanicweatherapi.azurewebsites.net/api/Titanic/Command");
                int _command = await
                    response.Content.ReadFromJsonAsync<int>();
                return _command;
            }
        }

        public async Task<int> GetHeatingLevel()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await
                    client.GetAsync("https://titanicweatherapi.azurewebsites.net/api/Titanic/HeatingLevel");
                int _heatingLevel = await
                    response.Content.ReadFromJsonAsync<int>();
                return _heatingLevel;
            }
        }

        public async Task<string> GetIconName()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await
                    client.GetAsync("https://titanicweatherapi.azurewebsites.net/api/Titanic/PiIcon");
                string iconName = await
                    response.Content.ReadAsStringAsync();
                return iconName;
            }
        }

        public async Task PostCommand(Command _command)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent serializedCommand = JsonContent.Create(_command);
                HttpResponseMessage response = await
                    client.PostAsync("https://titanicweatherapi.azurewebsites.net/api/Titanic/SetCommand", serializedCommand);
            }
        }
        //Used in UDP Server
        public async Task PostHeatingLevel(HeatingLevel _heatingLevel)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent serializedCommand = JsonContent.Create(_heatingLevel);
                HttpResponseMessage response = await
                    client.PostAsync("https://titanicweatherapi.azurewebsites.net/api/Titanic/SetHeatingLevel", serializedCommand);
            }
        }
    }
}