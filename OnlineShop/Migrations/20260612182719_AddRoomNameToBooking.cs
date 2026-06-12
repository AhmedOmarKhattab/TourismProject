using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomNameToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "bookings");
        }
    }
}
