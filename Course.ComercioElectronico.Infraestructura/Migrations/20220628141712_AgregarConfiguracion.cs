using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.ComercioElectronico.Infraestructura.Migrations
{
    public partial class AgregarConfiguracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductType");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProductType",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductType",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Code");

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductType");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductType",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");
        }
    }
}
