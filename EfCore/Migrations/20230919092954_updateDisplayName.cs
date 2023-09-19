using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore.Migrations
{
    public partial class updateDisplayName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Author",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                computedColumnSql: "[FirstName] + ',' + [LastName]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Author");
        }
    }
}
