﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Data;

#nullable disable

namespace test.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240621141048_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("test.Models.Backpack", b =>
                {
                    b.Property<int>("IdCharacter")
                        .HasColumnType("int");

                    b.Property<int>("IdItem")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("IdCharacter", "IdItem");

                    b.HasIndex("IdItem");

                    b.ToTable("backpack");

                    b.HasData(
                        new
                        {
                            IdCharacter = 1,
                            IdItem = 1,
                            Amount = 2
                        });
                });

            modelBuilder.Entity("test.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrWeight = 5,
                            FirstName = "To",
                            LastName = "Ja",
                            MaxWeight = 20
                        });
                });

            modelBuilder.Entity("test.Models.CharacterTitle", b =>
                {
                    b.Property<int>("IdCharacter")
                        .HasColumnType("int");

                    b.Property<int>("IdTitle")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCharacter", "IdTitle");

                    b.HasIndex("IdTitle");

                    b.ToTable("charactertitle");

                    b.HasData(
                        new
                        {
                            IdCharacter = 1,
                            IdTitle = 1,
                            AcquiredAt = new DateTime(2024, 6, 21, 16, 10, 47, 308, DateTimeKind.Local).AddTicks(7535)
                        });
                });

            modelBuilder.Entity("test.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("item");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "lol",
                            Weight = 3
                        });
                });

            modelBuilder.Entity("test.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("title");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "elo"
                        });
                });

            modelBuilder.Entity("test.Models.Backpack", b =>
                {
                    b.HasOne("test.Models.Character", "Character")
                        .WithMany("Backpacks")
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test.Models.Item", "Item")
                        .WithMany("Backpacks")
                        .HasForeignKey("IdItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("test.Models.CharacterTitle", b =>
                {
                    b.HasOne("test.Models.Character", "Character")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test.Models.Title", "Title")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("IdTitle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("test.Models.Character", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("test.Models.Item", b =>
                {
                    b.Navigation("Backpacks");
                });

            modelBuilder.Entity("test.Models.Title", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
