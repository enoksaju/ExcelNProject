using Microsoft.EntityFrameworkCore.Migrations;

namespace excelnobleza.shared.db.Migrations
{
    public partial class ComentariosParametros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "vc_parametros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "vc_parametros");
        }
    }
}
