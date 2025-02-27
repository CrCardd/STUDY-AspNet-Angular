using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuriosityApi.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_IdUser",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserAId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserBId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Carts");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserBId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserAId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdCart",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUser",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserAId",
                table: "Chats",
                column: "UserAId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserBId",
                table: "Chats",
                column: "UserBId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_IdUser",
                table: "Carts",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Carts_IdCart",
                table: "Chats",
                column: "IdCart",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_IdUser",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Carts_IdCart",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Chats_IdCart",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserAId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserBId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "IdCart",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "IdChat",
                table: "Carts");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserBId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserAId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUser",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserAId",
                table: "Chats",
                column: "UserAId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserBId",
                table: "Chats",
                column: "UserBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_IdUser",
                table: "Carts",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
