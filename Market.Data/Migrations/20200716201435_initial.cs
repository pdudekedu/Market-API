using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Market.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASSETS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSETS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROPERTIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROPERTIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROPERTIES_VALUES",
                columns: table => new
                {
                    ASSETID = table.Column<int>(nullable: false),
                    PROPERTYID = table.Column<int>(nullable: false),
                    VALUE = table.Column<bool>(nullable: false, defaultValue: false),
                    TIMESTAMP = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROPERTIES_VALUES", x => new { x.ASSETID, x.PROPERTYID });
                    table.ForeignKey(
                        name: "FK_PROPERTIES_VALUES_ASSETS",
                        column: x => x.ASSETID,
                        principalTable: "ASSETS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROPERTIES_VALUES_PROPERTIES",
                        column: x => x.PROPERTYID,
                        principalTable: "PROPERTIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTIES_VALUES_PROPERTYID",
                table: "PROPERTIES_VALUES",
                column: "PROPERTYID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROPERTIES_VALUES");

            migrationBuilder.DropTable(
                name: "ASSETS");

            migrationBuilder.DropTable(
                name: "PROPERTIES");
        }
    }
}
