﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TableTennisRazer.Models;

namespace TableTennisRazer.Migrations
{
    [DbContext(typeof(TableTennisRazerContext))]
    [Migration("20181105192855_MatchShit6")]
    partial class MatchShit6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TableTennisRazer.Models.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LosingScore");

                    b.Property<int?>("WinningScore");

                    b.HasKey("MatchID");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("TableTennisRazer.Models.MatchPerson", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("MatchId");

                    b.Property<int>("MatchResult");

                    b.Property<string>("PersonName")
                        .IsRequired();

                    b.HasKey("PersonId", "MatchId");

                    b.HasIndex("MatchId");

                    b.HasIndex("PersonName");

                    b.ToTable("MatchPerson");
                });

            modelBuilder.Entity("TableTennisRazer.Models.Person", b =>
                {
                    b.Property<string>("PersonName")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Mean");

                    b.Property<double>("StandardDeviation");

                    b.HasKey("PersonName");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("TableTennisRazer.Models.MatchPerson", b =>
                {
                    b.HasOne("TableTennisRazer.Models.Match", "Match")
                        .WithMany("MatchPeople")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TableTennisRazer.Models.Person", "Person")
                        .WithMany("MatchPeople")
                        .HasForeignKey("PersonName")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
