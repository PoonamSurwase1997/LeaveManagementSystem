using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec85b359-72d3-49d6-aa1e-45893c685e5c",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateOnly(1997, 12, 12), "7401c41f-1aad-439e-b253-b16bf451cb80", "Default", "Admin", "AQAAAAIAAYagAAAAELcWeUI/FrYimPY0jfO4CN7+rz2YqiVB54hNfR5TnGmxCK26ZLwJrykVelS69Frxag==", "5ab87afe-c915-47db-ab73-943334b3b8bb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec85b359-72d3-49d6-aa1e-45893c685e5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da3f8160-dd6e-423f-ae9e-3023fef13873", "AQAAAAIAAYagAAAAEI+vOJFPj67vVy7lHbKSeN74qwQo8Q9FE9Qpbgevrdiobp+L88XADLyJLPh0WsC2bg==", "4ded202c-afd3-4ef0-9fea-0086b7186648" });
        }
    }
}
