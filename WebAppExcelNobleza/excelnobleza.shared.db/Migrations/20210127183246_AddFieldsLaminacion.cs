using Microsoft.EntityFrameworkCore.Migrations;

namespace excelnobleza.shared.db.Migrations
{
    public partial class AddFieldsLaminacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lam_ElemDos",
                table: "vc_procesos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lam_ElemTrilam",
                table: "vc_procesos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lam_ElemUno",
                table: "vc_procesos",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Manga_A",
                table: "vc_parametros",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Manga_TL",
                table: "vc_parametros",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Manga_UA",
                table: "vc_parametros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lam_ElemDos",
                table: "vc_procesos");

            migrationBuilder.DropColumn(
                name: "Lam_ElemTrilam",
                table: "vc_procesos");

            migrationBuilder.DropColumn(
                name: "Lam_ElemUno",
                table: "vc_procesos");

            migrationBuilder.DropColumn(
                name: "Manga_A",
                table: "vc_parametros");

            migrationBuilder.DropColumn(
                name: "Manga_TL",
                table: "vc_parametros");

            migrationBuilder.DropColumn(
                name: "Manga_UA",
                table: "vc_parametros");
        }
    }
}
