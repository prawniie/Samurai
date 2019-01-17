using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class ChangedVariabelInBattleEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "BattleEvent");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfEvent",
                table: "BattleEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOfEvent",
                table: "BattleEvent");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "BattleEvent",
                nullable: false,
                defaultValue: 0);
        }
    }
}
