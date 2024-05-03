using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LK_Searcher.Migrations
{
    /// <inheritdoc />
    public partial class dellAuthorPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Authors",
                type: "text",
                nullable: true);
        }
    }
}
