using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Persistence.Migrations
{
    public partial class newRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a746c47a-da6d-45ad-910f-257aad147375",
                column: "ConcurrencyStamp",
                value: "809cb97f-998c-4403-b732-48bca5d20691");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "a746c47a-da6d-45ad-910f-257aad147376", "42a9435f-b69a-466b-885c-0dab6d6b0759", "ApplicationRole", "user", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a746c47a-da6d-45ad-910f-257aad147375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e57decc0-0923-45e1-86d0-c695f878fe12", "AQAAAAEAACcQAAAAEFimV3O3DKjfh6CpdjZW8TUgrDNmtoDRWoG87HxlKx9bHfx12LmJHT20TGqGIUugkw==", "c09bf372-f3e5-4d78-88fc-f9be17c29bde" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a746c47a-da6d-45ad-910f-257aad147376", "a746c47a-da6d-45ad-910f-257aad147375" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a746c47a-da6d-45ad-910f-257aad147376", "a746c47a-da6d-45ad-910f-257aad147375" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a746c47a-da6d-45ad-910f-257aad147376");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a746c47a-da6d-45ad-910f-257aad147375",
                column: "ConcurrencyStamp",
                value: "b83a327e-ecd0-4665-a11d-99dc5ff0abb5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a746c47a-da6d-45ad-910f-257aad147375",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6b674cc-ea78-4e87-b67d-c4a0052ecf98", "AQAAAAEAACcQAAAAECnoJ1NrdaxphKLbP9O1qMdpgplUZjeLrwxKgdALf2E7cTxxKUP2k4b4pkXTZSFy7A==", "2a804ccb-ef5f-4e34-8ffe-6281419df383" });
        }
    }
}
