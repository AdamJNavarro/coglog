using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CogLog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "BrainBlocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BrainBlocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TopicId",
                value: null);

            migrationBuilder.UpdateData(
                table: "BrainBlocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TopicId",
                value: null);

            migrationBuilder.UpdateData(
                table: "BrainBlocks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TopicId",
                value: null);

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Logo", "Title" },
                values: new object[,]
                {
                    { 1, "💻", "Coding" },
                    { 2, "🇯🇵", "Japanese" },
                    { 3, "📖", "Words" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrainBlocks_TopicId",
                table: "BrainBlocks",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_Title",
                table: "Topics",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BrainBlocks_Topics_TopicId",
                table: "BrainBlocks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrainBlocks_Topics_TopicId",
                table: "BrainBlocks");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_BrainBlocks_TopicId",
                table: "BrainBlocks");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "BrainBlocks");
        }
    }
}
