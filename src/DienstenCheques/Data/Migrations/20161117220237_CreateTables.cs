using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DienstenCheques.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    GebruikersNummer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Naam = table.Column<string>(maxLength: 100, nullable: false),
                    Voornaam = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.GebruikersNummer);
                });

            migrationBuilder.CreateTable(
                name: "Ondernemingen",
                columns: table => new
                {
                    OndernemingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ondernemingen", x => x.OndernemingId);
                });

            migrationBuilder.CreateTable(
                name: "Bestelling",
                columns: table => new
                {
                    BestellingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AantalAangekochteCheques = table.Column<int>(nullable: false),
                    CreatieDatum = table.Column<DateTime>(nullable: false),
                    DebiteerDatum = table.Column<DateTime>(nullable: false),
                    Elektronisch = table.Column<bool>(nullable: false),
                    GebruikersNummer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.BestellingId);
                    table.ForeignKey(
                        name: "FK_Bestelling_Gebruiker_GebruikersNummer",
                        column: x => x.GebruikersNummer,
                        principalTable: "Gebruiker",
                        principalColumn: "GebruikersNummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestatie",
                columns: table => new
                {
                    PrestatieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AantalUren = table.Column<int>(nullable: false),
                    Betaald = table.Column<bool>(nullable: false),
                    DatumPrestatie = table.Column<DateTime>(nullable: false),
                    GebruikersNummer = table.Column<int>(nullable: false),
                    OndernemingId = table.Column<int>(nullable: false),
                    PrestatieType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestatie", x => x.PrestatieId);
                    table.ForeignKey(
                        name: "FK_Prestatie_Gebruiker_GebruikersNummer",
                        column: x => x.GebruikersNummer,
                        principalTable: "Gebruiker",
                        principalColumn: "GebruikersNummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestatie_Ondernemingen_OndernemingId",
                        column: x => x.OndernemingId,
                        principalTable: "Ondernemingen",
                        principalColumn: "OndernemingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DienstenCheque",
                columns: table => new
                {
                    DienstenChequeNummer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatieDatum = table.Column<DateTime>(nullable: false),
                    Elektronisch = table.Column<bool>(nullable: false),
                    GebruikersNummer = table.Column<int>(nullable: false),
                    GebruiksDatum = table.Column<DateTime>(nullable: true),
                    PrestatieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DienstenCheque", x => x.DienstenChequeNummer);
                    table.ForeignKey(
                        name: "FK_DienstenCheque_Gebruiker_GebruikersNummer",
                        column: x => x.GebruikersNummer,
                        principalTable: "Gebruiker",
                        principalColumn: "GebruikersNummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DienstenCheque_Prestatie_PrestatieId",
                        column: x => x.PrestatieId,
                        principalTable: "Prestatie",
                        principalColumn: "PrestatieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_GebruikersNummer",
                table: "Bestelling",
                column: "GebruikersNummer");

            migrationBuilder.CreateIndex(
                name: "IX_DienstenCheque_GebruikersNummer",
                table: "DienstenCheque",
                column: "GebruikersNummer");

            migrationBuilder.CreateIndex(
                name: "IX_DienstenCheque_PrestatieId",
                table: "DienstenCheque",
                column: "PrestatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestatie_GebruikersNummer",
                table: "Prestatie",
                column: "GebruikersNummer");

            migrationBuilder.CreateIndex(
                name: "IX_Prestatie_OndernemingId",
                table: "Prestatie",
                column: "OndernemingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestelling");

            migrationBuilder.DropTable(
                name: "DienstenCheque");

            migrationBuilder.DropTable(
                name: "Prestatie");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.DropTable(
                name: "Ondernemingen");
        }
    }
}
