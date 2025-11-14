using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCardsPc.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionForVersoRecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionForRecto",
                table: "Cards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionForVerso",
                table: "Cards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionForRecto",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "QuestionForVerso",
                table: "Cards");
        }
    }
}
