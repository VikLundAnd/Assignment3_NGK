using Assignment3_NGK.Controllers;
using Assignment3_NGK.Data;
using Assignment3_NGK.Model;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment3.Test.Unit
{
    [TestFixture]
    public class ControllerTest
    {
        WeatherForecastController _uut;
        ILogger<WeatherForecastController> _logger;



        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<WeatherForecastController>>();
            _uut = new WeatherForecastController(_logger);
        }

        [Test]
        public void Get_ValidParameters_ContainsThreeValues()
        {
            var response = _uut.Get();

            Assert.AreEqual(response.Count, 3);
        }

        [Test]
        public void Get_ValidParameters_OrderedByDescending()
        {
            var response = _uut.Get().ToList();

            Assert.That(response[0].Time > response[1].Time && response[1].Time > response[2].Time);
        }

        [TestCase("2020-04-27")]
        [TestCase("1800-01-01")]
        [TestCase("2200-12-31")]
        public void GetSpecificDate_ValidParameters_ContainsOnlySpecificDate(string time)
        {
            //var weatherSeed = new Weather()
            //{
            //    AirPressure = 20,
            //    Humidity = 60,
            //    Temperature = 20,
            //    Time = DateTime.Parse(time)
            //};

            //int placeid;

            //using (var context = new AppDbContext())
            //{
            //    if (context.Place.Count() != 0) placeid = context.Place.First().PlaceId;
            //    else
            //    {
            //        placeid = 1;
            //        var place = new Place()
            //        {
            //            lat = 99,
            //            lon = 99,
            //            name = "GenericName",
            //            PlaceId = placeid,
            //        };
            //        context.Add(place);
            //    }

            //    weatherSeed.PlaceId = placeid;
            //    context.Add(weatherSeed);
            //}

            var response = _uut.Get(time).ToList();

            Assert.That(response.Where(r => r.Time.Date == DateTime.Parse(time)).Count() == response.Count);
        }
    }
}