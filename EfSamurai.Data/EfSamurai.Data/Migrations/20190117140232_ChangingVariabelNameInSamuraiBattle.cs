using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class ChangingVariabelNameInSamuraiBattle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.DropIndex(
                name: "IX_SamuraiBattle_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropColumn(
                name: "SamuraId",
                table: "SamuraiBattle");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "SamuraiBattle",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "SamuraiId", "BattleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "SamuraiBattle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SamuraId",
                table: "SamuraiBattle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "SamuraId", "BattleId" });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattle_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId");

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
