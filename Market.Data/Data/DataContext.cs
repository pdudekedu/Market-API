using Market.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Market.Data
{
    /// <summary>
    /// Main DB context.
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /// <summary>
        /// Table of assets.
        /// </summary>
        public DbSet<Asset> Assets { get; set; }
        /// <summary>
        /// Table of properties.
        /// </summary>
        public DbSet<Property> Properties { get; set; }
        /// <summary>
        /// Table of property values.
        /// </summary>
        public DbSet<PropertyValue> PropertiesValues { get; set; }
        /// <summary>
        /// Configures DB structure.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataSeeder dataSeeder = new DataSeeder();
            var assetsToSeed = dataSeeder.GetAssets(20).ToList();
            var propertiesToSeed = dataSeeder.GetProperties();

            modelBuilder.Entity<Asset>(asset =>
            {
                asset
                    .ToTable("ASSETS")
                    .HasKey(x => x.Id)
                        .HasName("PK_ASSETS");
                asset
                    .Property(x => x.Id)
                        .HasColumnName("ID")
                        .IsRequired();
                asset
                    .Property(x => x.Name)
                        .HasColumnName("NAME")
                        .IsRequired();

                asset.HasData(assetsToSeed);
            });

            modelBuilder.Entity<Property>(property =>
            {
                property
                    .ToTable("PROPERTIES")
                    .HasKey(x => x.Id)
                        .HasName("PK_PROPERTIES");
                property
                    .Property(x => x.Id)
                        .HasColumnName("ID")
                        .IsRequired();
                property
                    .Property(x => x.Name)
                        .HasColumnName("NAME")
                        .IsRequired();

                property.HasData(propertiesToSeed);
            });

            modelBuilder.Entity<PropertyValue>(propertyValue =>
            {
                propertyValue
                    .ToTable("PROPERTIES_VALUES")
                    .HasKey(x => new { x.AssetId, x.PropertyId })
                        .HasName("PK_PROPERTIES_VALUES");

                propertyValue
                    .Property(x => x.AssetId)
                        .HasColumnName("ASSETID")
                        .IsRequired();
                propertyValue
                    .HasOne(x => x.Asset)
                    .WithMany()
                    .HasForeignKey(x => x.AssetId)
                        .HasConstraintName("FK_PROPERTIES_VALUES_ASSETS");

                propertyValue
                    .Property(x => x.PropertyId)
                        .HasColumnName("PROPERTYID")
                        .IsRequired();
                propertyValue
                    .HasOne(x => x.Property)
                    .WithMany()
                    .HasForeignKey(x => x.PropertyId)
                        .HasConstraintName("FK_PROPERTIES_VALUES_PROPERTIES");

                propertyValue
                    .Property(x => x.Value)
                        .HasColumnName("VALUE")
                        .IsRequired()
                        .HasDefaultValue(false)
                        .IsConcurrencyToken();

                propertyValue
                    .Property(x => x.Timestamp)
                        .HasColumnName("TIMESTAMP")
                        .IsRequired()
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValue(DateTime.MinValue)
                        .IsConcurrencyToken();

                propertyValue.HasData(dataSeeder.GetPropertyValues(assetsToSeed, propertiesToSeed));
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
