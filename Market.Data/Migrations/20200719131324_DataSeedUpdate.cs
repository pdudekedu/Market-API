using Microsoft.EntityFrameworkCore.Migrations;

namespace Market.Migrations
{
    public partial class DataSeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ASSETS",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 10, "Asset 10" },
                    { 20, "Asset 20" },
                    { 18, "Asset 18" },
                    { 17, "Asset 17" },
                    { 16, "Asset 16" },
                    { 19, "Asset 19" },
                    { 14, "Asset 14" },
                    { 13, "Asset 13" },
                    { 12, "Asset 12" },
                    { 11, "Asset 11" },
                    { 15, "Asset 15" }
                });

            migrationBuilder.InsertData(
                table: "PROPERTIES_VALUES",
                columns: new[] { "ASSETID", "PROPERTYID" },
                values: new object[,]
                {
                    { 7, 2 },
                    { 5, 5 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 5 },
                    { 7, 1 },
                    { 7, 3 },
                    { 8, 4 },
                    { 7, 5 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 },
                    { 5, 4 },
                    { 8, 5 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 7, 4 },
                    { 5, 3 },
                    { 4, 2 },
                    { 5, 1 },
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 5, 2 },
                    { 2, 5 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 1 },
                    { 9, 4 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 3, 1 },
                    { 9, 5 }
                });

            migrationBuilder.InsertData(
                table: "PROPERTIES_VALUES",
                columns: new[] { "ASSETID", "PROPERTYID" },
                values: new object[,]
                {
                    { 10, 1 },
                    { 15, 5 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 3 },
                    { 16, 4 },
                    { 16, 5 },
                    { 17, 1 },
                    { 17, 2 },
                    { 17, 3 },
                    { 17, 4 },
                    { 17, 5 },
                    { 15, 4 },
                    { 18, 1 },
                    { 18, 3 },
                    { 18, 4 },
                    { 18, 5 },
                    { 19, 1 },
                    { 19, 2 },
                    { 19, 3 },
                    { 19, 4 },
                    { 19, 5 },
                    { 20, 1 },
                    { 20, 2 },
                    { 20, 3 },
                    { 18, 2 },
                    { 20, 4 },
                    { 15, 3 },
                    { 15, 1 },
                    { 10, 2 },
                    { 10, 3 },
                    { 10, 4 },
                    { 10, 5 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 4 },
                    { 11, 5 },
                    { 12, 1 },
                    { 12, 2 },
                    { 15, 2 },
                    { 12, 3 },
                    { 12, 5 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 3 },
                    { 13, 4 },
                    { 13, 5 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 3 },
                    { 14, 4 },
                    { 14, 5 },
                    { 12, 4 },
                    { 20, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 16, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 17, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 17, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 18, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 19, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 19, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 19, 5 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 20, 4 });

            migrationBuilder.DeleteData(
                table: "PROPERTIES_VALUES",
                keyColumns: new[] { "ASSETID", "PROPERTYID" },
                keyValues: new object[] { 20, 5 });

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ASSETS",
                keyColumn: "ID",
                keyValue: 20);
        }
    }
}
