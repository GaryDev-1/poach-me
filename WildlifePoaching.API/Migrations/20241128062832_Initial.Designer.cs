﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WildlifePoaching.API.Data;

#nullable disable

namespace WildlifePoaching.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241128062832_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AcquisitionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AnimalType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("AnimalTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcquisitionDate");

                    b.HasIndex("AnimalTypeId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("LocationId");

                    b.HasIndex("Name");

                    b.ToTable("Animals", (string)null);

                    b.HasDiscriminator<string>("AnimalType").HasValue("Animal");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.AnimalImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("IsPrimary");

                    b.ToTable("AnimalImages", (string)null);
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SpecialRequirements")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Category");

                    b.HasIndex("Name");

                    b.ToTable("AnimalTypes", (string)null);
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SecurityLevel")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("City");

                    b.HasIndex("Country");

                    b.HasIndex("SecurityLevel");

                    b.HasIndex("Latitude", "Longitude");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("Status");

                    b.HasIndex("TransactionDate");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoginAttempts")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("RefreshTokenExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[IsDeleted] = 0");

                    b.HasIndex("RefreshToken");

                    b.HasIndex("RoleId");

                    b.HasIndex("Status");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[IsDeleted] = 0");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId", "Permission")
                        .IsUnique();

                    b.ToTable("UserPermissions", (string)null);
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Animals.Dog", b =>
                {
                    b.HasBaseType("WildlifePoaching.API.Models.Domain.Animal");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsTrainable")
                        .HasColumnType("bit");

                    b.HasIndex("Breed");

                    b.HasDiscriminator().HasValue("Dog");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Animals.Fish", b =>
                {
                    b.HasBaseType("WildlifePoaching.API.Models.Domain.Animal");

                    b.Property<float>("OptimalTemperature")
                        .HasColumnType("real");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WaterType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("Species");

                    b.HasIndex("WaterType");

                    b.HasDiscriminator().HasValue("Fish");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Animals.Tiger", b =>
                {
                    b.HasBaseType("WildlifePoaching.API.Models.Domain.Animal");

                    b.Property<bool>("IsWild")
                        .HasColumnType("bit");

                    b.Property<string>("Subspecies")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasIndex("Subspecies");

                    b.HasDiscriminator().HasValue("Tiger");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Animal", b =>
                {
                    b.HasOne("WildlifePoaching.API.Models.Domain.AnimalType", "Type")
                        .WithMany("Animals")
                        .HasForeignKey("AnimalTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WildlifePoaching.API.Models.Domain.Location", "StolenFrom")
                        .WithMany("Animals")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StolenFrom");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.AnimalImage", b =>
                {
                    b.HasOne("WildlifePoaching.API.Models.Domain.Animal", "Animal")
                        .WithMany("Images")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Transaction", b =>
                {
                    b.HasOne("WildlifePoaching.API.Models.Domain.Animal", "Animal")
                        .WithMany("Transactions")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WildlifePoaching.API.Models.Domain.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.User", b =>
                {
                    b.HasOne("WildlifePoaching.API.Models.Domain.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.UserPermission", b =>
                {
                    b.HasOne("WildlifePoaching.API.Models.Domain.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Animal", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.AnimalType", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Location", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.Role", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WildlifePoaching.API.Models.Domain.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
