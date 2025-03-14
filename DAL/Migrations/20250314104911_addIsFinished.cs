using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addIsFinished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Questions_CurrentQuestionId",
                table: "Interviews");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentQuestionId",
                table: "Interviews",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Interviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Questions_CurrentQuestionId",
                table: "Interviews",
                column: "CurrentQuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Questions_CurrentQuestionId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Interviews");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentQuestionId",
                table: "Interviews",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Questions_CurrentQuestionId",
                table: "Interviews",
                column: "CurrentQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
