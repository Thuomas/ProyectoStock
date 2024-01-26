﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stock.Data;

#nullable disable

namespace Stock.Migrations
{
    [DbContext(typeof(StockContext))]
    partial class StockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Stock.Models.EntregasSmt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadRestante")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrdenTrabajoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Remito")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrdenTrabajoId");

                    b.ToTable("EntregasSmt");
                });

            modelBuilder.Entity("Stock.Models.EquiposFinalizados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desde")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hasta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrdenProduccionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Restante")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrdenProduccionId");

                    b.ToTable("EquiposFinalizados");
                });

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

                    b.Property<string>("OrdenTrabajo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrdenProduccionId");

                    b.ToTable("Trabajo");
                });

            modelBuilder.Entity("Stock.Models.EntregasSmt", b =>
                {
                    b.HasOne("Stock.Models.Trabajo", "OrdenTrabajo")
                        .WithMany("Entregas")
                        .HasForeignKey("OrdenTrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdenTrabajo");
                });

            modelBuilder.Entity("Stock.Models.EquiposFinalizados", b =>
                {
                    b.HasOne("Stock.Models.Produccion", "OrdenProduccion")
                        .WithMany("EquiposFinalizados")
                        .HasForeignKey("OrdenProduccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdenProduccion");
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

            modelBuilder.Entity("Stock.Models.Produccion", b =>
                {
                    b.Navigation("EquiposFinalizados");
                });

            modelBuilder.Entity("Stock.Models.Trabajo", b =>
                {
                    b.Navigation("Entregas");
                });
#pragma warning restore 612, 618
        }
    }
}