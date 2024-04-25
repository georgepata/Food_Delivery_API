using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery_API.Migrations
{
    /// <inheritdoc />
    public partial class AddingRatingRestaurantsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingRestaurant_Restaurants_RestaurantId",
                table: "RatingRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingRestaurant_Users_UserId",
                table: "RatingRestaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingRestaurant",
                table: "RatingRestaurant");

            migrationBuilder.RenameTable(
                name: "RatingRestaurant",
                newName: "RatingRestaurants");

            migrationBuilder.RenameIndex(
                name: "IX_RatingRestaurant_UserId",
                table: "RatingRestaurants",
                newName: "IX_RatingRestaurants_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RatingRestaurant_RestaurantId",
                table: "RatingRestaurants",
                newName: "IX_RatingRestaurants_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingRestaurants",
                table: "RatingRestaurants",
                column: "RatingRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingRestaurants_Restaurants_RestaurantId",
                table: "RatingRestaurants",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingRestaurants_Users_UserId",
                table: "RatingRestaurants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingRestaurants_Restaurants_RestaurantId",
                table: "RatingRestaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingRestaurants_Users_UserId",
                table: "RatingRestaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingRestaurants",
                table: "RatingRestaurants");

            migrationBuilder.RenameTable(
                name: "RatingRestaurants",
                newName: "RatingRestaurant");

            migrationBuilder.RenameIndex(
                name: "IX_RatingRestaurants_UserId",
                table: "RatingRestaurant",
                newName: "IX_RatingRestaurant_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RatingRestaurants_RestaurantId",
                table: "RatingRestaurant",
                newName: "IX_RatingRestaurant_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingRestaurant",
                table: "RatingRestaurant",
                column: "RatingRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingRestaurant_Restaurants_RestaurantId",
                table: "RatingRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingRestaurant_Users_UserId",
                table: "RatingRestaurant",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
