using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TitanicWeather.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? Pressure { get; set; }
    }
}
