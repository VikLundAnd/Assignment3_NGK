using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3_NGK.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "PlaceId", "Time", "AirPressure", "Humidity", "Temperature" },
                values: new object[] { 1, new DateTime(2020, 4, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), 1013.5, 55, 20.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Weather",
                keyColumns: new[] { "PlaceId", "Time" },
                keyValues: new object[] { 1, new DateTime(2020, 4, 27, 18, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
