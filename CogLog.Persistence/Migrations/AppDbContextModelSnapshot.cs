﻿// <auto-generated />
using System;
using CogLog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CogLog.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CogLog.Domain.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExtraContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("CogLog.Domain.BlockTag", b =>
                {
                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("BlockId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("BlockTags", (string)null);
                });

            modelBuilder.Entity("CogLog.Domain.BlockTopic", b =>
                {
                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("BlockId", "TopicId");

                    b.HasIndex("TopicId");

                    b.ToTable("BlockTopics", (string)null);
                });

            modelBuilder.Entity("CogLog.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Label")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CogLog.Domain.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Label")
                        .IsUnique();

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("CogLog.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CogLog.Domain.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("CogLog.Domain.Block", b =>
                {
                    b.HasOne("CogLog.Domain.Category", "Category")
                        .WithMany("Blocks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("CogLog.Domain.Subject", "Subject")
                        .WithMany("Blocks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("CogLog.Domain.BlockTag", b =>
                {
                    b.HasOne("CogLog.Domain.Block", "Block")
                        .WithMany("BlockTags")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CogLog.Domain.Tag", "Tag")
                        .WithMany("BlockTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("CogLog.Domain.BlockTopic", b =>
                {
                    b.HasOne("CogLog.Domain.Block", "Block")
                        .WithMany("BlockTopics")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CogLog.Domain.Topic", "Topic")
                        .WithMany("BlockTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("CogLog.Domain.Subject", b =>
                {
                    b.HasOne("CogLog.Domain.Category", "Category")
                        .WithMany("Subjects")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CogLog.Domain.Tag", b =>
                {
                    b.HasOne("CogLog.Domain.Subject", "Subject")
                        .WithMany("Tags")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("CogLog.Domain.Topic", b =>
                {
                    b.HasOne("CogLog.Domain.Subject", "Subject")
                        .WithMany("Topics")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("CogLog.Domain.Block", b =>
                {
                    b.Navigation("BlockTags");

                    b.Navigation("BlockTopics");
                });

            modelBuilder.Entity("CogLog.Domain.Category", b =>
                {
                    b.Navigation("Blocks");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("CogLog.Domain.Subject", b =>
                {
                    b.Navigation("Blocks");

                    b.Navigation("Tags");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("CogLog.Domain.Tag", b =>
                {
                    b.Navigation("BlockTags");
                });

            modelBuilder.Entity("CogLog.Domain.Topic", b =>
                {
                    b.Navigation("BlockTopics");
                });
#pragma warning restore 612, 618
        }
    }
}
