using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3_NGK.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    lat = table.Column<double>(nullable: false),
                    lon = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlaceId = table.Column<int>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    AirPressure = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => new { x.PlaceId, x.Time });
                    table.ForeignKey(
                        name: "FK_Weather_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "PlaceId", "lat", "lon", "name" },
                values: new object[] { 1, 56.159999999999997, 10.199999999999999, "Aarhus" });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "PlaceId", "Time", "AirPressure", "Humidity", "Temperature" },
                values: new object[] { 1, new DateTime(2020, 4, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), 1013.25, 40, 30.0 });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "PlaceId", "Time", "AirPressure", "Humidity", "Temperature" },
                values: new object[] { 1, new DateTime(2020, 4, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), 1013.9, 46, 28.0 });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "PlaceId", "Time", "AirPressure", "Humidity", "Temperature" },
                values: new object[] { 1, new DateTime(2020, 4, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 1014.1, 50, 22.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Place");
        }
    }
}
