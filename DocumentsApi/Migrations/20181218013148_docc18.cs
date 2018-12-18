using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentsApi.Migrations
{
    public partial class docc18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Departments_DepartmentId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentCategory");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Documents",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_DepartmentId",
                table: "Documents",
                newName: "IX_Documents_CategoryId");

            migrationBuilder.CreateTable(
                name: "DocumentDepartment",
                columns: table => new
                {
                    DocumentId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDepartment", x => new { x.DocumentId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_DocumentDepartment_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentDepartment_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDepartment_DepartmentId",
                table: "DocumentDepartment",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Categories_CategoryId",
                table: "Documents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Categories_CategoryId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentDepartment");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Documents",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_CategoryId",
                table: "Documents",
                newName: "IX_Documents_DepartmentId");

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
                name: "IX_DocumentCategory_CategoryId",
                table: "DocumentCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Departments_DepartmentId",
                table: "Documents",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
