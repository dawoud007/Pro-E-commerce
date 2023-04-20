using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsShop_service.Migrations
{
    public partial class updateModelsCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 126, DateTimeKind.Local).AddTicks(1979),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 37, 28, 765, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "Products",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(8835),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 37, 28, 762, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(6304),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 37, 28, 762, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 114, DateTimeKind.Local).AddTicks(5596),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 37, 28, 759, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 37, 28, 765, DateTimeKind.Local).AddTicks(351),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 126, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "Products",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 37, 28, 762, DateTimeKind.Local).AddTicks(4131),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 37, 28, 762, DateTimeKind.Local).AddTicks(3222),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 37, 28, 759, DateTimeKind.Local).AddTicks(6239),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 114, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
