using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_NGK.Model
{
    public class Place
    {
        [Required]
        public int PlaceId { get; set; }
        public string name { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }

        public List<Weather> Weathers { get; set; }
    }
}
