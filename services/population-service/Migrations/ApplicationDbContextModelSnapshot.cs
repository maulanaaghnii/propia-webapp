﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using population_service.Data;

#nullable disable

namespace population_service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("varchar(12)")
                        .HasColumnName("birth_date")
                        .HasAnnotation("Relational:JsonPropertyName", "birth_date");

                    b.Property<string>("BirthTime")
                        .HasColumnType("varchar(6)")
                        .HasColumnName("birth_time")
                        .HasAnnotation("Relational:JsonPropertyName", "birth_time");

                    b.Property<string>("BloodType")
                        .HasColumnType("varchar(3)")
                        .HasColumnName("blood_type")
                        .HasAnnotation("Relational:JsonPropertyName", "blood_type");

                    b.Property<string>("EyeColor")
                        .HasColumnType("varchar(3)")
                        .HasColumnName("eye_color")
                        .HasAnnotation("Relational:JsonPropertyName", "eye_color");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name")
                        .HasAnnotation("Relational:JsonPropertyName", "first_name");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("gender")
                        .HasAnnotation("Relational:JsonPropertyName", "gender");

                    b.Property<string>("Handedness")
                        .HasColumnType("varchar(1)")
                        .HasColumnName("handedness")
                        .HasAnnotation("Relational:JsonPropertyName", "handedness");

                    b.Property<string>("IsDelete")
                        .HasColumnType("varchar(1)")
                        .HasColumnName("is_delete")
                        .HasAnnotation("Relational:JsonPropertyName", "is_delete");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name")
                        .HasAnnotation("Relational:JsonPropertyName", "last_name");

                    b.HasKey("Id");

                    b.ToTable("tbldenizen");
                });
#pragma warning restore 612, 618
        }
    }
}
