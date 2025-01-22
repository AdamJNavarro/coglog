using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CogLog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrainBlocks",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variant = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainBlocks", x => x.Id);
                }
            );

            migrationBuilder.InsertData(
                table: "BrainBlocks",
                columns: new[]
                {
                    "Id",
                    "AdditionalContext",
                    "Content",
                    "DateAdded",
                    "Title",
                    "Url",
                    "Variant",
                },
                values: new object[,]
                {
                    {
                        1,
                        "adjective",
                        "having a rosy complexion of the face.",
                        new DateTime(2024, 11, 5, 7, 30, 0, 0, DateTimeKind.Unspecified),
                        "Rubicund",
                        "",
                        0,
                    },
                    {
                        2,
                        "adjective",
                        "having or showing great knowledge.",
                        new DateTime(2024, 11, 12, 7, 30, 0, 0, DateTimeKind.Unspecified),
                        "Erudite",
                        "",
                        0,
                    },
                    {
                        3,
                        "noun",
                        "A rectangular stepped tower found in ancient Mesopotamia.",
                        new DateTime(2024, 11, 23, 7, 30, 0, 0, DateTimeKind.Unspecified),
                        "Ziggurat",
                        "",
                        0,
                    },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "BrainBlocks");
        }
    }
}
