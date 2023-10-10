﻿// <auto-generated />
using System;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FirstAPI.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20230926052809_EmployeePic")]
    partial class EmployeePic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FirstAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Pic")
                        .HasColumnType("text");

                    b.Property<float?>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Username");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Age = 21,
                            Name = "Ramu",
                            Phone = "1234567890",
                            Salary = 12345.6f
                        },
                        new
                        {
                            Id = 102,
                            Age = 27,
                            Name = "Somu",
                            Phone = "9876543210",
                            Salary = 54321.6f
                        });
                });

            modelBuilder.Entity("FirstAPI.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<byte[]>("Key")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("users");
                });

            modelBuilder.Entity("FirstAPI.Models.Employee", b =>
                {
                    b.HasOne("FirstAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
