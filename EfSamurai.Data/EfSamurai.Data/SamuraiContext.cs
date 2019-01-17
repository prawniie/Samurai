﻿using System;
using EfSamurai.Domain;
using Microsoft.EntityFrameworkCore;


namespace EfSamurai.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Haircut> Haircuts { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteType> QuoteTypes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = EfSamurai;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>()
                .HasOne(p => p.SecretIdentity)
                .WithOne(i => i.Samurai)
                .HasForeignKey<SecretIdentity>(s => s.SamuraiForeignKey);

            modelBuilder.Entity<SamuraiBattle>().
                HasKey(x => new { x.SamuraId, x.BattleId });
            //base.OnModelCreating;
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
