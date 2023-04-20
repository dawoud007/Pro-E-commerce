using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsShop_service.Migrations
{
    public partial class updateModelsProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "categoryID",
                table: "Products",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 46, 35, 487, DateTimeKind.Local).AddTicks(4514),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 126, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 46, 35, 484, DateTimeKind.Local).AddTicks(6150),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 46, 35, 484, DateTimeKind.Local).AddTicks(5275),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 46, 35, 482, DateTimeKind.Local).AddTicks(2735),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 114, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryID",
                table: "Products",
                column: "categoryID",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "status",
                keyValue: null,
                column: "status",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "image",
                keyValue: null,
                column: "image",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "description",
                keyValue: null,
                column: "description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "color",
                keyValue: null,
                column: "color",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "code",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "categoryId",
                table: "Products",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Manufacturer",
                keyValue: null,
                column: "Manufacturer",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 126, DateTimeKind.Local).AddTicks(1979),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 46, 35, 487, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Brand",
                keyValue: null,
                column: "Brand",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(8835),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 46, 35, 484, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(6304),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 46, 35, 484, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Carts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 16, 40, 41, 114, DateTimeKind.Local).AddTicks(5596),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 20, 16, 46, 35, 482, DateTimeKind.Local).AddTicks(2735));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
