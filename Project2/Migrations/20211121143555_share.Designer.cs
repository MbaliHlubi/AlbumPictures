﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project2.Database;

namespace Project2.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20211121143555_share")]
    partial class share
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project2.Domains.Images", b =>
                {
                    b.Property<Guid>("image_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("album")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("album");

                    b.Property<byte[]>("image")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image");

                    b.Property<string>("image_CapturedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("capturedBy");

                    b.Property<DateTime>("image_CapturedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("capturedDate");

                    b.Property<string>("image_Geolocation")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("geolocation");

                    b.Property<string>("image_Tag")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tag");

                    b.Property<string>("image_name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid?>("person_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("image_id");

                    b.HasIndex("person_id");

                    b.ToTable("images");
                });

            modelBuilder.Entity("Project2.Domains.People", b =>
                {
                    b.Property<Guid>("person_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("person_name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("person_surname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("surname");

                    b.Property<string>("person_userName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("person_id");

                    b.ToTable("people");
                });

            modelBuilder.Entity("Project2.Domains.SharedImages", b =>
                {
                    b.Property<string>("sendTo")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("sent_to");

                    b.Property<Guid>("image_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("person_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("sendTo");

                    b.HasIndex("image_id");

                    b.HasIndex("person_id");

                    b.ToTable("shareImages");
                });

            modelBuilder.Entity("Project2.Domains.Images", b =>
                {
                    b.HasOne("Project2.Domains.People", "person")
                        .WithMany()
                        .HasForeignKey("person_id");

                    b.Navigation("person");
                });

            modelBuilder.Entity("Project2.Domains.SharedImages", b =>
                {
                    b.HasOne("Project2.Domains.Images", "image")
                        .WithMany()
                        .HasForeignKey("image_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Domains.People", "person")
                        .WithMany()
                        .HasForeignKey("person_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("image");

                    b.Navigation("person");
                });
#pragma warning restore 612, 618
        }
    }
}