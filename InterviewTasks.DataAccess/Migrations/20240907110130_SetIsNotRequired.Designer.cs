﻿// <auto-generated />
using System;
using InterviewTasks.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InterviewTasks.DataAccess.Migrations
{
    [DbContext(typeof(InterviewTasksDbContext))]
    [Migration("20240907110130_SetIsNotRequired")]
    partial class SetIsNotRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InterviewTasks.DataAccess.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CategoryEntity");
                });

            modelBuilder.Entity("InterviewTasks.DataAccess.Entities.TagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TestTaskId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TestTaskId");

                    b.ToTable("TagEntity");
                });

            modelBuilder.Entity("InterviewTasks.DataAccess.Entities.TestTaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DifficultyLevels")
                        .HasColumnType("integer");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TestTasks");
                });

            modelBuilder.Entity("InterviewTasks.DataAccess.Entities.TagEntity", b =>
                {
                    b.HasOne("InterviewTasks.DataAccess.Entities.TestTaskEntity", "TestTask")
                        .WithMany("Tags")
                        .HasForeignKey("TestTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestTask");
                });

            modelBuilder.Entity("InterviewTasks.DataAccess.Entities.TestTaskEntity", b =>
                {
                    b.HasOne("InterviewTasks.DataAccess.Entities.CategoryEntity", "Category")
                        .WithMany("TestTasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("InterviewTasks.DataAccess.Entities.CategoryEntity", b =>
                {
                    b.Navigation("TestTasks");
                });

            modelBuilder.Entity("InterviewTasks.DataAccess.Entities.TestTaskEntity", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
