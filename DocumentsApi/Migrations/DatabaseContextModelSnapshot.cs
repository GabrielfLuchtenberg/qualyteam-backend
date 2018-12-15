﻿// <auto-generated />
using System;
using DocumentsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocumentsApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DocumentsApi.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DocumentsApi.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DocumentsApi.Models.Document", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DepartmentId");

                    b.Property<long?>("DocumentCategoryCategoryId");

                    b.Property<long?>("DocumentCategoryDocumentId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DocumentCategoryDocumentId", "DocumentCategoryCategoryId");

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
                        .HasForeignKey("DepartmentId");

                    b.HasOne("DocumentsApi.Models.DocumentCategory")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentCategoryDocumentId", "DocumentCategoryCategoryId");
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