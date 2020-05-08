﻿// <auto-generated />
using System;
using Assignment3_NGK.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment3_NGK.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200508150152_ThirdMigration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment3_NGK.Model.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.Property<double>("lon")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaceId");

                    b.ToTable("Place");

                    b.HasData(
                        new
                        {
                            PlaceId = 1,
                            lat = 56.159999999999997,
                            lon = 10.199999999999999,
                            name = "Aarhus"
                        });
                });

            modelBuilder.Entity("Assignment3_NGK.Model.Weather", b =>
                {
                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

                    b.Property<double>("AirPressure")
                        .HasColumnType("float");

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("PlaceId", "Time");

                    b.ToTable("Weather");

                    b.HasData(
                        new
                        {
                            PlaceId = 1,
                            Time = new DateTime(2020, 4, 27, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            AirPressure = 1013.25,
                            Humidity = 40,
                            Temperature = 30.0
                        },
                        new
                        {
                            PlaceId = 1,
                            Time = new DateTime(2020, 4, 27, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            AirPressure = 1013.9,
                            Humidity = 46,
                            Temperature = 28.0
                        },
                        new
                        {
                            PlaceId = 1,
                            Time = new DateTime(2020, 4, 27, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            AirPressure = 1014.1,
                            Humidity = 50,
                            Temperature = 22.0
                        },
                        new
                        {
                            PlaceId = 1,
                            Time = new DateTime(2020, 4, 27, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            AirPressure = 1013.5,
                            Humidity = 55,
                            Temperature = 20.0
                        });
                });

            modelBuilder.Entity("Assignment3_NGK.Model.Weather", b =>
                {
                    b.HasOne("Assignment3_NGK.Model.Place", "Place")
                        .WithMany("Weathers")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}