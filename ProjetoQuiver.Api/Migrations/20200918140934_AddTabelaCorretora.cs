using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoQuiver.Api.Migrations
{
    public partial class AddTabelaCorretora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorretoraId",
                table: "Contato",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Corretora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 15, nullable: false),
                    Password = table.Column<string>(maxLength: 15, nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corretora", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contato_CorretoraId",
                table: "Contato",
                column: "CorretoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Corretora_CorretoraId",
                table: "Contato",
                column: "CorretoraId",
                principalTable: "Corretora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Corretora_CorretoraId",
                table: "Contato");

            migrationBuilder.DropTable(
                name: "Corretora");

            migrationBuilder.DropIndex(
                name: "IX_Contato_CorretoraId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "CorretoraId",
                table: "Contato");
        }
    }
}
