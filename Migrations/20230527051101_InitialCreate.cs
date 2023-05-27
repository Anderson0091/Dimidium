using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dimidiun.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intereses = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario1 = table.Column<int>(type: "int", nullable: false),
                    IdUsuario2 = table.Column<int>(type: "int", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_IdUsuario1",
                        column: x => x.IdUsuario1,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_IdUsuario2",
                        column: x => x.IdUsuario2,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    IdMensaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRemitente = table.Column<int>(type: "int", nullable: false),
                    IdDestinatario = table.Column<int>(type: "int", nullable: false),
                    ContenidoMensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.IdMensaje);
                    table.ForeignKey(
                        name: "FK_Mensajes_Usuarios_IdDestinatario",
                        column: x => x.IdDestinatario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensajes_Usuarios_IdRemitente",
                        column: x => x.IdRemitente,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gustos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.IdPerfil);
                    table.ForeignKey(
                        name: "FK_Perfiles_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdUsuario1",
                table: "Citas",
                column: "IdUsuario1");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdUsuario2",
                table: "Citas",
                column: "IdUsuario2");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_IdDestinatario",
                table: "Mensajes",
                column: "IdDestinatario");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_IdRemitente",
                table: "Mensajes",
                column: "IdRemitente");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_IdUsuario",
                table: "Perfiles",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
