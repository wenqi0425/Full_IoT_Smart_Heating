using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TitanicWeather.Models
{
    /// <summary>
    /// Model for summarizing data for the day.
    /// </summary>
    public class SummarizedData
    {
        public DateTime Date { get; set; }
        public decimal MaxTemp { get; set; }
        public decimal MinTemp { get; set; }
        public decimal MaxHumid { get; set; }
        public decimal MinHumid { get; set; }
    }
}
