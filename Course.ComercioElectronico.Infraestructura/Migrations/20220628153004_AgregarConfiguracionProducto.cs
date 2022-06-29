using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.ComercioElectronico.Infraestructura.Migrations
{
    public partial class AgregarConfiguracionProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandId",
                table: "Product",
                type: "nvarchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductTypeId",
                table: "Product",
                type: "nvarchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                table: "Product",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BrandId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Product");
        }
    }
}
