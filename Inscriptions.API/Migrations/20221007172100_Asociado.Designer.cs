﻿// <auto-generated />
using System;
using Inscriptions.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inscriptions.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221007172100_Asociado")]
    partial class Asociado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inscriptions.API.Data.Entities.Asociado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("HasInscription");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Zona")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Cedula")
                        .IsUnique();

                    b.ToTable("Asociados");
                });
#pragma warning restore 612, 618
        }
    }
}