using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class ChangedForeignKeyToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleLog_Battles_BattleForeignKey",
                table: "BattleLog");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiForeignKey",
                table: "SecretIdentity");

            migrationBuilder.RenameColumn(
                name: "SamuraiForeignKey",
                table: "SecretIdentity",
                newName: "SamuraiId");

            migrationBuilder.RenameIndex(
                name: "IX_SecretIdentity_SamuraiForeignKey",
                table: "SecretIdentity",
                newName: "IX_SecretIdentity_SamuraiId");

            migrationBuilder.RenameColumn(
                name: "BattleForeignKey",
                table: "BattleLog",
                newName: "BattleId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleLog_BattleForeignKey",
                table: "BattleLog",
                newName: "IX_BattleLog_BattleId");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Quotes",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLog_Battles_BattleId",
                table: "BattleLog",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleLog_Battles_BattleId",
                table: "BattleLog");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Quotes");

            migrationBuilder.RenameColumn(
                name: "SamuraiId",
                table: "SecretIdentity",
                newName: "SamuraiForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentity",
                newName: "IX_SecretIdentity_SamuraiForeignKey");

            migrationBuilder.RenameColumn(
                name: "BattleId",
                table: "BattleLog",
                newName: "BattleForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_BattleLog_BattleId",
                table: "BattleLog",
                newName: "IX_BattleLog_BattleForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLog_Battles_BattleForeignKey",
                table: "BattleLog",
                column: "BattleForeignKey",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiForeignKey",
                table: "SecretIdentity",
                column: "SamuraiForeignKey",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
