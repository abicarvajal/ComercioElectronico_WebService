using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.ComercioElectronico.Infraestructura.Migrations
{
    public partial class AgregarCamposAuditoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ProductType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Brand",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Brand");
        }
    }
}
