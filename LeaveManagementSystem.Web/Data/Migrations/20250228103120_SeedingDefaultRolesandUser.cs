using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LeaveTypes",
                type: "nvarchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d429a03-d2df-4ddf-9a0d-1b07dc9735ce", null, "Employee", "EMPLOYEE" },
                    { "a063c476-9046-455c-89a6-79c6d3ed0e4c", null, "Supervisor", "SUPERVISOR" },
                    { "a6b6297c-917c-41ad-8e9b-8e737e3667a1", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ec85b359-72d3-49d6-aa1e-45893c685e5c", 0, "da3f8160-dd6e-423f-ae9e-3023fef13873", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEI+vOJFPj67vVy7lHbKSeN74qwQo8Q9FE9Qpbgevrdiobp+L88XADLyJLPh0WsC2bg==", null, false, "4ded202c-afd3-4ef0-9fea-0086b7186648", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a6b6297c-917c-41ad-8e9b-8e737e3667a1", "ec85b359-72d3-49d6-aa1e-45893c685e5c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d429a03-d2df-4ddf-9a0d-1b07dc9735ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a063c476-9046-455c-89a6-79c6d3ed0e4c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a6b6297c-917c-41ad-8e9b-8e737e3667a1", "ec85b359-72d3-49d6-aa1e-45893c685e5c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b6297c-917c-41ad-8e9b-8e737e3667a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec85b359-72d3-49d6-aa1e-45893c685e5c");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LeaveTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)");
        }
    }
}
