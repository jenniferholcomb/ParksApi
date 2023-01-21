﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParksApi.Models;

#nullable disable

namespace ParksApi.Migrations
{
    [DbContext(typeof(ParksApiContext))]
    [Migration("20230121013908_UserInfo")]
    partial class UserInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParksApi.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Features")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Terrain")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Features = "beach, hiking, lookouts, camping",
                            Location = "Tillamook County",
                            Name = "Cape Lookout State Park",
                            State = "Oregon",
                            Terrain = "coastal, old-growth forest, high cliffs, rugged",
                            Type = "coast"
                        },
                        new
                        {
                            ParkId = 2,
                            Features = "hiking, springtime wildflowers, wheelchair access loops",
                            Location = "Portland",
                            Name = "Tyron Creek State Natural Area",
                            State = "Oregon",
                            Terrain = "woodsy ravine, creek",
                            Type = "city"
                        },
                        new
                        {
                            ParkId = 3,
                            Features = "hiking, wheelchair access loops, viewpoints",
                            Location = "Gifford Pinchot National Forest",
                            Name = "Mt St Helens National Volcanic Monument",
                            State = "Washington",
                            Terrain = "volcanic, old-growth forest, lakes, waterfalls in canyon",
                            Type = "mountain"
                        },
                        new
                        {
                            ParkId = 4,
                            Features = "overlooks of Columbia River, spring wildflowers, wheelchair accessible loop",
                            Location = "Columbia Gorge",
                            Name = "Beacon Rock State Park",
                            State = "Washington",
                            Terrain = "rocky near clifftops, forest, river",
                            Type = "gorge"
                        },
                        new
                        {
                            ParkId = 5,
                            Features = "rock climbing, camping, hiking",
                            Location = "Terrebone",
                            Name = "Smith Rock State Park",
                            State = "Oregon",
                            Terrain = "steep cliffs, river",
                            Type = "high desert"
                        });
                });

            modelBuilder.Entity("ParksApi.Models.UserInfo", b =>
                {
                    b.Property<int>("UserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("UserInfoId");

                    b.ToTable("UserInfos");

                    b.HasData(
                        new
                        {
                            UserInfoId = 1,
                            DisplayName = "Test",
                            Email = "test@test.com",
                            Password = "Test1234",
                            UserName = "test123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
