﻿// <auto-generated />
using System;
using EstudiantePrestamoReportes.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstudiantePrestamoReportes.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("EstudiantePrestamoReportes.Entidades.EstudianteDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Calificacion")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("FechaEvaluacion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoEvaluacion")
                        .HasColumnType("TEXT");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("Matricula");

                    b.ToTable("EstudianteDetalle");
                });

            modelBuilder.Entity("EstudiantePrestamoReportes.Entidades.Estudiantes", b =>
                {
                    b.Property<int>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("CalifMax")
                        .HasColumnType("REAL");

                    b.Property<float>("CalifMin")
                        .HasColumnType("REAL");

                    b.Property<float>("CalifPromedio")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<float>("TotalPts")
                        .HasColumnType("REAL");

                    b.HasKey("Matricula");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("EstudiantePrestamoReportes.Entidades.Prestamos", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConceptoPrestamo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.HasKey("IdPrestamo");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("EstudiantePrestamoReportes.Entidades.EstudianteDetalle", b =>
                {
                    b.HasOne("EstudiantePrestamoReportes.Entidades.Estudiantes", null)
                        .WithMany("estudianteDetalles")
                        .HasForeignKey("Matricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
