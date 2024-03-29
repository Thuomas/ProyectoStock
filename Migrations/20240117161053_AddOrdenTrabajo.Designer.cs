﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stock.Data;

#nullable disable

namespace Stock.Migrations
{
    [DbContext(typeof(StockContext))]
    [Migration("20240117161053_AddOrdenTrabajo")]
    partial class AddOrdenTrabajo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Stock.Models.Produccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Equipo")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrdenProduccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Produccion");
                });

            modelBuilder.Entity("Stock.Models.Trabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Equipo")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrdenProduccionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrdenProduccionId");

                    b.ToTable("Trabajo");
                });

            modelBuilder.Entity("Stock.Models.Trabajo", b =>
                {
                    b.HasOne("Stock.Models.Produccion", "OrdenProduccion")
                        .WithMany()
                        .HasForeignKey("OrdenProduccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdenProduccion");
                });
#pragma warning restore 612, 618
        }
    }
}
