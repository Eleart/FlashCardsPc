using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCardsPc.Migrations
{
    /// <inheritdoc />
    public partial class AddIsRectoSide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRectoSide",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRectoSide",
                table: "Cards");
        }
    }
}
