using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibyanaHub.Services.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0435a3e5-1ff9-4dbb-83c2-ab22379f9c83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11b2ba47-c330-471c-849d-ca61ff6d153c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e0cfdc9-1936-4e9e-adae-368d50a07f48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b55aeee7-695d-41cb-bc62-cd3cf536b960");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeaa4875-0e74-44d3-a4bd-9a12f2e31481");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e2183e1-f32b-4668-9725-e99f33362de3", null, "Trainee", "TRAINEE" },
                    { "c858ed84-5f93-4dc1-bac7-39c1aa63d962", null, "Commercial", "COMMERCIAL" },
                    { "d1a88340-953c-4cd5-b34b-28eef78b8da8", null, "Admin", "ADMIN" },
                    { "ddebc901-d223-4dfa-afdc-0a9aaa6f4915", null, "Employee", "EMPLOYEE" },
                    { "ec550e44-affe-4150-b68d-618a303bc0cf", null, "Coach", "COACH" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e2183e1-f32b-4668-9725-e99f33362de3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c858ed84-5f93-4dc1-bac7-39c1aa63d962");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1a88340-953c-4cd5-b34b-28eef78b8da8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddebc901-d223-4dfa-afdc-0a9aaa6f4915");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec550e44-affe-4150-b68d-618a303bc0cf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0435a3e5-1ff9-4dbb-83c2-ab22379f9c83", null, "Admin", "ADMIN" },
                    { "11b2ba47-c330-471c-849d-ca61ff6d153c", null, "Commercial", "COMMERCIAL" },
                    { "7e0cfdc9-1936-4e9e-adae-368d50a07f48", null, "Trainee", "TRAINEE" },
                    { "b55aeee7-695d-41cb-bc62-cd3cf536b960", null, "Employee", "EMPLOYEE" },
                    { "eeaa4875-0e74-44d3-a4bd-9a12f2e31481", null, "Coach", "COACH" }
                });
        }
    }
}
