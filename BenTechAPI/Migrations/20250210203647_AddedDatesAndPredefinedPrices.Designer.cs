﻿// <auto-generated />
using System;
using BenTechAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BenTechAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20250210203647_AddedDatesAndPredefinedPrices")]
    partial class AddedDatesAndPredefinedPrices
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BenTechAPI.Models.Dates", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ColorCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("predefinedPricesColorCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Date");

                    b.HasIndex("predefinedPricesColorCode");

                    b.ToTable("dates");
                });

            modelBuilder.Entity("BenTechAPI.Models.PredefinedPrices", b =>
                {
                    b.Property<string>("ColorCode")
                        .HasColumnType("varchar(10)");

                    b.Property<double>("Child03To06_value")
                        .HasColumnType("float");

                    b.Property<double>("Child07To10_value")
                        .HasColumnType("float");

                    b.Property<double>("Double_value")
                        .HasColumnType("float");

                    b.Property<double>("Quadruple_value")
                        .HasColumnType("float");

                    b.Property<double>("Quintuple_value")
                        .HasColumnType("float");

                    b.Property<double>("Single_value")
                        .HasColumnType("float");

                    b.Property<double>("Triple_value")
                        .HasColumnType("float");

                    b.HasKey("ColorCode");

                    b.ToTable("PredefinedPrices");
                });

            modelBuilder.Entity("BenTechAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BenTechAPI.Models.Dates", b =>
                {
                    b.HasOne("BenTechAPI.Models.PredefinedPrices", "predefinedPrices")
                        .WithMany()
                        .HasForeignKey("predefinedPricesColorCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("predefinedPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
