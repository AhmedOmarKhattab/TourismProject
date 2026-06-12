using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism_Project.Migrations
{
    /// <inheritdoc />
    public partial class FixBookingBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hotel",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "travelmethod",
                table: "Trips");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hotel",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "travelmethod",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
