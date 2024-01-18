﻿// <auto-generated />
using System;
using HRSystemAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRSystemAPI.Migrations
{
    [DbContext(typeof(HRDbContext))]
    [Migration("20240118211714_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRSystemAPI.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HRSystemAPI.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Address")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("SalaryId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("SalaryId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("HRSystemAPI.Model.PersonDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("PersonDetails");
                });

            modelBuilder.Entity("HRSystemAPI.Model.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("HRSystemAPI.Model.Salary", b =>
                {
                    b.Property<int>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalaryId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("SalaryId");

                    b.ToTable("Salarys");
                });

            modelBuilder.Entity("HRSystemAPI.Model.Person", b =>
                {
                    b.HasOne("HRSystemAPI.Model.Position", "Position")
                        .WithMany("Persons")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRSystemAPI.Model.Salary", "Salary")
                        .WithMany("Persons")
                        .HasForeignKey("SalaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("HRSystemAPI.Model.PersonDetails", b =>
                {
                    b.HasOne("HRSystemAPI.Model.Person", "Person")
                        .WithOne("PersonDetails")
                        .HasForeignKey("HRSystemAPI.Model.PersonDetails", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HRSystemAPI.Model.Position", b =>
                {
                    b.HasOne("HRSystemAPI.Model.Department", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HRSystemAPI.Model.Department", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("HRSystemAPI.Model.Person", b =>
                {
                    b.Navigation("PersonDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("HRSystemAPI.Model.Position", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("HRSystemAPI.Model.Salary", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
