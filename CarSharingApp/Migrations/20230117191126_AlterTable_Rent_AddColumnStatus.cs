using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharingApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableRentAddColumnStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rents");
        }
    }
}
