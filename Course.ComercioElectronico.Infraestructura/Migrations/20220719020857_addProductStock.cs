using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.ComercioElectronico.Infraestructura.Migrations
{
    public partial class addProductStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Product");
        }
    }
}
