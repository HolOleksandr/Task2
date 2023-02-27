﻿// <auto-generated />
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Author 1",
                            Content = "Text 1",
                            Genre = "horror",
                            Title = "Title 1"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Author 2",
                            Content = "Text 2",
                            Genre = "comedy",
                            Title = "Title 2"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Author 1",
                            Content = "Text 3",
                            Genre = "horror",
                            Title = "Title 3"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Author 3",
                            Content = "Text 4",
                            Genre = "fantasy",
                            Title = "Title 4"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Author 4",
                            Content = "Text 5",
                            Genre = "horror",
                            Title = "Title 5"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Author 2",
                            Content = "Text 6",
                            Genre = "historical",
                            Title = "Title 6"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Author 5",
                            Content = "Text 7",
                            Genre = "comedy",
                            Title = "Title 7"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Author 5",
                            Content = "Text 8",
                            Genre = "historical",
                            Title = "Title 8"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Author 2",
                            Content = "Text 9",
                            Genre = "comedy",
                            Title = "Title 9"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Author 1",
                            Content = "Text 10",
                            Genre = "Travel",
                            Title = "Title 10"
                        });
                });

            modelBuilder.Entity("Data.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Ratings", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Score = 5.6m
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            Score = 5.6m
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            Score = 10m
                        },
                        new
                        {
                            Id = 4,
                            BookId = 2,
                            Score = 7.3m
                        },
                        new
                        {
                            Id = 5,
                            BookId = 3,
                            Score = 6.6m
                        },
                        new
                        {
                            Id = 6,
                            BookId = 3,
                            Score = 5.6m
                        },
                        new
                        {
                            Id = 7,
                            BookId = 4,
                            Score = 3.2m
                        },
                        new
                        {
                            Id = 8,
                            BookId = 5,
                            Score = 2m
                        },
                        new
                        {
                            Id = 9,
                            BookId = 6,
                            Score = 3.2m
                        },
                        new
                        {
                            Id = 10,
                            BookId = 6,
                            Score = 9.9m
                        },
                        new
                        {
                            Id = 11,
                            BookId = 7,
                            Score = 8.6m
                        },
                        new
                        {
                            Id = 12,
                            BookId = 7,
                            Score = 7.6m
                        },
                        new
                        {
                            Id = 13,
                            BookId = 8,
                            Score = 5.6m
                        },
                        new
                        {
                            Id = 14,
                            BookId = 8,
                            Score = 5.5m
                        },
                        new
                        {
                            Id = 15,
                            BookId = 9,
                            Score = 6.6m
                        },
                        new
                        {
                            Id = 16,
                            BookId = 9,
                            Score = 8.9m
                        },
                        new
                        {
                            Id = 17,
                            BookId = 10,
                            Score = 10m
                        },
                        new
                        {
                            Id = 18,
                            BookId = 10,
                            Score = 2.4m
                        });
                });

            modelBuilder.Entity("Data.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reviewer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Message = "message 1",
                            Reviewer = "Reviewer 1"
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Message = "message 2",
                            Reviewer = "Reviewer 2"
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            Message = "message 3",
                            Reviewer = "Reviewer 1"
                        },
                        new
                        {
                            Id = 4,
                            BookId = 1,
                            Message = "message 4",
                            Reviewer = "Reviewer 2"
                        },
                        new
                        {
                            Id = 5,
                            BookId = 3,
                            Message = "message 5",
                            Reviewer = "Reviewer 3"
                        },
                        new
                        {
                            Id = 6,
                            BookId = 3,
                            Message = "message 6",
                            Reviewer = "Reviewer 1"
                        },
                        new
                        {
                            Id = 7,
                            BookId = 4,
                            Message = "message 7",
                            Reviewer = "Reviewer 6"
                        });
                });

            modelBuilder.Entity("Data.Entities.Rating", b =>
                {
                    b.HasOne("Data.Entities.Book", "Book")
                        .WithMany("Ratings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Data.Entities.Review", b =>
                {
                    b.HasOne("Data.Entities.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Data.Entities.Book", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
