﻿// <auto-generated />
using System;
using BookPlatform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookPlatform.Data.Migrations
{
    [DbContext(typeof(PlatformDbContext))]
    [Migration("20241104163258_SeedMoreAuthors_4")]
    partial class SeedMoreAuthors_4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationUserApplicationUser", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FriendsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicationUserId", "FriendsId");

                    b.HasIndex("FriendsId");

                    b.ToTable("ApplicationUserApplicationUser");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("First or only name of the author");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("First or only name of the author");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubmittedByUser")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Last or only name of the author");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a4ad7af-e62d-4970-876e-508a21b1a39b"),
                            FirstName = "Rudyard",
                            FullName = "Rudyard Kipling",
                            IsDeleted = false,
                            IsSubmittedByUser = false,
                            LastName = "Kipling"
                        },
                        new
                        {
                            Id = new Guid("d8a5ac42-01b0-49ab-a1b1-447b99d1768b"),
                            FirstName = "Richard",
                            FullName = "Richard Adams",
                            IsDeleted = false,
                            IsSubmittedByUser = false,
                            LastName = "Adams"
                        });
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float")
                        .HasComment("Average rating based on users' ratings");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Book description");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)")
                        .HasComment("Book cover image");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubmittedByUser")
                        .HasColumnType("bit");

                    b.Property<int?>("PublicationYear")
                        .HasColumnType("int")
                        .HasComment("Official known first publication year of the book");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Full title of the book");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.BookApplicationUser", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User's favourite character from the book - optional");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2")
                        .HasComment("Date on which the user added the book to a reading list");

                    b.Property<DateTime?>("DateFinished")
                        .HasColumnType("datetime2")
                        .HasComment("Date on which the user finished reading");

                    b.Property<DateTime?>("DateStarted")
                        .HasColumnType("datetime2")
                        .HasComment("Date on which the user started reading");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("RatingId")
                        .HasColumnType("int")
                        .HasComment("Optional user rating");

                    b.Property<int>("ReadingStatusId")
                        .HasColumnType("int")
                        .HasComment("Current reading status");

                    b.HasKey("BookId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("RatingId");

                    b.HasIndex("ReadingStatusId");

                    b.ToTable("BooksApplicationUsers");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.BookCharacter", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("BooksCharacters");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubmittedByUser")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Full name of the character");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Name of the genre");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Quote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The book the quote is from");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)")
                        .HasComment("The body of the quote");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date of creation in the database");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.QuoteApplicationUser", b =>
                {
                    b.Property<Guid>("QuoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuoteId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("QuotesApplicationUsers");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key and numeric value of the rating");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RatingDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Descriptive value of the rating");

                    b.HasKey("Id");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RatingDescription = "Barely finished it, if at all"
                        },
                        new
                        {
                            Id = 2,
                            RatingDescription = "Not much to enjoy/ learn"
                        },
                        new
                        {
                            Id = 3,
                            RatingDescription = "Good parts are good, bad parts are bad"
                        },
                        new
                        {
                            Id = 4,
                            RatingDescription = "Would definitely recommend/ reread"
                        },
                        new
                        {
                            Id = 5,
                            RatingDescription = "Absolutely amazing"
                        });
                });

            modelBuilder.Entity("BookPlatform.Data.Models.ReadingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key and numeric value of the status");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Descriptive value of the status");

                    b.HasKey("Id");

                    b.ToTable("ReadingStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusDescription = "Read"
                        },
                        new
                        {
                            Id = 2,
                            StatusDescription = "Currently Reading"
                        },
                        new
                        {
                            Id = 3,
                            StatusDescription = "Want to Read"
                        });
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The user who created the review");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The book the review is about");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The body of the review");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date of creation in the database");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int")
                        .HasComment("Number of likes");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date of last modification in the database");

                    b.HasKey("Id");

                    b.HasIndex("BookId", "ApplicationUserId")
                        .IsUnique();

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ApplicationUserApplicationUser", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookPlatform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("FriendsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Book", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookPlatform.Data.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.BookApplicationUser", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserBooks")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookPlatform.Data.Models.Book", "Book")
                        .WithMany("BookApplicationUsers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookPlatform.Data.Models.Character", "Character")
                        .WithMany("CharacterBookApplicationUsers")
                        .HasForeignKey("CharacterId");

                    b.HasOne("BookPlatform.Data.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId");

                    b.HasOne("BookPlatform.Data.Models.ReadingStatus", "ReadingStatus")
                        .WithMany()
                        .HasForeignKey("ReadingStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Book");

                    b.Navigation("Character");

                    b.Navigation("Rating");

                    b.Navigation("ReadingStatus");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.BookCharacter", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.Book", "Book")
                        .WithMany("BookCharacters")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookPlatform.Data.Models.Character", "Character")
                        .WithMany("CharacterBooks")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Quote", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.Book", "Book")
                        .WithMany("Quotes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.QuoteApplicationUser", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserQuotes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookPlatform.Data.Models.Quote", "Quote")
                        .WithMany("QuoteApplicationUsers")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Review", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.BookApplicationUser", "BookApplicationUser")
                        .WithOne("Review")
                        .HasForeignKey("BookPlatform.Data.Models.Review", "BookId", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookPlatform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("BookPlatform.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookPlatform.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("UserBooks");

                    b.Navigation("UserQuotes");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Book", b =>
                {
                    b.Navigation("BookApplicationUsers");

                    b.Navigation("BookCharacters");

                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.BookApplicationUser", b =>
                {
                    b.Navigation("Review");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Character", b =>
                {
                    b.Navigation("CharacterBookApplicationUsers");

                    b.Navigation("CharacterBooks");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookPlatform.Data.Models.Quote", b =>
                {
                    b.Navigation("QuoteApplicationUsers");
                });
#pragma warning restore 612, 618
        }
    }
}