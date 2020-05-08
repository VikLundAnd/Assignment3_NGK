using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_NGK.Model
{
    public class Weather
    {
        //public int WeatherId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Time { get; set; }

        public Place Place { get; set; }
        public int PlaceId { get; set; }

        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double AirPressure { get; set; }

    }
}
