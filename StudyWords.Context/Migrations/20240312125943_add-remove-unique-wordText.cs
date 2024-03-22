using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyWords.Context.Migrations
{
    /// <inheritdoc />
    public partial class addremoveuniquewordText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Word_WordText",
                table: "Word");

            migrationBuilder.AlterColumn<string>(
                name: "WordText",
                table: "Word",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WordText",
                table: "Word",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Word_WordText",
                table: "Word",
                column: "WordText",
                unique: true);
        }
    }
}
