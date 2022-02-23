using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    public partial class AddedDishEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDish = table.Column<decimal>(type: "smallmoney", nullable: true),
                    ToGo = table.Column<bool>(type: "bit", nullable: true),
                    NameLength = table.Column<int>(type: "int", nullable: true),
                    TotalSales = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishSupply",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    SuppliesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishSupply", x => new { x.DishesId, x.SuppliesId });
                    table.ForeignKey(
                        name: "FK_DishSupply_Dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishSupply_Supplies_SuppliesId",
                        column: x => x.SuppliesId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishSupply_SuppliesId",
                table: "DishSupply",
                column: "SuppliesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishSupply");

            migrationBuilder.DropTable(
                name: "Dish");
        }
    }
}
