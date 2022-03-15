using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    public partial class FinalModelLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dish_DishesId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishSupply_Dish_DishesId",
                table: "DishSupply");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employees_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "NameLength",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "PricePerDish",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "TotalSales",
                table: "Dish");

            migrationBuilder.RenameTable(
                name: "Dish",
                newName: "Dishes");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Supplies",
                newName: "SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_SupplierId",
                table: "Supplies",
                newName: "IX_Supplies_SupplierID");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Supplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Supplies",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Supplies",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ToGo",
                table: "Order",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderValue",
                table: "Order",
                type: "smallmoney",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "smallmoney");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDateTime",
                table: "Order",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "smallmoney",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dishes_DishesId",
                table: "DishOrder",
                column: "DishesId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishSupply_Dishes_DishesId",
                table: "DishSupply",
                column: "DishesId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employees_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Order_SupplierID",
                table: "Supplies",
                column: "SupplierID",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dishes_DishesId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishSupply_Dishes_DishesId",
                table: "DishSupply");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employees_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Order_SupplierID",
                table: "Supplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Dish");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Supplies",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_SupplierID",
                table: "Supplies",
                newName: "IX_Supplies_SupplierId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Supplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseDate",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ToGo",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderValue",
                table: "Order",
                type: "smallmoney",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "smallmoney",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDateTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NameLength",
                table: "Dish",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDish",
                table: "Dish",
                type: "smallmoney",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSales",
                table: "Dish",
                type: "money",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish",
                table: "Dish",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplyCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dish_DishesId",
                table: "DishOrder",
                column: "DishesId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishSupply_Dish_DishesId",
                table: "DishSupply",
                column: "DishesId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employees_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
