﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PcMarket.Data;

namespace PcMarket.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210204133353_AddEnum")]
    partial class AddEnum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("PcMarket.Models.PcComputerProp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AutoDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BuildPrice")
                        .HasColumnType("int");

                    b.Property<string>("Case")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPUName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPUType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemoryType")
                        .HasColumnType("int");

                    b.Property<string>("Motherboard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PowerSupply")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcesorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcesorType")
                        .HasColumnType("int");

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StorageType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("GetComputers");
                });

            modelBuilder.Entity("PcMarket.Models.PcPartOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateTimeNow")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<string>("PartName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartPrice")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GetOrders");
                });

            modelBuilder.Entity("PcMarket.Models.PcPartProp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartCategory")
                        .HasColumnType("int");

                    b.Property<int>("PartCondition")
                        .HasColumnType("int");

                    b.Property<string>("PartDescribtion")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartOrBuild")
                        .HasColumnType("int");

                    b.Property<int>("PartPrice")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("GetPcParts");
                });
#pragma warning restore 612, 618
        }
    }
}
