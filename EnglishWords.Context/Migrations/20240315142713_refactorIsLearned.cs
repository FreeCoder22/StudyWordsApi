using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishWords.Context.Migrations
{
    /// <inheritdoc />
    public partial class refactorIsLearned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLearning",
                table: "Word",
                newName: "IsLearned");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLearned",
                table: "Word",
                newName: "IsLearning");
        }
    }
}
