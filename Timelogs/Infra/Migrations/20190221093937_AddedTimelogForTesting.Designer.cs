﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(TimelogDBContext))]
    [Migration("20190221093937_AddedTimelogForTesting")]
    partial class AddedTimelogForTesting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Departments", b =>
                {
                    b.Property<Guid>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Domain.Models.Employees", b =>
                {
                    b.Property<string>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DepartmentID");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Domain.Models.Timelog", b =>
                {
                    b.Property<Guid>("LogID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeID");

                    b.Property<string>("State");

                    b.Property<DateTime>("Time");

                    b.HasKey("LogID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Timelog");
                });

            modelBuilder.Entity("Domain.Models.Employees", b =>
                {
                    b.HasOne("Domain.Models.Departments", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.Timelog", b =>
                {
                    b.HasOne("Domain.Models.Employees", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");
                });
#pragma warning restore 612, 618
        }
    }
}
