using Microsoft.EntityFrameworkCore.Migrations;

namespace adomany.Data.Migrations
{
    public partial class ketto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raktar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Elnevezes = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Kategoria = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Csomagolas = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Darab = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raktar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raktar");
        }
    }
}
