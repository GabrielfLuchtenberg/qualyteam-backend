using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentsApi.Migrations
{
    public partial class document3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Documents_DocumentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DocumentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Categories");

            migrationBuilder.AddColumn<long>(
                name: "DocumentCategoryCategoryId",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DocumentCategoryDocumentId",
                table: "Documents",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentCategory",
                columns: table => new
                {
                    DocumentId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategory", x => new { x.DocumentId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_DocumentCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentCategory_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentCategoryDocumentId_DocumentCategoryCategoryId",
                table: "Documents",
                columns: new[] { "DocumentCategoryDocumentId", "DocumentCategoryCategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentCategory_CategoryId",
                table: "DocumentCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentCategory_DocumentCategoryDocumentId_DocumentCategoryCategoryId",
                table: "Documents",
                columns: new[] { "DocumentCategoryDocumentId", "DocumentCategoryCategoryId" },
                principalTable: "DocumentCategory",
                principalColumns: new[] { "DocumentId", "CategoryId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentCategory_DocumentCategoryDocumentId_DocumentCategoryCategoryId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentCategory");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentCategoryDocumentId_DocumentCategoryCategoryId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentCategoryCategoryId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentCategoryDocumentId",
                table: "Documents");

            migrationBuilder.AddColumn<long>(
                name: "DocumentId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DocumentId",
                table: "Categories",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Documents_DocumentId",
                table: "Categories",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
