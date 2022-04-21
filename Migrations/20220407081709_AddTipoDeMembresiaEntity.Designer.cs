﻿// <auto-generated />
using MVC.BaseDeDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20220407081709_AddTipoDeMembresiaEntity")]
    partial class AddTipoDeMembresiaEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaSubscritoAlBoletinInformativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("TipoMembresiaId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("TipoMembresiaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MVC.Models.TipoMembresia", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Descuento")
                        .HasColumnType("tinyint");

                    b.Property<byte>("DuracionEnMeses")
                        .HasColumnType("tinyint");

                    b.Property<short>("TarifaDeRegistro")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("TipoMembresia");
                });

            modelBuilder.Entity("MVC.Models.Cliente", b =>
                {
                    b.HasOne("MVC.Models.TipoMembresia", "TipoMembresia")
                        .WithMany()
                        .HasForeignKey("TipoMembresiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
