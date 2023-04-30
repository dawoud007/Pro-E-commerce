using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsShop_service.Migrations
{
    public partial class updateproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 17, 29, 30, DateTimeKind.Local).AddTicks(6991),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 812, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Products",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 17, 29, 26, DateTimeKind.Local).AddTicks(7319),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 808, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 17, 29, 26, DateTimeKind.Local).AddTicks(4952),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 807, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 17, 29, 25, DateTimeKind.Local).AddTicks(8505),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 807, DateTimeKind.Local).AddTicks(5986));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 812, DateTimeKind.Local).AddTicks(9436),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 17, 29, 30, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 808, DateTimeKind.Local).AddTicks(2367),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 17, 29, 26, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 807, DateTimeKind.Local).AddTicks(9723),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 17, 29, 26, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 5, 11, 26, 807, DateTimeKind.Local).AddTicks(5986),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 30, 5, 17, 29, 25, DateTimeKind.Local).AddTicks(8505));
        }
    }
}
