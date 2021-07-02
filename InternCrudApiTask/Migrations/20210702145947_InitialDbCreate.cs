using Microsoft.EntityFrameworkCore.Migrations;

namespace InternCrudApiTask.Migrations
{
    public partial class InitialDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblColdDrinks",
                columns: table => new
                {
                    intColdDrinksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strColdDrinksName = table.Column<string>(nullable: true),
                    numQuantity = table.Column<decimal>(nullable: false),
                    numUnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColdDrinks", x => x.intColdDrinksId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblColdDrinks");
        }
    }
}
