﻿// <auto-generated />
using CastlesToWatch.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CastlesToWatch.API.Migrations
{
    [DbContext(typeof(CastlesDbContext))]
    partial class CastlesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CastlesToWatch.API.Model.Castle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Castles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Staroscinska 1, 82-200 Malbork",
                            CountryId = 3,
                            Name = "Zamek Krzyzacki Malbork",
                            Rating = 5.0
                        },
                        new
                        {
                            Id = 2,
                            Address = " Piazza Castello, 20121 Milano",
                            CountryId = 1,
                            Name = "Castello Sforzesco",
                            Rating = 4.0
                        },
                        new
                        {
                            Id = 3,
                            Address = "Zamkowa, 42-440 Podzamcze",
                            CountryId = 3,
                            Name = "Zamek Ogrodzieniec",
                            Rating = 3.0
                        });
                });

            modelBuilder.Entity("CastlesToWatch.API.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Italy",
                            ShortName = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spain",
                            ShortName = "ES"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Poland",
                            ShortName = "PL"
                        });
                });

            modelBuilder.Entity("CastlesToWatch.API.Model.Castle", b =>
                {
                    b.HasOne("CastlesToWatch.API.Model.Country", "Country")
                        .WithMany("Castles")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CastlesToWatch.API.Model.Country", b =>
                {
                    b.Navigation("Castles");
                });
#pragma warning restore 612, 618
        }
    }
}
