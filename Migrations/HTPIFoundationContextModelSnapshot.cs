﻿// <auto-generated />
using HTPIFoundation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;

namespace HTPIFoundation.Migrations
{
    [DbContext(typeof(HTPIFoundationContext))]
    partial class HTPIFoundationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("HTPIFoundation.Models.AutreTypePiece", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("AutreTypePiece");
                });

            modelBuilder.Entity("HTPIFoundation.Models.DonHtpi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePayement");

                    b.Property<string>("Detail");

                    b.Property<decimal>("FraisTransfert");

                    b.Property<string>("IDTransaction");

                    b.Property<int>("MembreID");

                    b.Property<decimal>("MontantAvance");

                    b.Property<decimal>("MontantTotal");

                    b.Property<int>("MoyenPayement");

                    b.Property<string>("NumRecue");

                    b.HasKey("ID");

                    b.HasIndex("MembreID");

                    b.ToTable("DonHtpi");
                });

            modelBuilder.Entity("HTPIFoundation.Models.Membre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AccepteCharteMembre");

                    b.Property<string>("Adresse");

                    b.Property<int>("Appellation");

                    b.Property<string>("Code_postal");

                    b.Property<DateTime>("Date_naissance");

                    b.Property<string>("Email");

                    b.Property<string>("ID_HTPI");

                    b.Property<string>("Nationnalite");

                    b.Property<string>("Nom");

                    b.Property<bool>("NumCompatibleMobileMoney");

                    b.Property<int>("OperateurID");

                    b.Property<int>("PaysID");

                    b.Property<int>("PersonneReferenceID");

                    b.Property<int>("PieceIdentiteID");

                    b.Property<string>("Prenom");

                    b.Property<string>("Profession");

                    b.Property<string>("TelephoneFixe");

                    b.Property<string>("TelephoneMobile");

                    b.Property<string>("Ville");

                    b.HasKey("ID");

                    b.HasIndex("OperateurID");

                    b.HasIndex("PaysID");

                    b.HasIndex("PersonneReferenceID");

                    b.HasIndex("PieceIdentiteID");

                    b.ToTable("Membre");
                });

            modelBuilder.Entity("HTPIFoundation.Models.Operateur", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("ID");

                    b.ToTable("Operateur");
                });

            modelBuilder.Entity("HTPIFoundation.Models.Paiement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AvanceAccord");

                    b.Property<DateTime>("DatePayement");

                    b.Property<string>("IDTransaction");

                    b.Property<int>("MembreAvanceID");

                    b.Property<int>("MembreID");

                    b.Property<decimal>("MontantAvance");

                    b.Property<decimal>("MontantPayer");

                    b.Property<int>("MoyenPayement");

                    b.HasKey("ID");

                    b.HasIndex("MembreAvanceID");

                    b.HasIndex("MembreID");

                    b.ToTable("Paiement");
                });

            modelBuilder.Entity("HTPIFoundation.Models.Pays", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("alpha2");

                    b.Property<string>("alpha3");

                    b.Property<string>("code");

                    b.Property<string>("nom_en_gb");

                    b.Property<string>("nom_fr_fr");

                    b.HasKey("ID");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("HTPIFoundation.Models.PieceIdentite", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AutreTypeJustDomicileID");

                    b.Property<int?>("AutreTypePieceIdentiteID");

                    b.Property<DateTime>("DateDelivrance");

                    b.Property<DateTime>("DateExpiration");

                    b.Property<string>("NumPieceIdentite");

                    b.Property<int>("PaysDelivranceID");

                    b.Property<int>("TypeJustDomicileID");

                    b.Property<int>("TypePieceIdentiteID");

                    b.Property<int>("UploadActeDeNaissanceID");

                    b.Property<int>("UploadJustificatifDomicileID");

                    b.Property<int>("UploadPieceIdentiteID");

                    b.HasKey("ID");

                    b.HasIndex("AutreTypeJustDomicileID");

                    b.HasIndex("AutreTypePieceIdentiteID");

                    b.HasIndex("PaysDelivranceID");

                    b.HasIndex("TypeJustDomicileID");

                    b.HasIndex("TypePieceIdentiteID");

                    b.HasIndex("UploadActeDeNaissanceID");

                    b.HasIndex("UploadJustificatifDomicileID");

                    b.HasIndex("UploadPieceIdentiteID");

                    b.ToTable("PieceIdentite");
                });

            modelBuilder.Entity("HTPIFoundation.Models.TypeJustificatifDomicile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("TypeJustificatifDomicile");
                });

            modelBuilder.Entity("HTPIFoundation.Models.TypePieceIdentite", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("TypePieceIdentite");
                });

            modelBuilder.Entity("HTPIFoundation.Models.Upload", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("FileName");

                    b.Property<string>("Uri");

                    b.HasKey("ID");

                    b.ToTable("Upload");
                });

            modelBuilder.Entity("HTPIFoundation.Models.Utilisateur", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCrt");

                    b.Property<string>("Email");

                    b.Property<string>("Genre");

                    b.Property<string>("Nom");

                    b.Property<string>("Password");

                    b.Property<string>("Prenom");

                    b.HasKey("ID");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("HTPIFoundation.Models.DonHtpi", b =>
                {
                    b.HasOne("HTPIFoundation.Models.Membre", "Membre")
                        .WithMany()
                        .HasForeignKey("MembreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HTPIFoundation.Models.Membre", b =>
                {
                    b.HasOne("HTPIFoundation.Models.Operateur", "Operateur")
                        .WithMany()
                        .HasForeignKey("OperateurID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.Pays", "Pays")
                        .WithMany()
                        .HasForeignKey("PaysID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.Membre", "PersonneReference")
                        .WithMany()
                        .HasForeignKey("PersonneReferenceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.PieceIdentite", "PieceIdentite")
                        .WithMany()
                        .HasForeignKey("PieceIdentiteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HTPIFoundation.Models.Paiement", b =>
                {
                    b.HasOne("HTPIFoundation.Models.Membre", "MembreAvance")
                        .WithMany()
                        .HasForeignKey("MembreAvanceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.Membre", "Membre")
                        .WithMany()
                        .HasForeignKey("MembreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HTPIFoundation.Models.PieceIdentite", b =>
                {
                    b.HasOne("HTPIFoundation.Models.AutreTypePiece", "AutreTypeJustDomicile")
                        .WithMany()
                        .HasForeignKey("AutreTypeJustDomicileID");

                    b.HasOne("HTPIFoundation.Models.AutreTypePiece", "AutreTypePieceIdentite")
                        .WithMany()
                        .HasForeignKey("AutreTypePieceIdentiteID");

                    b.HasOne("HTPIFoundation.Models.Pays", "PaysDelivrance")
                        .WithMany()
                        .HasForeignKey("PaysDelivranceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.TypeJustificatifDomicile", "TypeJustDomicile")
                        .WithMany()
                        .HasForeignKey("TypeJustDomicileID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.TypePieceIdentite", "TypePieceIdentite")
                        .WithMany()
                        .HasForeignKey("TypePieceIdentiteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.Upload", "UploadActeDeNaissance")
                        .WithMany()
                        .HasForeignKey("UploadActeDeNaissanceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.Upload", "UploadJustificatifDomicile")
                        .WithMany()
                        .HasForeignKey("UploadJustificatifDomicileID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HTPIFoundation.Models.Upload", "UploadPieceIdentite")
                        .WithMany()
                        .HasForeignKey("UploadPieceIdentiteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
