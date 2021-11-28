using Microsoft.EntityFrameworkCore.Migrations;

namespace Blazor.Migrations
{
    public partial class addedAdultsDBSET : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adult_Families_FamilyId",
                table: "Adult");

            migrationBuilder.DropForeignKey(
                name: "FK_Adult_Job_JobId",
                table: "Adult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adult",
                table: "Adult");

            migrationBuilder.RenameTable(
                name: "Adult",
                newName: "Adults");

            migrationBuilder.RenameIndex(
                name: "IX_Adult_JobId",
                table: "Adults",
                newName: "IX_Adults_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Adult_FamilyId",
                table: "Adults",
                newName: "IX_Adults_FamilyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adults",
                table: "Adults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Families_FamilyId",
                table: "Adults",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "FamilyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Job_JobId",
                table: "Adults",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Families_FamilyId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Job_JobId",
                table: "Adults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adults",
                table: "Adults");

            migrationBuilder.RenameTable(
                name: "Adults",
                newName: "Adult");

            migrationBuilder.RenameIndex(
                name: "IX_Adults_JobId",
                table: "Adult",
                newName: "IX_Adult_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Adults_FamilyId",
                table: "Adult",
                newName: "IX_Adult_FamilyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adult",
                table: "Adult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adult_Families_FamilyId",
                table: "Adult",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "FamilyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adult_Job_JobId",
                table: "Adult",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
