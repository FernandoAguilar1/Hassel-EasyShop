using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyShop.Data.Migrations
{
    public partial class InitialSeed_UserNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89917e95-490f-4569-bde5-3698125e14a5", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ede5fdc0-1298-40f6-a826-5dae1f8500a1", "2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcfd7fe6-2200-4a35-b2d8-b4e7d6ad74b7", 0, "ca26c837-eb42-4166-be2d-7ceae70ae211", "admin@easyshop.com", true, false, null, "ADMIN@EASYSHOP.COM", "ADMIN@EASYSHOP.COM", "AQAAAAEAACcQAAAAEG3OKM0a7ut+PWx1KaMf6rEUPo5CIvxapNGh/r2lXUO4bUyn+WQCiTLqWySrJbdShg==", null, false, "ab7cbc77-dec0-44f3-a148-ea630a0a5a9d", false, "admin@easyshop.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "89917e95-490f-4569-bde5-3698125e14a5", "bcfd7fe6-2200-4a35-b2d8-b4e7d6ad74b7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ede5fdc0-1298-40f6-a826-5dae1f8500a1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "89917e95-490f-4569-bde5-3698125e14a5", "bcfd7fe6-2200-4a35-b2d8-b4e7d6ad74b7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89917e95-490f-4569-bde5-3698125e14a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcfd7fe6-2200-4a35-b2d8-b4e7d6ad74b7");

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
    }
}
