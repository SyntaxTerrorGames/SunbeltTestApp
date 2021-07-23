using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SunbeltTestApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.DrinkId);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    PartyId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeeId);
                    table.ForeignKey(
                        name: "FK_Attendees_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendees_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_DrinkId",
                table: "Attendees",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_PartyId",
                table: "Attendees",
                column: "PartyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}
