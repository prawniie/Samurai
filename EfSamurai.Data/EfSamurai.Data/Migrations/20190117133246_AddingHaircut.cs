using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class AddingHaircut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HaircutId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Haircut",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haircut", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HaircutId",
                table: "Samurais",
                column: "HaircutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Haircut_HaircutId",
                table: "Samurais",
                column: "HaircutId",
                principalTable: "Haircut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Haircut_HaircutId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "Haircut");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_HaircutId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "HaircutId",
                table: "Samurais");
        }
    }
}
