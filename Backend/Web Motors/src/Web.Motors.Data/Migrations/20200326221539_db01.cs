using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Motors.Data.Migrations
{
    public partial class db01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_AnuncioWebmotors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(maxLength: 45, nullable: false),
                    Modelo = table.Column<string>(maxLength: 45, nullable: false),
                    Versao = table.Column<string>(maxLength: 45, nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Quilometragem = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AnuncioWebmotors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_AnuncioWebmotors");
        }
    }
}
