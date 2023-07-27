﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanzApp.Server.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230727200020_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("CategoriaGastos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("CategoriaGastos");
                });

            modelBuilder.Entity("CategoriaIngresos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("CategoriaIngresos");
                });

            modelBuilder.Entity("CuentasBancarias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreBanco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SaldoActual")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("cuentasBancarias");
                });

            modelBuilder.Entity("MetaAhorros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaLimite")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MontoObjetivo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("MetaAhorros");
                });

            modelBuilder.Entity("Transacciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoriaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("Usuarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contrasena")
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SaldoTotal")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CuentasBancarias", b =>
                {
                    b.HasOne("Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MetaAhorros", b =>
                {
                    b.HasOne("Usuarios", "Usuario")
                        .WithMany("L_MetasAhorro")
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Transacciones", b =>
                {
                    b.HasOne("CategoriaGastos", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID");

                    b.HasOne("Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Usuarios", b =>
                {
                    b.Navigation("L_MetasAhorro");
                });
#pragma warning restore 612, 618
        }
    }
}