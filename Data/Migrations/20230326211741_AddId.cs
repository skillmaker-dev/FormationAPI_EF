using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuisines_Restaurants_RestaurantId",
                table: "Cuisines");

            migrationBuilder.DropIndex(
                name: "IX_Cuisines_RestaurantId",
                table: "Cuisines");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Cuisines");

            migrationBuilder.AddColumn<int>(
                name: "CuisineId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CuisineId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CuisineId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CuisineId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants",
                column: "CuisineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Cuisines_CuisineId",
                table: "Restaurants",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Cuisines_CuisineId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CuisineId",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Cuisines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 1,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 2,
                column: "RestaurantId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 3,
                column: "RestaurantId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_RestaurantId",
                table: "Cuisines",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuisines_Restaurants_RestaurantId",
                table: "Cuisines",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
