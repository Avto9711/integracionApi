﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using integracion.api.Models.Context;

namespace integracion.api.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    [Migration("20181201051631_DeletedEmployeeIdInGeneralLedger")]
    partial class DeletedEmployeeIdInGeneralLedger
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("integracion.api.Models.DeductionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<bool>("Disabled");

                    b.Property<string>("Name");

                    b.Property<bool>("SalaryDepend");

                    b.HasKey("Id");

                    b.ToTable("DeductionTypes");
                });

            modelBuilder.Entity("integracion.api.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Department");

                    b.Property<bool>("Disabled");

                    b.Property<string>("Identification");

                    b.Property<string>("JobTitle");

                    b.Property<decimal>("MontSalary");

                    b.Property<string>("Name");

                    b.Property<int?>("RosterTypeId");

                    b.HasKey("Id");

                    b.HasIndex("RosterTypeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("integracion.api.Models.EntryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<bool>("Disabled");

                    b.Property<string>("Name");

                    b.Property<bool>("SalaryDepend");

                    b.HasKey("Id");

                    b.ToTable("EntryTypes");
                });

            modelBuilder.Entity("integracion.api.Models.GeneralLedger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account");

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("Disabled");

                    b.Property<int>("MovementType");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("GeneralLedgers");
                });

            modelBuilder.Entity("integracion.api.Models.RosterType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("Disabled");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RosterTypes");
                });

            modelBuilder.Entity("integracion.api.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("DeductionTypeId");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("Disabled");

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("EntryTypeId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DeductionTypeId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EntryTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("integracion.api.Models.Employee", b =>
                {
                    b.HasOne("integracion.api.Models.RosterType", "RosterType")
                        .WithMany()
                        .HasForeignKey("RosterTypeId");
                });

            modelBuilder.Entity("integracion.api.Models.Transaction", b =>
                {
                    b.HasOne("integracion.api.Models.DeductionType", "DeductionType")
                        .WithMany()
                        .HasForeignKey("DeductionTypeId");

                    b.HasOne("integracion.api.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("integracion.api.Models.EntryType", "EntryType")
                        .WithMany()
                        .HasForeignKey("EntryTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
