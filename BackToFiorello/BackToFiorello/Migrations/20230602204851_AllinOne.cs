using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackToFiorello.Migrations
{
    public partial class AllinOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, "HeaderLogo", "logo.png" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 2, "Phone", "7456834857634" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 3, "Email", "fiorello@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
