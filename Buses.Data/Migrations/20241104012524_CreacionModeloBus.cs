using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buses.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloBus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Ruta_RutaId",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "RutaId",
                table: "Reserva",
                newName: "BusId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_RutaId",
                table: "Reserva",
                newName: "IX_Reserva_BusId");

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "Ruta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AsientosReservados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bus_Ruta_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Ruta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_RutaId",
                table: "Bus",
                column: "RutaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Bus_BusId",
                table: "Reserva",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Bus_BusId",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "Ruta");

            migrationBuilder.RenameColumn(
                name: "BusId",
                table: "Reserva",
                newName: "RutaId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_BusId",
                table: "Reserva",
                newName: "IX_Reserva_RutaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Ruta_RutaId",
                table: "Reserva",
                column: "RutaId",
                principalTable: "Ruta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
