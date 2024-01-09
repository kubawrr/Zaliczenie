using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ManyToMany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3f8d4f00-7733-40fa-861f-ad698966fdee", "17ba694c-386c-42a5-aa20-5caa52e7023b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8d4f00-7733-40fa-861f-ad698966fdee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17ba694c-386c-42a5-aa20-5caa52e7023b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f555983e-e404-4fb5-af81-fddd303ca3c9", "f555983e-e404-4fb5-af81-fddd303ca3c9", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99a053ae-3fb2-4692-a97c-feccd472b3ea", 0, "85f83826-bc60-4d4d-819d-48dcc727044c", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEEt1OjtAl+Weoe0OTbv9DOS7pqe5hrECC+Nu3e/HB9A8qUOYVZAJxiUbGkYzgTGb5g==", null, false, "90b6e8b7-da19-4a59-8574-ff7274a7bef1", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f555983e-e404-4fb5-af81-fddd303ca3c9", "99a053ae-3fb2-4692-a97c-feccd472b3ea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f555983e-e404-4fb5-af81-fddd303ca3c9", "99a053ae-3fb2-4692-a97c-feccd472b3ea" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f555983e-e404-4fb5-af81-fddd303ca3c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99a053ae-3fb2-4692-a97c-feccd472b3ea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f8d4f00-7733-40fa-861f-ad698966fdee", "3f8d4f00-7733-40fa-861f-ad698966fdee", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "17ba694c-386c-42a5-aa20-5caa52e7023b", 0, "0f9f3f47-1bc3-4575-b187-bce0bc30950b", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEL6iRjK1uFpwC8foHWaI169+9ZLzNhwG+UA1kSLgkR7+ryw7L7p5AWrtToODAS4Sdg==", null, false, "601d283b-d5d7-4269-a570-2233edf9926c", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3f8d4f00-7733-40fa-861f-ad698966fdee", "17ba694c-386c-42a5-aa20-5caa52e7023b" });
        }
    }
}
