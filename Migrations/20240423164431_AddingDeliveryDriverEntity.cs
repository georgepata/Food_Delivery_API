using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery_API.Migrations
{
    /// <inheritdoc />
    public partial class AddingDeliveryDriverEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDriver_Orders_OrderId",
                table: "DeliveryDriver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryDriver",
                table: "DeliveryDriver");

            migrationBuilder.RenameTable(
                name: "DeliveryDriver",
                newName: "DeliveryDrivers");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryDriver_OrderId",
                table: "DeliveryDrivers",
                newName: "IX_DeliveryDrivers_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryDrivers",
                table: "DeliveryDrivers",
                column: "DeliveryDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDrivers_Orders_OrderId",
                table: "DeliveryDrivers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDrivers_Orders_OrderId",
                table: "DeliveryDrivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryDrivers",
                table: "DeliveryDrivers");

            migrationBuilder.RenameTable(
                name: "DeliveryDrivers",
                newName: "DeliveryDriver");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryDrivers_OrderId",
                table: "DeliveryDriver",
                newName: "IX_DeliveryDriver_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryDriver",
                table: "DeliveryDriver",
                column: "DeliveryDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDriver_Orders_OrderId",
                table: "DeliveryDriver",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
