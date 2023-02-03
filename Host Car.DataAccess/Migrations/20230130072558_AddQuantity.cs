using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Host_Car.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarQuantity",
                table: "CarDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CarStatus",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarQuantity",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "CarStatus",
                table: "CarDetails");
        }
    }
}
