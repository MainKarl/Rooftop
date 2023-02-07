﻿// <auto-generated />
using System;
using API_AnalyseSanguine.Context.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230207175609_requetes3")]
    partial class requetes3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_AnalyseSanguine.Models.Dossier", b =>
                {
                    b.Property<int>("IdDossier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDossier"), 1L, 1);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Sexe")
                        .HasColumnType("tinyint");

                    b.HasKey("IdDossier");

                    b.ToTable("Dossiers");

                    b.HasData(
                        new
                        {
                            IdDossier = 1,
                            DateNaissance = new DateTime(2001, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Turgeon",
                            Prenom = "Victor",
                            Sexe = (byte)0
                        },
                        new
                        {
                            IdDossier = 2,
                            DateNaissance = new DateTime(2002, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Belval",
                            Prenom = "Jean-Philippe",
                            Sexe = (byte)0
                        });
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.Medecin", b =>
                {
                    b.Property<int>("IdMedecin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedecin"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedecin");

                    b.ToTable("Medecins");

                    b.HasData(
                        new
                        {
                            IdMedecin = 1,
                            Nom = "Banville",
                            Prenom = "Zacharie"
                        },
                        new
                        {
                            IdMedecin = 2,
                            Nom = "Bourque",
                            Prenom = "Yannick"
                        },
                        new
                        {
                            IdMedecin = 3,
                            Nom = "Langlais",
                            Prenom = "Jonathan"
                        },
                        new
                        {
                            IdMedecin = 4,
                            Nom = "Jetté",
                            Prenom = "Antony"
                        },
                        new
                        {
                            IdMedecin = 5,
                            Nom = "Denis",
                            Prenom = "Lucas"
                        },
                        new
                        {
                            IdMedecin = 6,
                            Nom = "Lagacé",
                            Prenom = "Mathilde"
                        },
                        new
                        {
                            IdMedecin = 7,
                            Nom = "Néron",
                            Prenom = "Alicia"
                        },
                        new
                        {
                            IdMedecin = 8,
                            Nom = "Godin",
                            Prenom = "Raphaelle"
                        },
                        new
                        {
                            IdMedecin = 9,
                            Nom = "Martinez",
                            Prenom = "Leonie"
                        },
                        new
                        {
                            IdMedecin = 10,
                            Nom = "Daneau",
                            Prenom = "Rose"
                        });
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.RequeteAnalyse", b =>
                {
                    b.Property<int>("IdRequete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRequete"), 1L, 1);

                    b.Property<string>("AnalyseDemande")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CodeAcces")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEchantillon")
                        .HasColumnType("datetime2");

                    b.Property<int>("DossierIdDossier")
                        .HasColumnType("int");

                    b.Property<int>("MedecinIdMedecin")
                        .HasColumnType("int");

                    b.Property<string>("NomTechnicien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRequete");

                    b.HasIndex("DossierIdDossier");

                    b.HasIndex("MedecinIdMedecin");

                    b.ToTable("RequeteAnalyses");

                    b.HasData(
                        new
                        {
                            IdRequete = 1,
                            AnalyseDemande = "",
                            CodeAcces = new Guid("3b59dc03-483d-4042-8d0a-1069f47acb12"),
                            DateEchantillon = new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DossierIdDossier = 1,
                            MedecinIdMedecin = 1,
                            NomTechnicien = "Matheo Boudreau"
                        },
                        new
                        {
                            IdRequete = 2,
                            AnalyseDemande = "",
                            CodeAcces = new Guid("f352bcce-2180-4ba2-83b1-f16554b8cb10"),
                            DateEchantillon = new DateTime(2017, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DossierIdDossier = 1,
                            MedecinIdMedecin = 7,
                            NomTechnicien = "Jerome Frenette"
                        },
                        new
                        {
                            IdRequete = 3,
                            AnalyseDemande = "",
                            CodeAcces = new Guid("94629f47-ac04-440c-9569-4cd0c9e67543"),
                            DateEchantillon = new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DossierIdDossier = 1,
                            MedecinIdMedecin = 3,
                            NomTechnicien = "Clara Faubert"
                        },
                        new
                        {
                            IdRequete = 4,
                            AnalyseDemande = "",
                            CodeAcces = new Guid("2c859aaf-a17d-4785-baef-b4251cb9c1e7"),
                            DateEchantillon = new DateTime(2014, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DossierIdDossier = 2,
                            MedecinIdMedecin = 10,
                            NomTechnicien = "Louis Truchon"
                        },
                        new
                        {
                            IdRequete = 5,
                            AnalyseDemande = "",
                            CodeAcces = new Guid("72f47943-b843-410d-a2c8-7650e8a5fa34"),
                            DateEchantillon = new DateTime(2006, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DossierIdDossier = 2,
                            MedecinIdMedecin = 4,
                            NomTechnicien = "Andreanne Pearson"
                        },
                        new
                        {
                            IdRequete = 6,
                            AnalyseDemande = "",
                            CodeAcces = new Guid("bc3368f6-9aa4-4d00-b910-a090472b0fa7"),
                            DateEchantillon = new DateTime(2009, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DossierIdDossier = 2,
                            MedecinIdMedecin = 9,
                            NomTechnicien = "Sabrina Beauvais"
                        });
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.ResultatAnalyse", b =>
                {
                    b.Property<int>("IdResultatAnalyse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResultatAnalyse"), 1L, 1);

                    b.Property<int>("RequeteAnalyseIdRequete")
                        .HasColumnType("int");

                    b.Property<int>("TypeValeurIdTypeValeur")
                        .HasColumnType("int");

                    b.Property<float>("Valeur")
                        .HasColumnType("real");

                    b.HasKey("IdResultatAnalyse");

                    b.HasIndex("RequeteAnalyseIdRequete");

                    b.HasIndex("TypeValeurIdTypeValeur");

                    b.ToTable("ResultatAnalyses");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.TypeAnalyse", b =>
                {
                    b.Property<int>("IdTypeAnalyse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypeAnalyse"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequeteAnalyseIdRequete")
                        .HasColumnType("int");

                    b.HasKey("IdTypeAnalyse");

                    b.HasIndex("RequeteAnalyseIdRequete");

                    b.ToTable("TypeAnalyses");

                    b.HasData(
                        new
                        {
                            IdTypeAnalyse = 1,
                            Nom = "Albumine"
                        },
                        new
                        {
                            IdTypeAnalyse = 2,
                            Nom = "ALT"
                        },
                        new
                        {
                            IdTypeAnalyse = 3,
                            Nom = "Bilan lipidique"
                        },
                        new
                        {
                            IdTypeAnalyse = 4,
                            Nom = "Bilirubine totale"
                        },
                        new
                        {
                            IdTypeAnalyse = 5,
                            Nom = "Calcium total"
                        },
                        new
                        {
                            IdTypeAnalyse = 6,
                            Nom = "Cortisol"
                        },
                        new
                        {
                            IdTypeAnalyse = 7,
                            Nom = "Cortisol post-dexaméthasone"
                        },
                        new
                        {
                            IdTypeAnalyse = 8,
                            Nom = "Créatinine"
                        },
                        new
                        {
                            IdTypeAnalyse = 9,
                            Nom = "Créatinine kinase"
                        },
                        new
                        {
                            IdTypeAnalyse = 10,
                            Nom = "Électrolytes"
                        },
                        new
                        {
                            IdTypeAnalyse = 11,
                            Nom = "Ferritine"
                        },
                        new
                        {
                            IdTypeAnalyse = 12,
                            Nom = "Magnésium"
                        },
                        new
                        {
                            IdTypeAnalyse = 13,
                            Nom = "Phosphatase alcaline"
                        },
                        new
                        {
                            IdTypeAnalyse = 14,
                            Nom = "Phosphore"
                        },
                        new
                        {
                            IdTypeAnalyse = 15,
                            Nom = "Protéine C réactive"
                        },
                        new
                        {
                            IdTypeAnalyse = 16,
                            Nom = "Protéines totales"
                        },
                        new
                        {
                            IdTypeAnalyse = 17,
                            Nom = "TSH et algorithme T4L et T3L"
                        });
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.TypeValeur", b =>
                {
                    b.Property<int>("IdTypeValeur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypeValeur"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeAnalyseIdTypeAnalyse")
                        .HasColumnType("int");

                    b.Property<string>("Unite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypeValeur");

                    b.HasIndex("TypeAnalyseIdTypeAnalyse");

                    b.ToTable("TypeValeurs");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.RequeteAnalyse", b =>
                {
                    b.HasOne("API_AnalyseSanguine.Models.Dossier", "Dossier")
                        .WithMany("LstRequetes")
                        .HasForeignKey("DossierIdDossier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_AnalyseSanguine.Models.Medecin", "Medecin")
                        .WithMany("LstRequetes")
                        .HasForeignKey("MedecinIdMedecin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dossier");

                    b.Navigation("Medecin");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.ResultatAnalyse", b =>
                {
                    b.HasOne("API_AnalyseSanguine.Models.RequeteAnalyse", "RequeteAnalyse")
                        .WithMany("LstResultats")
                        .HasForeignKey("RequeteAnalyseIdRequete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_AnalyseSanguine.Models.TypeValeur", "TypeValeur")
                        .WithMany()
                        .HasForeignKey("TypeValeurIdTypeValeur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequeteAnalyse");

                    b.Navigation("TypeValeur");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.TypeAnalyse", b =>
                {
                    b.HasOne("API_AnalyseSanguine.Models.RequeteAnalyse", null)
                        .WithMany("LstTypeAnalyse")
                        .HasForeignKey("RequeteAnalyseIdRequete");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.TypeValeur", b =>
                {
                    b.HasOne("API_AnalyseSanguine.Models.TypeAnalyse", "TypeAnalyse")
                        .WithMany("LstValeurs")
                        .HasForeignKey("TypeAnalyseIdTypeAnalyse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeAnalyse");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.Dossier", b =>
                {
                    b.Navigation("LstRequetes");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.Medecin", b =>
                {
                    b.Navigation("LstRequetes");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.RequeteAnalyse", b =>
                {
                    b.Navigation("LstResultats");

                    b.Navigation("LstTypeAnalyse");
                });

            modelBuilder.Entity("API_AnalyseSanguine.Models.TypeAnalyse", b =>
                {
                    b.Navigation("LstValeurs");
                });
#pragma warning restore 612, 618
        }
    }
}
