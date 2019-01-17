﻿// <auto-generated />
using System;
using EfSamurai.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfSamurai.Data.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    [Migration("20190117141413_AddingBattleEvent")]
    partial class AddingBattleEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfSamurai.Domain.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Brutal");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("EfSamurai.Domain.BattleEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BattleLogId");

                    b.Property<string>("Description");

                    b.Property<int>("Order");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.HasIndex("BattleLogId");

                    b.ToTable("BattleEvent");
                });

            modelBuilder.Entity("EfSamurai.Domain.BattleLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BattleForeignKey");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BattleForeignKey")
                        .IsUnique();

                    b.ToTable("BattleLog");
                });

            modelBuilder.Entity("EfSamurai.Domain.Haircut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Haircuts");
                });

            modelBuilder.Entity("EfSamurai.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SamuraiId");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.HasIndex("TypeId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("EfSamurai.Domain.QuoteType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("QuoteTypes");
                });

            modelBuilder.Entity("EfSamurai.Domain.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HaircutId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HaircutId");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("EfSamurai.Domain.SamuraiBattle", b =>
                {
                    b.Property<int>("SamuraiId");

                    b.Property<int>("BattleId");

                    b.HasKey("SamuraiId", "BattleId");

                    b.HasIndex("BattleId");

                    b.ToTable("SamuraiBattle");
                });

            modelBuilder.Entity("EfSamurai.Domain.SecretIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("SamuraiForeignKey");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiForeignKey")
                        .IsUnique();

                    b.ToTable("SecretIdentity");
                });

            modelBuilder.Entity("EfSamurai.Domain.BattleEvent", b =>
                {
                    b.HasOne("EfSamurai.Domain.BattleLog")
                        .WithMany("BattleEvents")
                        .HasForeignKey("BattleLogId");
                });

            modelBuilder.Entity("EfSamurai.Domain.BattleLog", b =>
                {
                    b.HasOne("EfSamurai.Domain.Battle", "Battle")
                        .WithOne("BattleLog")
                        .HasForeignKey("EfSamurai.Domain.BattleLog", "BattleForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EfSamurai.Domain.Quote", b =>
                {
                    b.HasOne("EfSamurai.Domain.Samurai", "Samurai")
                        .WithMany("Quotes")
                        .HasForeignKey("SamuraiId");

                    b.HasOne("EfSamurai.Domain.QuoteType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("EfSamurai.Domain.Samurai", b =>
                {
                    b.HasOne("EfSamurai.Domain.Haircut", "Haircut")
                        .WithMany()
                        .HasForeignKey("HaircutId");
                });

            modelBuilder.Entity("EfSamurai.Domain.SamuraiBattle", b =>
                {
                    b.HasOne("EfSamurai.Domain.Battle", "Battle")
                        .WithMany()
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EfSamurai.Domain.Samurai", "Samurai")
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EfSamurai.Domain.SecretIdentity", b =>
                {
                    b.HasOne("EfSamurai.Domain.Samurai", "Samurai")
                        .WithOne("SecretIdentity")
                        .HasForeignKey("EfSamurai.Domain.SecretIdentity", "SamuraiForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
