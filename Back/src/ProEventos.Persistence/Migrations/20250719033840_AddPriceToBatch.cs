using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEventos.Persistence.Migrations
{
    public partial class AddPriceToBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Batchs",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Batchs");
        }
    }
}
