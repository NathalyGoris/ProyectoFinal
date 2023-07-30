using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanzApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Correo = table.Column<string>(type: "TEXT", nullable: true),
                    Contrasena = table.Column<string>(type: "TEXT", nullable: true),
                    SaldoTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ahorros",
                columns: table => new
                {
                    AhorroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MontoObjetivo = table.Column<decimal>(type: "TEXT", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ahorros", x => x.AhorroId);
                    table.ForeignKey(
                        name: "FK_Ahorros_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "cuentasBancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreBanco = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "TEXT", nullable: false),
                    SaldoActual = table.Column<decimal>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuentasBancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cuentasBancarias_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: true),
                    CategoriaTransaccionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    GastosTransaccionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.TransaccionId);
                    table.ForeignKey(
                        name: "FK_Transacciones_Transacciones_CategoriaTransaccionId",
                        column: x => x.CategoriaTransaccionId,
                        principalTable: "Transacciones",
                        principalColumn: "TransaccionId");
                    table.ForeignKey(
                        name: "FK_Transacciones_Transacciones_GastosTransaccionId",
                        column: x => x.GastosTransaccionId,
                        principalTable: "Transacciones",
                        principalColumn: "TransaccionId");
                    table.ForeignKey(
                        name: "FK_Transacciones_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ahorros_UsuarioID",
                table: "Ahorros",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_cuentasBancarias_UsuarioID",
                table: "cuentasBancarias",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_CategoriaTransaccionId",
                table: "Transacciones",
                column: "CategoriaTransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_GastosTransaccionId",
                table: "Transacciones",
                column: "GastosTransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_UsuarioID",
                table: "Transacciones",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ahorros");

            migrationBuilder.DropTable(
                name: "cuentasBancarias");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
