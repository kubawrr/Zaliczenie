using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Many2Manyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerShippingCountry_Computers_ComputerId",
                table: "ComputerShippingCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_ComputerShippingCountry_ShippingCountries_ShippingId",
                table: "ComputerShippingCountry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComputerShippingCountry",
                table: "ComputerShippingCountry");

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

            migrationBuilder.RenameTable(
                name: "ComputerShippingCountry",
                newName: "ComputerShippingCountries");

            migrationBuilder.RenameIndex(
                name: "IX_ComputerShippingCountry_ComputerId",
                table: "ComputerShippingCountries",
                newName: "IX_ComputerShippingCountries_ComputerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComputerShippingCountries",
                table: "ComputerShippingCountries",
                columns: new[] { "ShippingId", "ComputerId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f55b630-fb5e-4fda-b2cd-faa13b0710ca", "6f55b630-fb5e-4fda-b2cd-faa13b0710ca", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da2174ba-f691-4736-9f70-33d69f707c4f", 0, "ca64649e-bad0-4031-a807-dd7f8cc57826", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFSbhNECnMoC6WK+VEAj6E+IGUpXMuhKuRt1o7aWKPf7fh8xNmZrmcLU4fUEFgV6Jg==", null, false, "a9350ee7-5222-4e89-b55f-ad870331dc10", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6f55b630-fb5e-4fda-b2cd-faa13b0710ca", "da2174ba-f691-4736-9f70-33d69f707c4f" });

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerShippingCountries_Computers_ComputerId",
                table: "ComputerShippingCountries",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerShippingCountries_ShippingCountries_ShippingId",
                table: "ComputerShippingCountries",
                column: "ShippingId",
                principalTable: "ShippingCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerShippingCountries_Computers_ComputerId",
                table: "ComputerShippingCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_ComputerShippingCountries_ShippingCountries_ShippingId",
                table: "ComputerShippingCountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComputerShippingCountries",
                table: "ComputerShippingCountries");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6f55b630-fb5e-4fda-b2cd-faa13b0710ca", "da2174ba-f691-4736-9f70-33d69f707c4f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f55b630-fb5e-4fda-b2cd-faa13b0710ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da2174ba-f691-4736-9f70-33d69f707c4f");

            migrationBuilder.RenameTable(
                name: "ComputerShippingCountries",
                newName: "ComputerShippingCountry");

            migrationBuilder.RenameIndex(
                name: "IX_ComputerShippingCountries_ComputerId",
                table: "ComputerShippingCountry",
                newName: "IX_ComputerShippingCountry_ComputerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComputerShippingCountry",
                table: "ComputerShippingCountry",
                columns: new[] { "ShippingId", "ComputerId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerShippingCountry_Computers_ComputerId",
                table: "ComputerShippingCountry",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerShippingCountry_ShippingCountries_ShippingId",
                table: "ComputerShippingCountry",
                column: "ShippingId",
                principalTable: "ShippingCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
