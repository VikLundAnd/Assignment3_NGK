using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_NGK.Data;
using Assignment3_NGK.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment3_NGK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        // Get 3 latest uploaded
        [HttpGet]
        public ICollection<Weather> Get()
        {
            var templist = new List<Weather>();
            using (var context = new AppDbContext())
            {

                templist =  context.Weather
                    .OrderByDescending(w => w.Time)
                    .Take(3)
                    .ToList();
            }


            return templist;
        }



        // Get weatherdata for specific date
        [HttpGet("{date}")]
        public ICollection<Weather> Get(string date)
        {
            var templist = new List<Weather>();
            using (var context = new AppDbContext())
            {

                templist = context.Weather
                    .Where(w =>w.Time.Date == DateTime.Parse(date))
                    .ToList();
            }

            return templist;
        }

        // Get weatherdata between dates
        [HttpGet("{dateStart}/{dateEnd}")]
        public ICollection<Weather> Get(string dateStart, string dateEnd)
        {
            var templist = new List<Weather>();
            using (var context = new AppDbContext())
            {

                templist = context.Weather
                    .Where(w => w.Time.Date < DateTime.Parse(dateEnd) && w.Time.Date > DateTime.Parse(dateStart))
                    .ToList();
            }

            return templist;
        }


    }
}
