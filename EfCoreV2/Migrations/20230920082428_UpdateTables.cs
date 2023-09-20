using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreV2.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImage_Blogs_BlogId",
                table: "BlogImage");

            migrationBuilder.RenameColumn(
                name: "Captio",
                table: "BlogImage",
                newName: "Caption");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "BlogImage",
                newName: "BlogFk");

            migrationBuilder.RenameIndex(
                name: "IX_BlogImage_BlogId",
                table: "BlogImage",
                newName: "IX_BlogImage_BlogFk");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImage_Blogs_BlogFk",
                table: "BlogImage",
                column: "BlogFk",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImage_Blogs_BlogFk",
                table: "BlogImage");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "BlogImage",
                newName: "Captio");

            migrationBuilder.RenameColumn(
                name: "BlogFk",
                table: "BlogImage",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogImage_BlogFk",
                table: "BlogImage",
                newName: "IX_BlogImage_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImage_Blogs_BlogId",
                table: "BlogImage",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
