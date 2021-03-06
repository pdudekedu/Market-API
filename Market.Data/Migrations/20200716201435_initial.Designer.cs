﻿// <auto-generated />
using System;
using Market.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Market.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200716201435_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Market.Models.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_ASSETS");

                    b.ToTable("ASSETS");
                });

            modelBuilder.Entity("Market.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_PROPERTIES");

                    b.ToTable("PROPERTIES");
                });

            modelBuilder.Entity("Market.Models.PropertyValue", b =>
                {
                    b.Property<int>("AssetId")
                        .HasColumnName("ASSETID")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnName("PROPERTYID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TIMESTAMP")
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<bool>("Value")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VALUE")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("AssetId", "PropertyId")
                        .HasName("PK_PROPERTIES_VALUES");

                    b.HasIndex("PropertyId");

                    b.ToTable("PROPERTIES_VALUES");
                });

            modelBuilder.Entity("Market.Models.PropertyValue", b =>
                {
                    b.HasOne("Market.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .HasConstraintName("FK_PROPERTIES_VALUES_ASSETS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Market.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_PROPERTIES_VALUES_PROPERTIES")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
