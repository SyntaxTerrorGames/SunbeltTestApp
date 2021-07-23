﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SunbeltTestApp.Data;

namespace SunbeltTestApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrinkId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Party", b =>
                {
                    b.Property<long>("PartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PartyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PartyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartyId");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.PartyAttendee", b =>
                {
                    b.Property<long>("PartyAttendeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<long>("PartyId")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("PartyAttendeeId");

                    b.HasIndex("DrinkId");

                    b.HasIndex("PartyId");

                    b.HasIndex("PersonId");

                    b.ToTable("PartyAttendees");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PartyId")
                        .HasColumnType("bigint");

                    b.HasKey("PersonId");

                    b.HasIndex("PartyId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.PartyAttendee", b =>
                {
                    b.HasOne("SunbeltTestApp.EFMigrations.Drink", "Drink")
                        .WithMany("PartyAttendees")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SunbeltTestApp.EFMigrations.Party", "Party")
                        .WithMany()
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SunbeltTestApp.EFMigrations.Person", "Person")
                        .WithMany("PartyAttendees")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Party");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Person", b =>
                {
                    b.HasOne("SunbeltTestApp.EFMigrations.Party", null)
                        .WithMany("People")
                        .HasForeignKey("PartyId");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Drink", b =>
                {
                    b.Navigation("PartyAttendees");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Party", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Person", b =>
                {
                    b.Navigation("PartyAttendees");
                });
#pragma warning restore 612, 618
        }
    }
}
