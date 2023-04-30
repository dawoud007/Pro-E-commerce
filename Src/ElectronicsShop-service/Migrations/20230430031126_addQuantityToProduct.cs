using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsShop_service.Migrations
{
    public partial class addQuantityToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 812, DateTimeKind.Local).AddTicks(9436),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 25, 23, 26, 30, 557, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 808, DateTimeKind.Local).AddTicks(2367),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 25, 23, 26, 30, 552, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 807, DateTimeKind.Local).AddTicks(9723),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 25, 23, 26, 30, 552, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 807, DateTimeKind.Local).AddTicks(5986),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 25, 23, 26, 30, 552, DateTimeKind.Local).AddTicks(87));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 23, 26, 30, 557, DateTimeKind.Local).AddTicks(9321),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 812, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 23, 26, 30, 552, DateTimeKind.Local).AddTicks(6601),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 808, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 23, 26, 30, 552, DateTimeKind.Local).AddTicks(4382),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 807, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 23, 26, 30, 552, DateTimeKind.Local).AddTicks(87),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 807, DateTimeKind.Local).AddTicks(5986));
        }
    }
}
