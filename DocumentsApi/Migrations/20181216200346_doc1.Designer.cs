﻿// <auto-generated />
using DocumentsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DocumentsApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20181216200346_doc1")]
    partial class doc1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DocumentsApi.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DocumentsApi.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DocumentsApi.Models.Document", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DepartmentId");

                    b.Property<string>("Title");

                    b.Property<string>("code");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DocumentsApi.Models.DocumentCategory", b =>
                {
                    b.Property<long>("DocumentId");

                    b.Property<long>("CategoryId");

                    b.HasKey("DocumentId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("DocumentCategory");
                });

            modelBuilder.Entity("DocumentsApi.Models.Document", b =>
                {
                    b.HasOne("DocumentsApi.Models.Department", "Department")
                        .WithMany("Documents")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DocumentsApi.Models.DocumentCategory", b =>
                {
                    b.HasOne("DocumentsApi.Models.Category", "Category")
                        .WithMany("DocumentCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DocumentsApi.Models.Document", "Document")
                        .WithMany("DocumentCategories")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
