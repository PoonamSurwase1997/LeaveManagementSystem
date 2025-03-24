using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec85b359-72d3-49d6-aa1e-45893c685e5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6f8915c-831a-4ea4-ad1f-a148ddedc86e", "AQAAAAIAAYagAAAAENirNC7yFE9cT2RrkVbz17rspkq0oIEnk3yMO8H1f3kgnWTJMwvWYz1RGYP6euCiOw==", "beebdfed-549b-4243-b1bc-d0c3ae2adad7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec85b359-72d3-49d6-aa1e-45893c685e5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5d1bc87-4c5c-4f2e-8ef6-9864b1fd6a9c", "AQAAAAIAAYagAAAAEMFRELIGk9TzqsMNOioZ43sRIp7Jvxrfli6cfIPadlEelIasRiOntX+sQ95NA2VzwA==", "393f67ef-8402-496c-967c-3ccff8424397" });
        }
    }
}
