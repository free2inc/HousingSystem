using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class some : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Area", "BuildingId", "CreatedDate", "Floor", "ModifiedDate", "NumberOfRooms" },
                values: new object[,]
                {
                    { 1, 100f, 1, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9907), 1, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9915), 3 },
                    { 2, 100f, 1, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9919), 2, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9920), 3 },
                    { 3, 100f, 1, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9922), 3, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9923), 3 },
                    { 4, 50f, 2, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9925), 4, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9926), 1 },
                    { 5, 120f, 3, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9927), 1, new DateTime(2021, 9, 19, 19, 38, 18, 106, DateTimeKind.Local).AddTicks(9928), 4 }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "CityAdminBuildingId", "CreatedDate", "District", "Floors", "ModifiedDate", "Number" },
                values: new object[,]
                {
                    { 1, "Some address 1", 101, new DateTime(2021, 9, 19, 19, 38, 18, 104, DateTimeKind.Local).AddTicks(9745), "Some dist 1", 3, new DateTime(2021, 9, 19, 19, 38, 18, 105, DateTimeKind.Local).AddTicks(8335), "8D" },
                    { 2, "Some address 2", 102, new DateTime(2021, 9, 19, 19, 38, 18, 105, DateTimeKind.Local).AddTicks(9180), "Some dist 2", 4, new DateTime(2021, 9, 19, 19, 38, 18, 105, DateTimeKind.Local).AddTicks(9186), "8D" },
                    { 3, "Some address 3", 101, new DateTime(2021, 9, 19, 19, 38, 18, 105, DateTimeKind.Local).AddTicks(9188), "Some dist 3", 1, new DateTime(2021, 9, 19, 19, 38, 18, 105, DateTimeKind.Local).AddTicks(9189), "89" },
                    { 4, "Some address 4", 101, new DateTime(2021, 9, 19, 19, 38, 18, 105, DateTimeKind.Local).AddTicks(9192), "Some dist 4", 3, new DateTime(2021, 9, 19, 19, 38, 18, 105, DateTimeKind.Local).AddTicks(9193), "15A" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
