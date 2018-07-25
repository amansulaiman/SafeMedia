using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SafeMedia.Migrations
{
    public partial class Inintial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HateSpeechReports",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    HateText = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    EvidanceLink = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    Language = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HateSpeechReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HateSpeechReports");
        }
    }
}
