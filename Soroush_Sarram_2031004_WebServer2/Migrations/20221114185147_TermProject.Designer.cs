﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Soroush_Sarram_2031004_WebServer2.Data;

#nullable disable

namespace SoroushSarram2031004WebServer2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221114185147_TermProject")]
    partial class TermProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Soroush_Sarram_2031004_WebServer2.Models.Session", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Token");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Soroush_Sarram_2031004_WebServer2.Models.Task", b =>
                {
                    b.Property<string>("TaskUId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssignedToName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignedToUid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedByUid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.HasKey("TaskUId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Soroush_Sarram_2031004_WebServer2.Models.User", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
