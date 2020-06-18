﻿// <auto-generated />
using System;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(ChampionshipDbContext))]
    [Migration("20200618105551_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kolokwium2.Models.Championship", b =>
                {
                    b.Property<int>("IdChampionship")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OfficialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("IdChampionship");

                    b.ToTable("Championships");
                });

            modelBuilder.Entity("Kolokwium2.Models.ChampionshipTeam", b =>
                {
                    b.Property<int>("IdChampionship")
                        .HasColumnType("int");

                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.HasKey("IdChampionship");

                    b.HasIndex("IdTeam");

                    b.ToTable("ChampionshipTeams");
                });

            modelBuilder.Entity("Kolokwium2.Models.Player", b =>
                {
                    b.Property<int>("IdPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdPlayer");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Kolokwium2.Models.PlayerTeam", b =>
                {
                    b.Property<int>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPlayer")
                        .HasColumnType("int");

                    b.Property<int>("NumOnShirt")
                        .HasColumnType("int");

                    b.Property<int?>("TeamIdTeam")
                        .HasColumnType("int");

                    b.HasKey("IdTeam");

                    b.HasIndex("IdPlayer");

                    b.HasIndex("TeamIdTeam");

                    b.ToTable("PlayerTeams");
                });

            modelBuilder.Entity("Kolokwium2.Models.Team", b =>
                {
                    b.Property<int>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdTeam");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Kolokwium2.Models.ChampionshipTeam", b =>
                {
                    b.HasOne("Kolokwium2.Models.Championship", "Championship")
                        .WithMany("ChampionshipTeams")
                        .HasForeignKey("IdChampionship")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Team", "Team")
                        .WithMany("ChampionshipTeams")
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kolokwium2.Models.PlayerTeam", b =>
                {
                    b.HasOne("Kolokwium2.Models.Player", "Player")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("IdPlayer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Team", "Team")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("TeamIdTeam");
                });
#pragma warning restore 612, 618
        }
    }
}
