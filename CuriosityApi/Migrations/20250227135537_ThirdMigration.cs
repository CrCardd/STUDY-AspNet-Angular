using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuriosityApi.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Carts_IdCart",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_IdCart",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "IdChat",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "IdCart",
                table: "Chats",
                newName: "IdProduct");

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IdProduct",
                table: "Chats",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Products_IdProduct",
                table: "Chats",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Products_IdProduct",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_IdProduct",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "Chats",
                newName: "IdCart");

            migrationBuilder.AddColumn<Guid>(
                name: "IdChat",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IdCart",
                table: "Chats",
                column: "IdCart",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Carts_IdCart",
                table: "Chats",
                column: "IdCart",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
