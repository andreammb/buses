using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buses.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeUserDataFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ruta_AspNetUsers_AppUserId",
                table: "Ruta");

            migrationBuilder.DropIndex(
                name: "IX_Ruta_AppUserId",
                table: "Ruta");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Ruta");

            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Reserva",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_AppUserId",
                table: "Reserva",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_AspNetUsers_AppUserId",
                table: "Reserva",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_AspNetUsers_AppUserId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_AppUserId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reserva");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Ruta",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ruta_AppUserId",
                table: "Ruta",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ruta_AspNetUsers_AppUserId",
                table: "Ruta",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
