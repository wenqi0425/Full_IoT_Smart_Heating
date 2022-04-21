using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanicWeather.Managers;
using TitanicWeather.Models;
using TitanicWeather.TitanicContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TitanicWeather.Controllers
{
    /// <summary>
    /// This is a controller for the titanic application
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TitanicController : ControllerBase
    {
        private readonly TitanicManagerDB _manager;
        private readonly TitanicManager _localManager;

        /// <summary>
        /// This is the constructor for the controller that takes no parameters
        /// </summary>
        public TitanicController()
        {
            _manager = new TitanicManagerDB();
            _localManager = new TitanicManager();
        }


        //This is probably redundant and since we are on the end of the project we don't want to delete it to not break anything.
        [HttpGet]
        public IActionResult OnGet()
        {
            return RedirectToPage("/index.html");
        }

        /// <summary>
        /// This method gets the most recent measurement out of the database
        /// </summary>
        /// <returns>The most recent measurement</returns>
        // GET: api/Titanic/Recent
        [HttpGet("Recent")]
        public Measurement GetRecentMeasurement()
        {
            return _manager.GetLastMeasurement();
        }

        /// <summary>
        /// This method gets all the measurements that have been made and stored in the database
        /// </summary>
        /// <returns>A list of all the measurements that are saved in the database</returns>
        // GET: api/Titanic/All
        [HttpGet("All")]
        public IEnumerable<Measurement> GetAllMeasurements()
        {
            return _manager.GetAllMeasurements();
        }

        /// <summary>
        /// This method is used to get the command that the web application sends so it knows what to do according to the command
        /// that is passed
        /// </summary>
        /// <returns>The received command</returns>
        // GET: api/Titanic/Command
        [HttpGet("Command")]
        public int GetCommand()
        {
            return _localManager.GetCommand();
        }
        
        /// <summary>
        /// Gets the heating level that the web application sends
        /// </summary>
        /// <returns>The received heating level</returns>
        // GET: api/Titanic/HeatingLevel
        [HttpGet("HeatingLevel")]
        public int GetHeatingLevel()
        {
            return _localManager.GetHeatingLevel();
        }

        /// <summary>
        /// Gets the last week of data that is stored in the database
        /// </summary>
        /// <returns>a list of data of the last week</returns>
        // GET: api/Titanic/SummarizedData
        [HttpGet("SummarizedData")]
        public IEnumerable<SummarizedData> GetSummarizedData()
        {
            return _manager.GetSummarizedData();
        }
        

        /// <summary>
        /// Gets the icon that the web application sends in order to be able to show the right icon on the Pi
        /// </summary>
        /// <returns>The received icon which is a string</returns>
        // GET: api/Titanic/PiIcon
        [HttpGet("PiIcon")]
        public string GetPiIcon()
        {
            return _localManager.GetPiIcon();
        }


        /// <summary>
        /// Used to set the command on the web application
        /// </summary>
        /// <param name="command">The command that should be send</param>
        // POST api/Titanic/SetCommand
        [HttpPost("SetCommand")]
        public void PostCommand([FromBody] Command command)
        {
            _localManager.SetCommand(command.integer);
        }

        /// <summary>
        /// Used to set the heating level on the web application
        /// </summary>
        /// <param name="heatingLevel">The heating level that should be send</param>
        // POST api/Titanic/SetHeatingLevel
        [HttpPost("SetHeatingLevel")]
        public void PostHeatingLevel([FromBody] HeatingLevel heatingLevel)
        {
            _localManager.SetHeatingLevel(heatingLevel.integer);
        }

        /// <summary>
        /// Used to post the icon to the web application
        /// </summary>
        /// <param name="piIcon">The pi icon</param>
        // POST api/Titanic/SetPiIcon
        [HttpPost("SetPiIcon")]
        public void PostPiIcon([FromBody] PiIcon piIcon)
        {
            _localManager.SetPiIcon(piIcon.iconName);
        }
    }
}
