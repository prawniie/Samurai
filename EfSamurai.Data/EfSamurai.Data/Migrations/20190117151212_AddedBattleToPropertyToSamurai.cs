using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class AddedBattleToPropertyToSamurai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SamuraiId",
                table: "Battles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Battles_SamuraiId",
                table: "Battles",
                column: "SamuraiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Samurais_SamuraiId",
                table: "Battles",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Samurais_SamuraiId",
                table: "Battles");

            migrationBuilder.DropIndex(
                name: "IX_Battles_SamuraiId",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "SamuraiId",
                table: "Battles");
        }
    }
}
