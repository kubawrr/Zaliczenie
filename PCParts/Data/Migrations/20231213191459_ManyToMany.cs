using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a60e7b0-4b90-42bd-845d-e92e0e626e7a", "712442d7-9448-4100-9282-9846641eaaf2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a60e7b0-4b90-42bd-845d-e92e0e626e7a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "712442d7-9448-4100-9282-9846641eaaf2");

            migrationBuilder.CreateTable(
                name: "ShippingCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerShippingCountry",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShippingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerShippingCountry", x => new { x.ShippingId, x.ComputerId });
                    table.ForeignKey(
                        name: "FK_ComputerShippingCountry_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerShippingCountry_ShippingCountries_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "ShippingCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f8d4f00-7733-40fa-861f-ad698966fdee", "3f8d4f00-7733-40fa-861f-ad698966fdee", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "17ba694c-386c-42a5-aa20-5caa52e7023b", 0, "0f9f3f47-1bc3-4575-b187-bce0bc30950b", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEL6iRjK1uFpwC8foHWaI169+9ZLzNhwG+UA1kSLgkR7+ryw7L7p5AWrtToODAS4Sdg==", null, false, "601d283b-d5d7-4269-a570-2233edf9926c", false, "admin" });

            migrationBuilder.InsertData(
                table: "ShippingCountries",
                columns: new[] { "Id", "CountryName" },
                values: new object[] { 1, "Poland" });

            migrationBuilder.InsertData(
                table: "ShippingCountries",
                columns: new[] { "Id", "CountryName" },
                values: new object[] { 2, "Germany" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3f8d4f00-7733-40fa-861f-ad698966fdee", "17ba694c-386c-42a5-aa20-5caa52e7023b" });

            migrationBuilder.InsertData(
                table: "ComputerShippingCountry",
                columns: new[] { "ComputerId", "ShippingId", "Id" },
                values: new object[] { 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "ComputerShippingCountry",
                columns: new[] { "ComputerId", "ShippingId", "Id" },
                values: new object[] { 2, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerShippingCountry_ComputerId",
                table: "ComputerShippingCountry",
                column: "ComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerShippingCountry");

            migrationBuilder.DropTable(
                name: "ShippingCountries");

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
                values: new object[] { "5a60e7b0-4b90-42bd-845d-e92e0e626e7a", "5a60e7b0-4b90-42bd-845d-e92e0e626e7a", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "712442d7-9448-4100-9282-9846641eaaf2", 0, "7dd0028d-f544-4bb9-9e4b-88562d64b3e3", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPiBSAND/8Bkk7pOGqbMkeqKAHmM/T+GM+JFRWx68POiB2Blqs/x8Y1+9xZKHU3vgQ==", null, false, "a8392828-3625-4d1f-8121-9fae5bb71ed5", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5a60e7b0-4b90-42bd-845d-e92e0e626e7a", "712442d7-9448-4100-9282-9846641eaaf2" });
        }
    }
}
