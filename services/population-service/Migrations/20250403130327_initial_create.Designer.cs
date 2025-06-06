﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using population_service.Data;

#nullable disable

namespace population_service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250403130327_initial_create")]
    partial class initial_create
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("population_service.Models.Denizen", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("BirthDate")
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("Relational:JsonPropertyName", "birth_date");

                    b.Property<string>("BloodType")
                        .HasColumnType("varchar(5)")
                        .HasAnnotation("Relational:JsonPropertyName", "blood_type");

                    b.Property<string>("EyeColor")
                        .HasColumnType("varchar(5)")
                        .HasAnnotation("Relational:JsonPropertyName", "eye_color");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "first_name");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("Relational:JsonPropertyName", "gender");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "last_name");

                    b.HasKey("Id");

                    b.ToTable("tbldenizen");
                });
#pragma warning restore 612, 618
        }
    }
}
