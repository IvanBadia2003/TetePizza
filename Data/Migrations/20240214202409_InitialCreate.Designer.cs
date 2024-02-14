﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TetePizza.Data;

#nullable disable

namespace TetePizza.Data.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20240214202409_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TetePizza.Models.Ingrediente", b =>
                {
                    b.Property<int>("IngredienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredienteId"), 1L, 1);

                    b.Property<string>("NombreIngrediente")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(150)");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredienteId");

                    b.ToTable("Ingrediente");

                    b.HasData(
                        new
                        {
                            IngredienteId = 1,
                            NombreIngrediente = "Piña",
                            Origen = "Vegetal"
                        },
                        new
                        {
                            IngredienteId = 2,
                            NombreIngrediente = "Jamón york",
                            Origen = "Animal"
                        },
                        new
                        {
                            IngredienteId = 3,
                            NombreIngrediente = "Carne picada",
                            Origen = "Animal"
                        });
                });

            modelBuilder.Entity("TetePizza.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaID"), 1L, 1);

                    b.Property<string>("IsGlutenFree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PizzaID");

                    b.ToTable("Pizza");

                    b.HasData(
                        new
                        {
                            PizzaID = 1,
                            IsGlutenFree = "yes",
                            Nombre = "Hawaiana"
                        },
                        new
                        {
                            PizzaID = 2,
                            IsGlutenFree = "yes",
                            Nombre = "Barbacoa"
                        });
                });

            modelBuilder.Entity("TetePizza.Models.PizzaIngrediente", b =>
                {
                    b.Property<int>("PizzaID")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteID")
                        .HasColumnType("int");

                    b.HasKey("PizzaID", "IngredienteID");

                    b.HasIndex("IngredienteID");

                    b.ToTable("PizzaIngrediente");

                    b.HasData(
                        new
                        {
                            PizzaID = 1,
                            IngredienteID = 1
                        },
                        new
                        {
                            PizzaID = 1,
                            IngredienteID = 2
                        },
                        new
                        {
                            PizzaID = 2,
                            IngredienteID = 3
                        });
                });

            modelBuilder.Entity("TetePizza.Models.PizzaIngrediente", b =>
                {
                    b.HasOne("TetePizza.Models.Ingrediente", "Ingrediente")
                        .WithMany("PizzaIngredientes")
                        .HasForeignKey("IngredienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TetePizza.Models.Pizza", "Pizza")
                        .WithMany("PizzaIngredientes")
                        .HasForeignKey("PizzaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("TetePizza.Models.Ingrediente", b =>
                {
                    b.Navigation("PizzaIngredientes");
                });

            modelBuilder.Entity("TetePizza.Models.Pizza", b =>
                {
                    b.Navigation("PizzaIngredientes");
                });
#pragma warning restore 612, 618
        }
    }
}