﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RouletteGameAPI.Databases;

#nullable disable

namespace RouletteGameAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("RouletteGameAPI.Models.Bet", b =>
                {
                    b.Property<int>("BetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Payout")
                        .HasColumnType("TEXT");

                    b.Property<int>("PutOn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RouletteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BetId");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("RouletteGameAPI.Models.Roulette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("WinningNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Roulette");
                });
#pragma warning restore 612, 618
        }
    }
}
