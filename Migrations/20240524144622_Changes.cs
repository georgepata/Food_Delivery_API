using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Food_Delivery_API.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenuItem_MenuItems_MenuItemId",
                table: "OrderMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenuItem_Orders_OrderId",
                table: "OrderMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenuItem",
                table: "OrderMenuItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a7c3262-b48c-4f8b-8027-dede84cf48e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50f32355-028c-4361-91ba-699d9b61c31d");

            migrationBuilder.RenameTable(
                name: "OrderMenuItem",
                newName: "OrderMenuItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenuItem_OrderId",
                table: "OrderMenuItems",
                newName: "IX_OrderMenuItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenuItem_MenuItemId",
                table: "OrderMenuItems",
                newName: "IX_OrderMenuItems_MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenuItems",
                table: "OrderMenuItems",
                column: "OrderMenuItemId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ea1f810-7fd1-4ce5-80f2-2fab6ab73f31", null, "User", "USER" },
                    { "50b20b4b-19c3-41c2-9381-e78062dfe816", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenuItems_MenuItems_MenuItemId",
                table: "OrderMenuItems",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenuItems_Orders_OrderId",
                table: "OrderMenuItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenuItems_MenuItems_MenuItemId",
                table: "OrderMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenuItems_Orders_OrderId",
                table: "OrderMenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenuItems",
                table: "OrderMenuItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ea1f810-7fd1-4ce5-80f2-2fab6ab73f31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50b20b4b-19c3-41c2-9381-e78062dfe816");

            migrationBuilder.RenameTable(
                name: "OrderMenuItems",
                newName: "OrderMenuItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenuItems_OrderId",
                table: "OrderMenuItem",
                newName: "IX_OrderMenuItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenuItems_MenuItemId",
                table: "OrderMenuItem",
                newName: "IX_OrderMenuItem_MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenuItem",
                table: "OrderMenuItem",
                column: "OrderMenuItemId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a7c3262-b48c-4f8b-8027-dede84cf48e7", null, "Admin", "ADMIN" },
                    { "50f32355-028c-4361-91ba-699d9b61c31d", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenuItem_MenuItems_MenuItemId",
                table: "OrderMenuItem",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenuItem_Orders_OrderId",
                table: "OrderMenuItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
