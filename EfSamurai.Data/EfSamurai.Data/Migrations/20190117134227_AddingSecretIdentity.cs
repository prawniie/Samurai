using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class AddingSecretIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quote_Samurais_SamuraiId",
                table: "Quote");

            migrationBuilder.DropForeignKey(
                name: "FK_Quote_QuoteType_TypeId",
                table: "Quote");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Haircut_HaircutId",
                table: "Samurais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteType",
                table: "QuoteType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quote",
                table: "Quote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Haircut",
                table: "Haircut");

            migrationBuilder.RenameTable(
                name: "QuoteType",
                newName: "QuoteTypes");

            migrationBuilder.RenameTable(
                name: "Quote",
                newName: "Quotes");

            migrationBuilder.RenameTable(
                name: "Haircut",
                newName: "Haircuts");

            migrationBuilder.RenameIndex(
                name: "IX_Quote_TypeId",
                table: "Quotes",
                newName: "IX_Quotes_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Quote_SamuraiId",
                table: "Quotes",
                newName: "IX_Quotes_SamuraiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteTypes",
                table: "QuoteTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quotes",
                table: "Quotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Haircuts",
                table: "Haircuts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SecretIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SamuraiForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentity_Samurais_SamuraiForeignKey",
                        column: x => x.SamuraiForeignKey,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentity_SamuraiForeignKey",
                table: "SecretIdentity",
                column: "SamuraiForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Samurais_SamuraiId",
                table: "Quotes",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteTypes_TypeId",
                table: "Quotes",
                column: "TypeId",
                principalTable: "QuoteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Haircuts_HaircutId",
                table: "Samurais",
                column: "HaircutId",
                principalTable: "Haircuts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Samurais_SamuraiId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteTypes_TypeId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Haircuts_HaircutId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteTypes",
                table: "QuoteTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quotes",
                table: "Quotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Haircuts",
                table: "Haircuts");

            migrationBuilder.RenameTable(
                name: "QuoteTypes",
                newName: "QuoteType");

            migrationBuilder.RenameTable(
                name: "Quotes",
                newName: "Quote");

            migrationBuilder.RenameTable(
                name: "Haircuts",
                newName: "Haircut");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_TypeId",
                table: "Quote",
                newName: "IX_Quote_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_SamuraiId",
                table: "Quote",
                newName: "IX_Quote_SamuraiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteType",
                table: "QuoteType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quote",
                table: "Quote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Haircut",
                table: "Haircut",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_Samurais_SamuraiId",
                table: "Quote",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_QuoteType_TypeId",
                table: "Quote",
                column: "TypeId",
                principalTable: "QuoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Haircut_HaircutId",
                table: "Samurais",
                column: "HaircutId",
                principalTable: "Haircut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
