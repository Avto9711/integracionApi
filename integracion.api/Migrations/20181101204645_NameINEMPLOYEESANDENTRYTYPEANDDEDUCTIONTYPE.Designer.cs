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
    [Migration("20181101204645_NameINEMPLOYEESANDENTRYTYPEANDDEDUCTIONTYPE")]
    partial class NameINEMPLOYEESANDENTRYTYPEANDDEDUCTIONTYPE
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

                    b.Property<string>("Name");

                    b.Property<bool>("SalaryDepend");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("DeductionTypes");
                });

            modelBuilder.Entity("integracion.api.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department");

                    b.Property<string>("Identification");

                    b.Property<string>("JobTitle");

                    b.Property<decimal>("MontSalary");

                    b.Property<string>("Name");

                    b.Property<int?>("RosterId");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("integracion.api.Models.EntryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<bool>("SalaryDepend");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("EntryTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
