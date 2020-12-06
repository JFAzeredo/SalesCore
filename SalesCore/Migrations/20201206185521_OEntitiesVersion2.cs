using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesCore.Migrations
{
    public partial class OEntitiesVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecor_Seller_SellerId",
                table: "SalesRecor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecor",
                table: "SalesRecor");

            migrationBuilder.RenameTable(
                name: "SalesRecor",
                newName: "SalesRecord");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecor_SellerId",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_SellerId",
                table: "SalesRecord",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_SellerId",
                table: "SalesRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord");

            migrationBuilder.RenameTable(
                name: "SalesRecord",
                newName: "SalesRecor");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellerId",
                table: "SalesRecor",
                newName: "IX_SalesRecor_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecor",
                table: "SalesRecor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecor_Seller_SellerId",
                table: "SalesRecor",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
