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
					Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Edad = table.Column<int>(type: "int", nullable: false),
					Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
					FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Intereses = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
					Usuario1IdUsuario = table.Column<int>(type: "int", nullable: true),
					IdUsuario2 = table.Column<int>(type: "int", nullable: false),
					Usuario2IdUsuario = table.Column<int>(type: "int", nullable: true),
					FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
					Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Citas", x => x.IdCita);
					table.ForeignKey(
						name: "FK_Citas_Usuarios_Usuario1IdUsuario",
						column: x => x.Usuario1IdUsuario,
						principalTable: "Usuarios",
						principalColumn: "IdUsuario");
					table.ForeignKey(
						name: "FK_Citas_Usuarios_Usuario2IdUsuario",
						column: x => x.Usuario2IdUsuario,
						principalTable: "Usuarios",
						principalColumn: "IdUsuario");
				});

			migrationBuilder.CreateTable(
				name: "Mensajes",
				columns: table => new
				{
					IdMensaje = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdRemitente = table.Column<int>(type: "int", nullable: false),
					RemitenteIdUsuario = table.Column<int>(type: "int", nullable: false),
					IdDestinatario = table.Column<int>(type: "int", nullable: false),
					DestinatarioIdUsuario = table.Column<int>(type: "int", nullable: false),
					ContenidoMensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
					FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Mensajes", x => x.IdMensaje);
					table.ForeignKey(
						name: "FK_Mensajes_Usuarios_DestinatarioIdUsuario",
						column: x => x.DestinatarioIdUsuario,
						principalTable: "Usuarios",
						principalColumn: "IdUsuario",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Mensajes_Usuarios_RemitenteIdUsuario",
						column: x => x.RemitenteIdUsuario,
						principalTable: "Usuarios",
						principalColumn: "IdUsuario",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "Perfiles",
				columns: table => new
				{
					IdPerfil = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdUsuario = table.Column<int>(type: "int", nullable: false),
					UsuarioIdUsuario = table.Column<int>(type: "int", nullable: false),
					Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Gustos = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Perfiles", x => x.IdPerfil);
					table.ForeignKey(
						name: "FK_Perfiles_Usuarios_UsuarioIdUsuario",
						column: x => x.UsuarioIdUsuario,
						principalTable: "Usuarios",
						principalColumn: "IdUsuario",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Citas_Usuario1IdUsuario",
				table: "Citas",
				column: "Usuario1IdUsuario");

			migrationBuilder.CreateIndex(
				name: "IX_Citas_Usuario2IdUsuario",
				table: "Citas",
				column: "Usuario2IdUsuario");

			migrationBuilder.CreateIndex(
				name: "IX_Mensajes_DestinatarioIdUsuario",
				table: "Mensajes",
				column: "DestinatarioIdUsuario");

			migrationBuilder.CreateIndex(
				name: "IX_Mensajes_RemitenteIdUsuario",
				table: "Mensajes",
				column: "RemitenteIdUsuario");

			migrationBuilder.CreateIndex(
				name: "IX_Perfiles_UsuarioIdUsuario",
				table: "Perfiles",
				column: "UsuarioIdUsuario");
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
