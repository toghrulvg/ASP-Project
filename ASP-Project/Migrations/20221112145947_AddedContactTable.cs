using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_Project.Migrations
{
    public partial class AddedContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ContactUs = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    WorkingTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
