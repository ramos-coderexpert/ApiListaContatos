using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIListaContatos.Migrations
{
    public partial class PopulaTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "Idade", "Nome", "Sexo" },
                values: new object[] { 1, 20, "Fernando", "Masculino" });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "Idade", "Nome", "Sexo" },
                values: new object[] { 2, 30, "Carlos", "Masculino" });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "Idade", "Nome", "Sexo" },
                values: new object[] { 3, 23, "Roberta", "Feminino" });

            migrationBuilder.InsertData(
                table: "Contatos",
                columns: new[] { "ContatoId", "Conteudo", "Nome", "PessoaId" },
                values: new object[] { 1, "11946574829", "Telefone", 1 });

            migrationBuilder.InsertData(
                table: "Contatos",
                columns: new[] { "ContatoId", "Conteudo", "Nome", "PessoaId" },
                values: new object[] { 2, "carlos.augusto@gmail.com", "Email", 2 });

            migrationBuilder.InsertData(
                table: "Contatos",
                columns: new[] { "ContatoId", "Conteudo", "Nome", "PessoaId" },
                values: new object[] { 3, "11966935487", "Whatsapp", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contatos",
                keyColumn: "ContatoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contatos",
                keyColumn: "ContatoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contatos",
                keyColumn: "ContatoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pessoas",
                keyColumn: "PessoaId",
                keyValue: 3);
        }
    }
}
