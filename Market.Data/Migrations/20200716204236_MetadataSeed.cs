using Microsoft.EntityFrameworkCore.Migrations;

namespace Market.Migrations
{
    public partial class MetadataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ASSETS",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Asset 1" },
                    { 2, "Asset 2" },
                    { 3, "Asset 3" },
                    { 4, "Asset 4" },
                    { 5, "Asset 5" },
                    { 6, "Asset 6" },
                    { 7, "Asset 7" },
                    { 8, "Asset 8" },
                    { 9, "Asset 9" }
                });

            migrationBuilder.InsertData(
                table: "PROPERTIES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "is fix income" },
                    { 2, "is convertible" },
                    { 3, "is swap" },
                    { 4, "is cash" },
                    { 5, "is future" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PROPERTIES",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PROPERTIES",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PROPERTIES",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PROPERTIES",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PROPERTIES",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
