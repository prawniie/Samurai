﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class AddingQuoteType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Quote",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuoteType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quote_TypeId",
                table: "Quote",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_QuoteType_TypeId",
                table: "Quote",
                column: "TypeId",
                principalTable: "QuoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quote_QuoteType_TypeId",
                table: "Quote");

            migrationBuilder.DropTable(
                name: "QuoteType");

            migrationBuilder.DropIndex(
                name: "IX_Quote_TypeId",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Quote");
        }
    }
}
