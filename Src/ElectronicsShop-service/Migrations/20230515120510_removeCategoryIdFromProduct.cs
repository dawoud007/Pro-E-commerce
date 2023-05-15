using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsShop_service.Migrations
{
    public partial class removeCategoryIdFromProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "Products",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryID",
                table: "Products",
                newName: "IX_Products_categoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 14, 5, 10, 335, DateTimeKind.Local).AddTicks(6931),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 15, 14, 23, 49, 59, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 14, 5, 10, 327, DateTimeKind.Local).AddTicks(7829),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 15, 14, 23, 49, 55, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 14, 5, 10, 327, DateTimeKind.Local).AddTicks(4726),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 15, 14, 23, 49, 54, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 14, 5, 10, 326, DateTimeKind.Local).AddTicks(8135),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 15, 14, 23, 49, 54, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Products",
                newName: "categoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                newName: "IX_Products_categoryID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 14, 23, 49, 59, DateTimeKind.Local).AddTicks(6681),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 15, 14, 5, 10, 335, DateTimeKind.Local).AddTicks(6931));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 14, 23, 49, 55, DateTimeKind.Local).AddTicks(1198),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 15, 14, 5, 10, 327, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 14, 23, 49, 54, DateTimeKind.Local).AddTicks(7648),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 15, 14, 5, 10, 327, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 14, 23, 49, 54, DateTimeKind.Local).AddTicks(1950),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 15, 14, 5, 10, 326, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryID",
                table: "Products",
                column: "categoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
