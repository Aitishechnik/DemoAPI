using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CustomUsersUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCustom_UserLogs_UserLogID",
                table: "UsersCustom");

            migrationBuilder.DropIndex(
                name: "IX_UsersCustom_UserLogID",
                table: "UsersCustom");

            migrationBuilder.AddColumn<string>(
                name: "UserLogName",
                table: "UsersCustom",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLogName",
                table: "UsersCustom");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCustom_UserLogID",
                table: "UsersCustom",
                column: "UserLogID");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCustom_UserLogs_UserLogID",
                table: "UsersCustom",
                column: "UserLogID",
                principalTable: "UserLogs",
                principalColumn: "Id");
        }
    }
}
