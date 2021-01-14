using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persona.Persistencia.Migrations
{
    public partial class creartablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombres = table.Column<string>(type: "text", nullable: true),
                    apellidos = table.Column<string>(type: "text", nullable: true),
                    numdocumento = table.Column<string>(type: "text", nullable: true),
                    imagen = table.Column<string>(type: "text", nullable: true),
                    fechanacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    idtipodocumento = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.id);
                    table.ForeignKey(
                        name: "FK_Persona_TipoDocumento_idtipodocumento",
                        column: x => x.idtipodocumento,
                        principalTable: "TipoDocumento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonaDireccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    direccion = table.Column<string>(type: "text", nullable: true),
                    idpersona = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaDireccion", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonaDireccion_Persona_idpersona",
                        column: x => x.idpersona,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaEmail",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: true),
                    idpersona = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaEmail", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonaEmail_Persona_idpersona",
                        column: x => x.idpersona,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaTelefono",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    telefono = table.Column<string>(type: "text", nullable: true),
                    idpersona = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaTelefono", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonaTelefono_Persona_idpersona",
                        column: x => x.idpersona,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_idtipodocumento",
                table: "Persona",
                column: "idtipodocumento");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaDireccion_idpersona",
                table: "PersonaDireccion",
                column: "idpersona");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaEmail_idpersona",
                table: "PersonaEmail",
                column: "idpersona");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTelefono_idpersona",
                table: "PersonaTelefono",
                column: "idpersona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaDireccion");

            migrationBuilder.DropTable(
                name: "PersonaEmail");

            migrationBuilder.DropTable(
                name: "PersonaTelefono");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoDocumento");
        }
    }
}
