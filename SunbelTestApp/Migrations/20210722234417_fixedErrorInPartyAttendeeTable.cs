using Microsoft.EntityFrameworkCore.Migrations;

namespace SunbeltTestApp.Migrations
{
    public partial class fixedErrorInPartyAttendeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartyAttendees_People_PersonId",
                table: "PartyAttendees");

            migrationBuilder.DropColumn(
                name: "AttendeeId",
                table: "PartyAttendees");

            migrationBuilder.AlterColumn<long>(
                name: "PersonId",
                table: "PartyAttendees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartyAttendees_People_PersonId",
                table: "PartyAttendees",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartyAttendees_People_PersonId",
                table: "PartyAttendees");

            migrationBuilder.AlterColumn<long>(
                name: "PersonId",
                table: "PartyAttendees",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AttendeeId",
                table: "PartyAttendees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_PartyAttendees_People_PersonId",
                table: "PartyAttendees",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
