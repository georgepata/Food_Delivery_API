using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Food_Delivery_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDeliveryDriverAnnotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDrivers_Orders_OrderId",
                table: "DeliveryDrivers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDrivers_OrderId",
                table: "DeliveryDrivers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "475211b4-d722-4d43-a526-25c842b3755b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2f2f109-b6ac-4955-9451-60f96cbce146");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "DeliveryDrivers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a34b0e5-8831-45ce-947b-598058980b0e", null, "User", "USER" },
                    { "e0215b19-4559-4174-a2c1-4818658c5dab", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDrivers_OrderId",
                table: "DeliveryDrivers",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDrivers_Orders_OrderId",
                table: "DeliveryDrivers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDrivers_Orders_OrderId",
                table: "DeliveryDrivers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDrivers_OrderId",
                table: "DeliveryDrivers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a34b0e5-8831-45ce-947b-598058980b0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0215b19-4559-4174-a2c1-4818658c5dab");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "DeliveryDrivers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "475211b4-d722-4d43-a526-25c842b3755b", null, "Admin", "ADMIN" },
                    { "c2f2f109-b6ac-4955-9451-60f96cbce146", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDrivers_OrderId",
                table: "DeliveryDrivers",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDrivers_Orders_OrderId",
                table: "DeliveryDrivers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
