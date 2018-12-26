﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ArmadaContext))]
    [Migration("20181226210748_AddGameStatusToGame")]
    partial class AddGameStatusToGame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("GameStatus")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Height")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(100);

                    b.Property<int>("Width")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(100);

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorizationCode")
                        .IsRequired();

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<int?>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Data.Entities.Player", b =>
                {
                    b.HasOne("Data.Entities.Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId");
                });
#pragma warning restore 612, 618
        }
    }
}