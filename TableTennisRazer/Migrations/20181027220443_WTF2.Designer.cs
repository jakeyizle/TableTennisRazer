﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TableTennisRazer.Models;

namespace TableTennisRazer.Migrations
{
    [DbContext(typeof(TableTennisRazerContext))]
    [Migration("20181027220443_WTF2")]
    partial class WTF2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TableTennisRazer.Models.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LosingScore");

                    b.Property<int>("WinningScore");

                    b.HasKey("MatchID");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("TableTennisRazer.Models.MatchPerson", b =>
                {
                    b.Property<int>("MatchPersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchId");

                    b.Property<int>("PersonId");

                    b.HasKey("MatchPersonId");

                    b.HasIndex("MatchId");

                    b.HasIndex("PersonId");

                    b.ToTable("MatchPerson");
                });

            modelBuilder.Entity("TableTennisRazer.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Mean");

                    b.Property<string>("Name");

                    b.Property<double>("StandardDeviation");

                    b.HasKey("PersonId");

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
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
