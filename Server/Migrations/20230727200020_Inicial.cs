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
                name: "CategoriaGastos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaGastos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaIngresos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaIngresos", x => x.ID);
                });

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
                name: "MetaAhorros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MontoObjetivo = table.Column<decimal>(type: "TEXT", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaAhorros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaAhorros_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: true),
                    CategoriaID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_CategoriaGastos_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "CategoriaGastos",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Transacciones_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuentasBancarias_UsuarioID",
                table: "cuentasBancarias",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_MetaAhorros_UsuarioID",
                table: "MetaAhorros",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_CategoriaID",
                table: "Transacciones",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_UsuarioID",
                table: "Transacciones",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaIngresos");

            migrationBuilder.DropTable(
                name: "cuentasBancarias");

            migrationBuilder.DropTable(
                name: "MetaAhorros");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "CategoriaGastos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
