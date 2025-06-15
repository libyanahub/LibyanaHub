using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibyanaHub.Services.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserId_to_BaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserDomains",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Trainees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TraineeCertificates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FitnessCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CourseCompletions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CoachSpecializations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CoachSocialLinks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CoachExperiences",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Coaches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CoachCertificates",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDomains");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TraineeCertificates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FitnessCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CourseCompletions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoachSpecializations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoachSocialLinks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoachExperiences");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoachCertificates");
        }
    }
}
