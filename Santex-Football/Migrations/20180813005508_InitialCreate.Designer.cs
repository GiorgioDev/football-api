﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Santex_Football.Database;

namespace SantexFootball.Web.Migrations
{
    [DbContext(typeof(LeagueContext))]
    [Migration("20180813005508_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Santex_Football.Database.Models.ImportedLeague", b =>
                {
                    b.Property<string>("LeagueCodeId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("LeagueCodeId");

                    b.ToTable("ImportedLeagues");
                });

            modelBuilder.Entity("Santex_Football.Database.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption");

                    b.Property<string>("LeagueCode");

                    b.Property<string>("Year");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Santex_Football.Database.Models.LeagueCode", b =>
                {
                    b.Property<string>("LeagueCodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("LeagueDescription");

                    b.HasKey("LeagueCodeId");

                    b.ToTable("LeagueCodes");
                });

            modelBuilder.Entity("Santex_Football.Database.Models.LeagueTeam", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("LeagueId");

                    b.HasKey("TeamId", "LeagueId");

                    b.HasIndex("LeagueId");

                    b.ToTable("LeagueTeam");
                });

            modelBuilder.Entity("Santex_Football.Database.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractUntil");

                    b.Property<string>("DateOfBirth");

                    b.Property<int>("JerseyNumber");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<string>("Position");

                    b.Property<int>("TeamId");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Santex_Football.Database.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("LeagueId");

                    b.Property<string>("Name");

                    b.Property<string>("Shortname");

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Santex_Football.Database.Models.LeagueTeam", b =>
                {
                    b.HasOne("Santex_Football.Database.Models.League", "League")
                        .WithMany("LeagueTeams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Santex_Football.Database.Models.Team", "Team")
                        .WithMany("LeagueTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Santex_Football.Database.Models.Player", b =>
                {
                    b.HasOne("Santex_Football.Database.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Santex_Football.Database.Models.Team", b =>
                {
                    b.HasOne("Santex_Football.Database.Models.League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}