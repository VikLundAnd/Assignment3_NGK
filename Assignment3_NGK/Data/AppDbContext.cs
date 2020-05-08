using Assignment3_NGK.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_NGK.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Place> Place { get; set; }
        public DbSet<Weather> Weather { get; set; }
       

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Composite key
            mb.Entity<Weather>()
                .HasKey(w => new { w.PlaceId, w.Time });

            mb.Entity<Place>()
                .HasData(new Place
                {
                    PlaceId = 1,
                    name = "Aarhus",
                    lat = 56.16,
                    lon = 10.20
                });

            mb.Entity<Weather>()
                .HasData(new Weather {
                    // Date: 27/04-2020 15:00
                    Time = new DateTime(2020, 4, 27,15,0,0,0),
                    AirPressure = 1013.25,
                    Humidity = 40,
                    Temperature = 30,
                    PlaceId = 1 // Aahus
                },
                new Weather
                {
                    // Date: 27/04-2020 16:00
                    Time = new DateTime(2020, 4, 27, 16, 0, 0, 0),
                    AirPressure = 1013.9,
                    Humidity = 46,
                    Temperature = 28,
                    PlaceId = 1 // Aahus
                },
                new Weather
                {
                    // Date: 27/04-2020 17:00
                    Time = new DateTime(2020, 4, 27, 17, 0, 0, 0),
                    AirPressure = 1014.1,
                    Humidity = 50,
                    Temperature = 22,
                    PlaceId = 1 // Aahus
                    
                },
                new Weather
                {
                    // Date: 27/04-2020 18:00
                    Time = new DateTime(2020, 4, 27, 18, 0, 0, 0),
                    AirPressure = 1013.5,
                    Humidity = 55,
                    Temperature = 20,
                    PlaceId = 1 // Aahus

                });


            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WeatherForecastDatabase;Integrated Security=True").EnableSensitiveDataLogging();
    }
}
