using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Reviewer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Content", "Cover", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "Author 1", "Text 1", null, "horror", "Title 1" },
                    { 2, "Author 2", "Text 2", null, "comedy", "Title 2" },
                    { 3, "Author 1", "Text 3", null, "horror", "Title 3" },
                    { 4, "Author 3", "Text 4", null, "fantasy", "Title 4" },
                    { 5, "Author 4", "Text 5", null, "horror", "Title 5" },
                    { 6, "Author 2", "Text 6", null, "historical", "Title 6" },
                    { 7, "Author 5", "Text 7", null, "comedy", "Title 7" },
                    { 8, "Author 5", "Text 8", null, "historical", "Title 8" },
                    { 9, "Author 2", "Text 9", null, "comedy", "Title 9" },
                    { 10, "Author 1", "Text 10", null, "Travel", "Title 10" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "BookId", "Score" },
                values: new object[,]
                {
                    { 1, 1, 5.6m },
                    { 2, 1, 5.6m },
                    { 3, 2, 10m },
                    { 4, 2, 7.3m },
                    { 5, 3, 6.6m },
                    { 6, 3, 5.6m },
                    { 7, 4, 3.2m },
                    { 8, 5, 2m },
                    { 9, 6, 3.2m },
                    { 10, 6, 9.9m },
                    { 11, 7, 8.6m },
                    { 12, 7, 7.6m },
                    { 13, 8, 5.6m },
                    { 14, 8, 5.5m },
                    { 15, 9, 6.6m },
                    { 16, 9, 8.9m },
                    { 17, 10, 10m },
                    { 18, 10, 2.4m }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Message", "Reviewer" },
                values: new object[,]
                {
                    { 1, 1, "message 1", "Reviewer 1" },
                    { 2, 2, "message 2", "Reviewer 2" },
                    { 3, 2, "message 3", "Reviewer 1" },
                    { 4, 1, "message 4", "Reviewer 2" },
                    { 5, 3, "message 5", "Reviewer 3" },
                    { 6, 3, "message 6", "Reviewer 1" },
                    { 7, 4, "message 7", "Reviewer 6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookId",
                table: "Ratings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
