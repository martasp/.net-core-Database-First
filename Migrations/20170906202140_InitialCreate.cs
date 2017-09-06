using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mvctest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destytojas",
                columns: table => new
                {
                    id_Destytojas = table.Column<int>(type: "int", nullable: false),
                    metai = table.Column<DateTime>(type: "date", nullable: true),
                    pavarde = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    vardas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destytojas", x => x.id_Destytojas);
                });

            migrationBuilder.CreateTable(
                name: "Studentas",
                columns: table => new
                {
                    id_Studentas = table.Column<int>(type: "int", nullable: false),
                    fk_Destytojasid_Destytojas = table.Column<int>(type: "int", nullable: false),
                    metai = table.Column<DateTime>(type: "date", nullable: true),
                    pavarde = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    universitetas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    vardas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studentas", x => x.id_Studentas);
                    table.ForeignKey(
                        name: "moko",
                        column: x => x.fk_Destytojasid_Destytojas,
                        principalTable: "Destytojas",
                        principalColumn: "id_Destytojas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atsiskaitymas",
                columns: table => new
                {
                    id_Atsiskaitymas = table.Column<int>(type: "int", nullable: false),
                    fk_Studentasid_Studentas = table.Column<int>(type: "int", nullable: false),
                    pavadinimas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    pazymys = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atsiskaitymas", x => x.id_Atsiskaitymas);
                    table.ForeignKey(
                        name: "atsiskaito",
                        column: x => x.fk_Studentasid_Studentas,
                        principalTable: "Studentas",
                        principalColumn: "id_Studentas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modulis",
                columns: table => new
                {
                    kodas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    fk_Studentasid_Studentas = table.Column<int>(type: "int", nullable: false),
                    fk_Studentasid_Studentas1 = table.Column<int>(type: "int", nullable: false),
                    pavadinimas = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulis", x => x.kodas);
                    table.ForeignKey(
                        name: "turi",
                        column: x => x.fk_Studentasid_Studentas,
                        principalTable: "Studentas",
                        principalColumn: "id_Studentas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Modulis__fk_Stud__2D27B809",
                        column: x => x.fk_Studentasid_Studentas1,
                        principalTable: "Studentas",
                        principalColumn: "id_Studentas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atsiskaitymas_fk_Studentasid_Studentas",
                table: "Atsiskaitymas",
                column: "fk_Studentasid_Studentas");

            migrationBuilder.CreateIndex(
                name: "IX_Modulis_fk_Studentasid_Studentas",
                table: "Modulis",
                column: "fk_Studentasid_Studentas");

            migrationBuilder.CreateIndex(
                name: "IX_Modulis_fk_Studentasid_Studentas1",
                table: "Modulis",
                column: "fk_Studentasid_Studentas1");

            migrationBuilder.CreateIndex(
                name: "IX_Studentas_fk_Destytojasid_Destytojas",
                table: "Studentas",
                column: "fk_Destytojasid_Destytojas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atsiskaitymas");

            migrationBuilder.DropTable(
                name: "Modulis");

            migrationBuilder.DropTable(
                name: "Studentas");

            migrationBuilder.DropTable(
                name: "Destytojas");
        }
    }
}
