using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HTPIFoundation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutreTypePiece",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutreTypePiece", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Operateur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operateur", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    alpha2 = table.Column<string>(nullable: true),
                    alpha3 = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    nom_en_gb = table.Column<string>(nullable: true),
                    nom_fr_fr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeJustificatifDomicile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeJustificatifDomicile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypePieceIdentite",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePieceIdentite", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Upload",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upload", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DateCrt = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PieceIdentite",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AutreTypeJustDomicileID = table.Column<int>(nullable: true),
                    AutreTypePieceIdentiteID = table.Column<int>(nullable: true),
                    DateDelivrance = table.Column<DateTime>(nullable: false),
                    DateExpiration = table.Column<DateTime>(nullable: false),
                    NumPieceIdentite = table.Column<string>(nullable: true),
                    PaysDelivranceID = table.Column<int>(nullable: false),
                    TypeJustDomicileID = table.Column<int>(nullable: false),
                    TypePieceIdentiteID = table.Column<int>(nullable: false),
                    UploadActeDeNaissanceID = table.Column<int>(nullable: false),
                    UploadJustificatifDomicileID = table.Column<int>(nullable: false),
                    UploadPieceIdentiteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceIdentite", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PieceIdentite_AutreTypePiece_AutreTypeJustDomicileID",
                        column: x => x.AutreTypeJustDomicileID,
                        principalTable: "AutreTypePiece",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PieceIdentite_AutreTypePiece_AutreTypePieceIdentiteID",
                        column: x => x.AutreTypePieceIdentiteID,
                        principalTable: "AutreTypePiece",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PieceIdentite_Pays_PaysDelivranceID",
                        column: x => x.PaysDelivranceID,
                        principalTable: "Pays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceIdentite_TypeJustificatifDomicile_TypeJustDomicileID",
                        column: x => x.TypeJustDomicileID,
                        principalTable: "TypeJustificatifDomicile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceIdentite_TypePieceIdentite_TypePieceIdentiteID",
                        column: x => x.TypePieceIdentiteID,
                        principalTable: "TypePieceIdentite",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceIdentite_Upload_UploadActeDeNaissanceID",
                        column: x => x.UploadActeDeNaissanceID,
                        principalTable: "Upload",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceIdentite_Upload_UploadJustificatifDomicileID",
                        column: x => x.UploadJustificatifDomicileID,
                        principalTable: "Upload",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceIdentite_Upload_UploadPieceIdentiteID",
                        column: x => x.UploadPieceIdentiteID,
                        principalTable: "Upload",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membre",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AccepteCharteMembre = table.Column<bool>(nullable: false),
                    Adresse = table.Column<string>(nullable: true),
                    Appellation = table.Column<int>(nullable: false),
                    Code_postal = table.Column<string>(nullable: true),
                    Date_naissance = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ID_HTPI = table.Column<string>(nullable: true),
                    Nationnalite = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    NumCompatibleMobileMoney = table.Column<bool>(nullable: false),
                    OperateurID = table.Column<int>(nullable: false),
                    PaysID = table.Column<int>(nullable: false),
                    PersonneReferenceID = table.Column<int>(nullable: false),
                    PieceIdentiteID = table.Column<int>(nullable: false),
                    Prenom = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    TelephoneFixe = table.Column<string>(nullable: true),
                    TelephoneMobile = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Membre_Operateur_OperateurID",
                        column: x => x.OperateurID,
                        principalTable: "Operateur",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membre_Pays_PaysID",
                        column: x => x.PaysID,
                        principalTable: "Pays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membre_Membre_PersonneReferenceID",
                        column: x => x.PersonneReferenceID,
                        principalTable: "Membre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membre_PieceIdentite_PieceIdentiteID",
                        column: x => x.PieceIdentiteID,
                        principalTable: "PieceIdentite",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHtpi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DatePayement = table.Column<DateTime>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    FraisTransfert = table.Column<decimal>(nullable: false),
                    IDTransaction = table.Column<string>(nullable: true),
                    MembreID = table.Column<int>(nullable: false),
                    MontantAvance = table.Column<decimal>(nullable: false),
                    MontantTotal = table.Column<decimal>(nullable: false),
                    MoyenPayement = table.Column<int>(nullable: false),
                    NumRecue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHtpi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DonHtpi_Membre_MembreID",
                        column: x => x.MembreID,
                        principalTable: "Membre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paiement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AvanceAccord = table.Column<bool>(nullable: false),
                    DatePayement = table.Column<DateTime>(nullable: false),
                    IDTransaction = table.Column<string>(nullable: true),
                    MembreAvanceID = table.Column<int>(nullable: false),
                    MembreID = table.Column<int>(nullable: false),
                    MontantAvance = table.Column<decimal>(nullable: false),
                    MontantPayer = table.Column<decimal>(nullable: false),
                    MoyenPayement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Paiement_Membre_MembreAvanceID",
                        column: x => x.MembreAvanceID,
                        principalTable: "Membre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paiement_Membre_MembreID",
                        column: x => x.MembreID,
                        principalTable: "Membre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHtpi_MembreID",
                table: "DonHtpi",
                column: "MembreID");

            migrationBuilder.CreateIndex(
                name: "IX_Membre_OperateurID",
                table: "Membre",
                column: "OperateurID");

            migrationBuilder.CreateIndex(
                name: "IX_Membre_PaysID",
                table: "Membre",
                column: "PaysID");

            migrationBuilder.CreateIndex(
                name: "IX_Membre_PersonneReferenceID",
                table: "Membre",
                column: "PersonneReferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Membre_PieceIdentiteID",
                table: "Membre",
                column: "PieceIdentiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_MembreAvanceID",
                table: "Paiement",
                column: "MembreAvanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_MembreID",
                table: "Paiement",
                column: "MembreID");

            migrationBuilder.CreateIndex(
                name: "IX_PieceIdentite_AutreTypeJustDomicileID",
                table: "PieceIdentite",
                column: "AutreTypeJustDomicileID");

            migrationBuilder.CreateIndex(
                name: "IX_PieceIdentite_AutreTypePieceIdentiteID",
                table: "PieceIdentite",
                column: "AutreTypePieceIdentiteID");

            migrationBuilder.CreateIndex(
                name: "IX_PieceIdentite_PaysDelivranceID",
                table: "PieceIdentite",
                column: "PaysDelivranceID");

            migrationBuilder.CreateIndex(
                name: "IX_PieceIdentite_TypeJustDomicileID",
                table: "PieceIdentite",
                column: "TypeJustDomicileID");

            migrationBuilder.CreateIndex(
                name: "IX_PieceIdentite_TypePieceIdentiteID",
                table: "PieceIdentite",
                column: "TypePieceIdentiteID");

            migrationBuilder.CreateIndex(
                name: "IX_PieceIdentite_UploadActeDeNaissanceID",
                table: "PieceIdentite",
                column: "UploadActeDeNaissanceID");

            migrationBuilder.CreateIndex(
                name: "IX_PieceIdentite_UploadJustificatifDomicileID",
                table: "PieceIdentite",
                column: "UploadJustificatifDomicileID");

            migrationBuilder.CreateIndex(
                name: "IX_PieceIdentite_UploadPieceIdentiteID",
                table: "PieceIdentite",
                column: "UploadPieceIdentiteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHtpi");

            migrationBuilder.DropTable(
                name: "Paiement");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Membre");

            migrationBuilder.DropTable(
                name: "Operateur");

            migrationBuilder.DropTable(
                name: "PieceIdentite");

            migrationBuilder.DropTable(
                name: "AutreTypePiece");

            migrationBuilder.DropTable(
                name: "Pays");

            migrationBuilder.DropTable(
                name: "TypeJustificatifDomicile");

            migrationBuilder.DropTable(
                name: "TypePieceIdentite");

            migrationBuilder.DropTable(
                name: "Upload");
        }
    }
}
