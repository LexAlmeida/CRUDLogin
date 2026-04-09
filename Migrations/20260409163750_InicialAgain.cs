using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class InicialAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LOGIN",
                table: "LOGIN");

            migrationBuilder.RenameTable(
                name: "LOGIN",
                newName: "login");

            migrationBuilder.AddPrimaryKey(
                name: "PK_login",
                table: "login",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_login",
                table: "login");

            migrationBuilder.RenameTable(
                name: "login",
                newName: "LOGIN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LOGIN",
                table: "LOGIN",
                column: "Id");
        }
    }
}
