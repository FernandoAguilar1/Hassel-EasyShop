using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyShop.Data.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "362f35ab-99c8-4036-be9d-c8a3ab61f104", "2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "798f6da7-3c62-40da-b74f-0412a2eb7863", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "141d1dd2-be65-41be-ae47-7e96ea47bc2c", 0, "5f458e53-8438-4733-ac80-80f0e1ebf907", "admin@easyshop.com", true, false, null, "ADMIN@EASYSHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEF9lEw2V7EgGv4TMCZMfbMZBh2cIZhmnTM9HL+Wg55vUnHk+VrjR4kjNgpk/HSKhRg==", null, false, "0dc93ed6-a9fa-4e84-9a4b-a5a5afbc6869", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "798f6da7-3c62-40da-b74f-0412a2eb7863", "141d1dd2-be65-41be-ae47-7e96ea47bc2c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "362f35ab-99c8-4036-be9d-c8a3ab61f104");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "798f6da7-3c62-40da-b74f-0412a2eb7863", "141d1dd2-be65-41be-ae47-7e96ea47bc2c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798f6da7-3c62-40da-b74f-0412a2eb7863");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "141d1dd2-be65-41be-ae47-7e96ea47bc2c");
        }
    }
}
