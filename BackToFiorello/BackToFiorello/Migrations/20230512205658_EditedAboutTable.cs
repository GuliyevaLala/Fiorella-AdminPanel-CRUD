using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackToFiorello.Migrations
{
    public partial class EditedAboutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Expert",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Expert");
        }
    }
}
