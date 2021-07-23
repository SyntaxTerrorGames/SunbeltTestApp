using Microsoft.EntityFrameworkCore.Migrations;

namespace SunbeltTestApp.Migrations
{
    public partial class addedPartyAttendeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartyAttendees",
                columns: table => new
                {
                    PartyAttendeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyId = table.Column<long>(type: "bigint", nullable: false),
                    AttendeeId = table.Column<long>(type: "bigint", nullable: false),
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyAttendees", x => x.PartyAttendeeId);
                    table.ForeignKey(
                        name: "FK_PartyAttendees_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartyAttendees_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartyAttendees_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartyAttendees_DrinkId",
                table: "PartyAttendees",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyAttendees_PartyId",
                table: "PartyAttendees",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyAttendees_PersonId",
                table: "PartyAttendees",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PartyId",
                table: "People",
                column: "PartyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartyAttendees");

            migrationBuilder.DropTable(
                name: "People");

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
    }
}
