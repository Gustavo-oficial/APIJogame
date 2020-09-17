using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Jogame.Migrations
{
    public partial class AlterTableJogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Jogo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Jogo");
        }
    }
}
