﻿// <auto-generated />
using System;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryManager.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryManager.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(55)")
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "William Shakespeare"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Villiam Skakspjut"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Robert C. Martin"
                        });
                });

            modelBuilder.Entity("LibraryManager.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BooksID")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BooksID");

                    b.HasIndex("MemberId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryManager.Domain.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DetailsID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DetailsID");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("LibraryManager.Domain.BookDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("BookDetails");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = 1,
                            Description = "Arguably Shakespeare's greatest tragedy",
                            ISBN = "1472518381",
                            Title = "Hamlet"
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 1,
                            Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.",
                            ISBN = "9780141012292",
                            Title = "King Lear"
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 2,
                            Description = "An intense drama of love, deception, jealousy and destruction.",
                            ISBN = "1853260185",
                            Title = "Othello"
                        });
                });

            modelBuilder.Entity("LibraryManager.Domain.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BorrowedBookId")
                        .HasColumnType("int");

                    b.Property<int?>("BorrowingMemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndLoan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartLoan")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BorrowedBookId");

                    b.HasIndex("BorrowingMemberId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LibraryManager.Domain.LoanHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookDetailsID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanedOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Returned")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookDetailsID");

                    b.HasIndex("MemberId");

                    b.ToTable("LoanHistories");
                });

            modelBuilder.Entity("LibraryManager.Domain.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Lars",
                            LastName = "Larsson",
                            SSN = "970324-7138"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jan",
                            LastName = "Jansson",
                            SSN = "680721-1821"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Rune",
                            LastName = "Stålmark",
                            SSN = "910112-7832"
                        });
                });

            modelBuilder.Entity("LibraryManager.Domain.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("LibraryManager.Domain.Book", b =>
                {
                    b.HasOne("LibraryManager.Domain.BookDetails", "Books")
                        .WithMany()
                        .HasForeignKey("BooksID");

                    b.HasOne("LibraryManager.Domain.Member", null)
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("LibraryManager.Domain.BookCopy", b =>
                {
                    b.HasOne("LibraryManager.Domain.BookDetails", "Details")
                        .WithMany("Copies")
                        .HasForeignKey("DetailsID");
                });

            modelBuilder.Entity("LibraryManager.Domain.BookDetails", b =>
                {
                    b.HasOne("LibraryManager.Domain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManager.Domain.Loan", b =>
                {
                    b.HasOne("LibraryManager.Domain.Book", "BorrowedBook")
                        .WithMany()
                        .HasForeignKey("BorrowedBookId");

                    b.HasOne("LibraryManager.Domain.Member", "BorrowingMember")
                        .WithMany()
                        .HasForeignKey("BorrowingMemberId");
                });

            modelBuilder.Entity("LibraryManager.Domain.LoanHistory", b =>
                {
                    b.HasOne("LibraryManager.Domain.BookDetails", "BookDetails")
                        .WithMany()
                        .HasForeignKey("BookDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManager.Domain.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
