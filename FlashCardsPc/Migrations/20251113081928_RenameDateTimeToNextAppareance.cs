using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCardsPc.Migrations
{
    /// <inheritdoc />
    public partial class RenameDateTimeToNextAppareance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Cards",
                newName: "NextAppareance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextAppareance",
                table: "Cards",
                newName: "DateTime");
        }
    }
}
