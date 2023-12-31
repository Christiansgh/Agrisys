﻿// <auto-generated />
using System;
using Agrisys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agrisys.Migrations.HomeDb
{
    [DbContext(typeof(HomeDbContext))]
    [Migration("20231205175704_InitialHomeDb")]
    partial class InitialHomeDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Agrisys.Models.HomeViewModel", b =>
                {
                    b.Property<int>("HomeViewModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("DistributorAmount")
                        .HasColumnType("REAL");

                    b.Property<int?>("DistributorState")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("FanAmount")
                        .HasColumnType("REAL");

                    b.Property<int?>("FanState")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HatchOneState")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HatchTwoState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LogMessages")
                        .HasColumnType("TEXT");

                    b.Property<double?>("MixerAmount")
                        .HasColumnType("REAL");

                    b.Property<int?>("MixerState")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Pressure")
                        .HasColumnType("REAL");

                    b.Property<double?>("SiloAmount")
                        .HasColumnType("REAL");

                    b.Property<int?>("SiloState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TargetId")
                        .HasColumnType("TEXT");

                    b.HasKey("HomeViewModelId");

                    b.ToTable("HomeViewModels");
                });
#pragma warning restore 612, 618
        }
    }
}
