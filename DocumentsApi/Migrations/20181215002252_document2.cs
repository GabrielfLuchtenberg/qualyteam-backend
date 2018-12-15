using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentsApi.Migrations
{
    public partial class document2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DocumentId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DocumentId",
                table: "Categories",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DepartmentId",
                table: "Documents",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Documents_DocumentId",
                table: "Categories",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Documents_DocumentId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DocumentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Categories");
        }
    }
}
