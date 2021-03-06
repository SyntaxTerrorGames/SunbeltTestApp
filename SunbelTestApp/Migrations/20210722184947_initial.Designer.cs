// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SunbeltTestApp.Data;

namespace SunbeltTestApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210722184947_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Attendee", b =>
                {
                    b.Property<long>("AttendeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttendeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<long?>("PartyId")
                        .HasColumnType("bigint");

                    b.HasKey("AttendeeId");

                    b.HasIndex("DrinkId");

                    b.HasIndex("PartyId");

                    b.ToTable("Attendees");
                });

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

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Attendee", b =>
                {
                    b.HasOne("SunbeltTestApp.EFMigrations.Drink", "Drink")
                        .WithMany("Attendees")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SunbeltTestApp.EFMigrations.Party", null)
                        .WithMany("Attendees")
                        .HasForeignKey("PartyId");

                    b.Navigation("Drink");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Drink", b =>
                {
                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("SunbeltTestApp.EFMigrations.Party", b =>
                {
                    b.Navigation("Attendees");
                });
#pragma warning restore 612, 618
        }
    }
}
