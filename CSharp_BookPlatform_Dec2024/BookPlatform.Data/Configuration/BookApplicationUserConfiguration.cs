﻿using BookPlatform.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPlatform.Data.Configuration
{
    public class BookApplicationUserConfiguration : IEntityTypeConfiguration<BookApplicationUser>
    {
        public void Configure(EntityTypeBuilder<BookApplicationUser> builder)
        {
            builder.HasKey(bau => new { bau.BookId, bau.ApplicationUserId });

            builder.HasOne(bau => bau.Review)
                .WithOne(r => r.BookApplicationUser)
                .HasPrincipalKey<BookApplicationUser>(bau => new { bau.BookId, bau.ApplicationUserId })
                .HasForeignKey<Review>(r => new { r.BookId, r.ApplicationUserId })
                .IsRequired();
        }
    }
}