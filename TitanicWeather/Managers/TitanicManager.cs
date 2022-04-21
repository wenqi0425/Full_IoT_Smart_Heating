using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TitanicWeather.Managers
{
    /// <summary>
    /// Class with methods used in the Rest API.
    /// </summary>
    public class TitanicManager
    {
        private static int _command = -1;
        private static int _heatingLevel = 0;
        private static string _piIcon = "";

        public void SetCommand(int com)
        {
            _command = com;
        }
        public void SetHeatingLevel(int heat)
        {
            _heatingLevel = heat;
        }
        public void SetPiIcon(string piIcon)
        {
            _piIcon = piIcon;
        }

        public int GetCommand()
        {
            return _command;
        }

        public int GetHeatingLevel()
        {
            return _heatingLevel;
        }
        public string GetPiIcon()
        {
            return _piIcon;
        }      
    }
}
