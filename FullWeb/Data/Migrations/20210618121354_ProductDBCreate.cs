using Microsoft.EntityFrameworkCore.Migrations;

namespace FullWeb.Data.Migrations
{
    public partial class ProductDBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingSize = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ClothingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fabric = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
