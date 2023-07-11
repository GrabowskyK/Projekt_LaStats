﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_LaStats.Context;

#nullable disable

namespace Projekt_LaStats.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230711184215_AddBilanceToTeam")]
    partial class AddBilanceToTeam
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projekt_LaStats.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("PenaltyMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("PenaltyType")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerAssistId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerEventId")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerAssistId");

                    b.HasIndex("PlayerEventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScoreGuestTeam")
                        .HasColumnType("int");

                    b.Property<int>("ScoreHomeTeam")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Assist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("DateBorn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Goals")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("MinutesPenalty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Penalty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("ShirtNumber")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("LostGoals")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScoredGoals")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("draw")
                        .HasColumnType("int");

                    b.Property<int>("lose")
                        .HasColumnType("int");

                    b.Property<int>("points")
                        .HasColumnType("int");

                    b.Property<int>("wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.Event", b =>
                {
                    b.HasOne("Projekt_LaStats.Models.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_LaStats.Models.Player", "PlayerAssist")
                        .WithMany()
                        .HasForeignKey("PlayerAssistId");

                    b.HasOne("Projekt_LaStats.Models.Player", "PlayerEvent")
                        .WithMany()
                        .HasForeignKey("PlayerEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("PlayerAssist");

                    b.Navigation("PlayerEvent");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.Match", b =>
                {
                    b.HasOne("Projekt_LaStats.Models.Team", "GuestTeam")
                        .WithMany("TeamAway")
                        .HasForeignKey("GuestTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Projekt_LaStats.Models.Team", "HomeTeam")
                        .WithMany("TeamHost")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GuestTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.Player", b =>
                {
                    b.HasOne("Projekt_LaStats.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.Team", b =>
                {
                    b.HasOne("Projekt_LaStats.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("Projekt_LaStats.Models.Team", b =>
                {
                    b.Navigation("TeamAway");

                    b.Navigation("TeamHost");
                });
#pragma warning restore 612, 618
        }
    }
}
