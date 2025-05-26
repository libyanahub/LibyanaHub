using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibyanaHub.Services.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_AspNetUsers_ApplicationUserId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachCertificate_Coach_CoachId",
                table: "CoachCertificate");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachExperience_Coach_CoachId",
                table: "CoachExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachSocialLink_Coach_CoachId",
                table: "CoachSocialLink");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachSpecialization_Coach_CoachId",
                table: "CoachSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachSpecialization_FitnessCategory_FitnessCategoryId",
                table: "CoachSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCompletion_Course_CourseId",
                table: "CourseCompletion");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCompletion_Trainee_TraineeId",
                table: "CourseCompletion");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_AspNetUsers_ApplicationUserId",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCertificate_Trainee_TraineeId",
                table: "TraineeCertificate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDomain_AspNetUsers_ApplicationUserId",
                table: "UserDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDomain",
                table: "UserDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraineeCertificate",
                table: "TraineeCertificate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCategory",
                table: "FitnessCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseCompletion",
                table: "CourseCompletion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachSpecialization",
                table: "CoachSpecialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachSocialLink",
                table: "CoachSocialLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachExperience",
                table: "CoachExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachCertificate",
                table: "CoachCertificate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coach",
                table: "Coach");

            migrationBuilder.RenameTable(
                name: "UserDomain",
                newName: "UserDomains");

            migrationBuilder.RenameTable(
                name: "TraineeCertificate",
                newName: "TraineeCertificates");

            migrationBuilder.RenameTable(
                name: "Trainee",
                newName: "Trainees");

            migrationBuilder.RenameTable(
                name: "FitnessCategory",
                newName: "FitnessCategories");

            migrationBuilder.RenameTable(
                name: "CourseCompletion",
                newName: "CourseCompletions");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "CoachSpecialization",
                newName: "CoachSpecializations");

            migrationBuilder.RenameTable(
                name: "CoachSocialLink",
                newName: "CoachSocialLinks");

            migrationBuilder.RenameTable(
                name: "CoachExperience",
                newName: "CoachExperiences");

            migrationBuilder.RenameTable(
                name: "CoachCertificate",
                newName: "CoachCertificates");

            migrationBuilder.RenameTable(
                name: "Coach",
                newName: "Coaches");

            migrationBuilder.RenameIndex(
                name: "IX_UserDomain_ApplicationUserId",
                table: "UserDomains",
                newName: "IX_UserDomains_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeCertificate_TraineeId",
                table: "TraineeCertificates",
                newName: "IX_TraineeCertificates_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_ApplicationUserId",
                table: "Trainees",
                newName: "IX_Trainees_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseCompletion_TraineeId",
                table: "CourseCompletions",
                newName: "IX_CourseCompletions_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseCompletion_CourseId",
                table: "CourseCompletions",
                newName: "IX_CourseCompletions_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSpecialization_FitnessCategoryId",
                table: "CoachSpecializations",
                newName: "IX_CoachSpecializations_FitnessCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSpecialization_CoachId",
                table: "CoachSpecializations",
                newName: "IX_CoachSpecializations_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSocialLink_CoachId",
                table: "CoachSocialLinks",
                newName: "IX_CoachSocialLinks_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachExperience_CoachId",
                table: "CoachExperiences",
                newName: "IX_CoachExperiences_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachCertificate_CoachId",
                table: "CoachCertificates",
                newName: "IX_CoachCertificates_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_Coach_ApplicationUserId",
                table: "Coaches",
                newName: "IX_Coaches_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDomains",
                table: "UserDomains",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraineeCertificates",
                table: "TraineeCertificates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainees",
                table: "Trainees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCategories",
                table: "FitnessCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseCompletions",
                table: "CourseCompletions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachSpecializations",
                table: "CoachSpecializations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachSocialLinks",
                table: "CoachSocialLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachExperiences",
                table: "CoachExperiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachCertificates",
                table: "CoachCertificates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoachCertificates_Coaches_CoachId",
                table: "CoachCertificates",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_AspNetUsers_ApplicationUserId",
                table: "Coaches",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachExperiences_Coaches_CoachId",
                table: "CoachExperiences",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSocialLinks_Coaches_CoachId",
                table: "CoachSocialLinks",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSpecializations_Coaches_CoachId",
                table: "CoachSpecializations",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSpecializations_FitnessCategories_FitnessCategoryId",
                table: "CoachSpecializations",
                column: "FitnessCategoryId",
                principalTable: "FitnessCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCompletions_Courses_CourseId",
                table: "CourseCompletions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCompletions_Trainees_TraineeId",
                table: "CourseCompletions",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCertificates_Trainees_TraineeId",
                table: "TraineeCertificates",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_AspNetUsers_ApplicationUserId",
                table: "Trainees",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDomains_AspNetUsers_ApplicationUserId",
                table: "UserDomains",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoachCertificates_Coaches_CoachId",
                table: "CoachCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_AspNetUsers_ApplicationUserId",
                table: "Coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachExperiences_Coaches_CoachId",
                table: "CoachExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachSocialLinks_Coaches_CoachId",
                table: "CoachSocialLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachSpecializations_Coaches_CoachId",
                table: "CoachSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachSpecializations_FitnessCategories_FitnessCategoryId",
                table: "CoachSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCompletions_Courses_CourseId",
                table: "CourseCompletions");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCompletions_Trainees_TraineeId",
                table: "CourseCompletions");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCertificates_Trainees_TraineeId",
                table: "TraineeCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_AspNetUsers_ApplicationUserId",
                table: "Trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDomains_AspNetUsers_ApplicationUserId",
                table: "UserDomains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDomains",
                table: "UserDomains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainees",
                table: "Trainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraineeCertificates",
                table: "TraineeCertificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCategories",
                table: "FitnessCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseCompletions",
                table: "CourseCompletions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachSpecializations",
                table: "CoachSpecializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachSocialLinks",
                table: "CoachSocialLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachExperiences",
                table: "CoachExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachCertificates",
                table: "CoachCertificates");

            migrationBuilder.RenameTable(
                name: "UserDomains",
                newName: "UserDomain");

            migrationBuilder.RenameTable(
                name: "Trainees",
                newName: "Trainee");

            migrationBuilder.RenameTable(
                name: "TraineeCertificates",
                newName: "TraineeCertificate");

            migrationBuilder.RenameTable(
                name: "FitnessCategories",
                newName: "FitnessCategory");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "CourseCompletions",
                newName: "CourseCompletion");

            migrationBuilder.RenameTable(
                name: "CoachSpecializations",
                newName: "CoachSpecialization");

            migrationBuilder.RenameTable(
                name: "CoachSocialLinks",
                newName: "CoachSocialLink");

            migrationBuilder.RenameTable(
                name: "CoachExperiences",
                newName: "CoachExperience");

            migrationBuilder.RenameTable(
                name: "Coaches",
                newName: "Coach");

            migrationBuilder.RenameTable(
                name: "CoachCertificates",
                newName: "CoachCertificate");

            migrationBuilder.RenameIndex(
                name: "IX_UserDomains_ApplicationUserId",
                table: "UserDomain",
                newName: "IX_UserDomain_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainees_ApplicationUserId",
                table: "Trainee",
                newName: "IX_Trainee_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeCertificates_TraineeId",
                table: "TraineeCertificate",
                newName: "IX_TraineeCertificate_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseCompletions_TraineeId",
                table: "CourseCompletion",
                newName: "IX_CourseCompletion_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseCompletions_CourseId",
                table: "CourseCompletion",
                newName: "IX_CourseCompletion_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSpecializations_FitnessCategoryId",
                table: "CoachSpecialization",
                newName: "IX_CoachSpecialization_FitnessCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSpecializations_CoachId",
                table: "CoachSpecialization",
                newName: "IX_CoachSpecialization_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSocialLinks_CoachId",
                table: "CoachSocialLink",
                newName: "IX_CoachSocialLink_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachExperiences_CoachId",
                table: "CoachExperience",
                newName: "IX_CoachExperience_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_Coaches_ApplicationUserId",
                table: "Coach",
                newName: "IX_Coach_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachCertificates_CoachId",
                table: "CoachCertificate",
                newName: "IX_CoachCertificate_CoachId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDomain",
                table: "UserDomain",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraineeCertificate",
                table: "TraineeCertificate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCategory",
                table: "FitnessCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseCompletion",
                table: "CourseCompletion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachSpecialization",
                table: "CoachSpecialization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachSocialLink",
                table: "CoachSocialLink",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachExperience",
                table: "CoachExperience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coach",
                table: "Coach",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachCertificate",
                table: "CoachCertificate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_AspNetUsers_ApplicationUserId",
                table: "Coach",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachCertificate_Coach_CoachId",
                table: "CoachCertificate",
                column: "CoachId",
                principalTable: "Coach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachExperience_Coach_CoachId",
                table: "CoachExperience",
                column: "CoachId",
                principalTable: "Coach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSocialLink_Coach_CoachId",
                table: "CoachSocialLink",
                column: "CoachId",
                principalTable: "Coach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSpecialization_Coach_CoachId",
                table: "CoachSpecialization",
                column: "CoachId",
                principalTable: "Coach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSpecialization_FitnessCategory_FitnessCategoryId",
                table: "CoachSpecialization",
                column: "FitnessCategoryId",
                principalTable: "FitnessCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCompletion_Course_CourseId",
                table: "CourseCompletion",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCompletion_Trainee_TraineeId",
                table: "CourseCompletion",
                column: "TraineeId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_AspNetUsers_ApplicationUserId",
                table: "Trainee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCertificate_Trainee_TraineeId",
                table: "TraineeCertificate",
                column: "TraineeId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDomain_AspNetUsers_ApplicationUserId",
                table: "UserDomain",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
