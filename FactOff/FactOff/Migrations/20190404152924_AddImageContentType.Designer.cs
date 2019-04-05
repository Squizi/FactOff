﻿// <auto-generated />
using System;
using FactOff.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FactOff.Migrations
{
    [DbContext(typeof(FactOffContext))]
    [Migration("20190404152924_AddImageContentType")]
    partial class AddImageContentType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FactOff.Models.DB.Fact", b =>
                {
                    b.Property<Guid>("FactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Context");

                    b.Property<Guid?>("CreatorUserId");

                    b.Property<int>("RateCount");

                    b.Property<float>("Rating");

                    b.Property<Guid?>("ThemeId");

                    b.HasKey("FactId");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("ThemeId");

                    b.ToTable("Facts");
                });

            modelBuilder.Entity("FactOff.Models.DB.FactsTags", b =>
                {
                    b.Property<Guid>("FactId");

                    b.Property<Guid>("TagId");

                    b.HasKey("FactId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("FactsTags");
                });

            modelBuilder.Entity("FactOff.Models.DB.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FactOff.Models.DB.Theme", b =>
                {
                    b.Property<Guid>("ThemeId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Image");

                    b.Property<string>("ImageContentType");

                    b.Property<string>("Name");

                    b.HasKey("ThemeId");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("FactOff.Models.DB.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FactOff.Models.DB.UserFavoritesFacts", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("FactId");

                    b.HasKey("UserId", "FactId");

                    b.HasIndex("FactId");

                    b.ToTable("UserFavoritesFacts");
                });

            modelBuilder.Entity("FactOff.Models.DB.UserFavoriteThemes", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("ThemeId");

                    b.HasKey("UserId", "ThemeId");

                    b.HasIndex("ThemeId");

                    b.ToTable("UserFavoriteThemes");
                });

            modelBuilder.Entity("FactOff.Models.DB.Fact", b =>
                {
                    b.HasOne("FactOff.Models.DB.User", "Creator")
                        .WithMany("CreatedFacts")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("FactOff.Models.DB.Theme", "Theme")
                        .WithMany("Facts")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("FactOff.Models.DB.FactsTags", b =>
                {
                    b.HasOne("FactOff.Models.DB.Fact", "Fact")
                        .WithMany("Tags")
                        .HasForeignKey("FactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FactOff.Models.DB.Tag", "Tag")
                        .WithMany("Facts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FactOff.Models.DB.UserFavoritesFacts", b =>
                {
                    b.HasOne("FactOff.Models.DB.Fact", "Fact")
                        .WithMany("Users")
                        .HasForeignKey("FactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FactOff.Models.DB.User", "User")
                        .WithMany("FavoriteFacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FactOff.Models.DB.UserFavoriteThemes", b =>
                {
                    b.HasOne("FactOff.Models.DB.Theme", "Theme")
                        .WithMany("Users")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FactOff.Models.DB.User", "User")
                        .WithMany("FavoriteThemes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}