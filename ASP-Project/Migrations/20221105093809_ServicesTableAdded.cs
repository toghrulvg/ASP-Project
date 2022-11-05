using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_Project.Migrations
{
    public partial class ServicesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Slider",
                table: "Slider");

            migrationBuilder.RenameTable(
                name: "Slider",
                newName: "Sliders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders");

            migrationBuilder.RenameTable(
                name: "Sliders",
                newName: "Slider");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slider",
                table: "Slider",
                column: "Id");
        }
    }
}
