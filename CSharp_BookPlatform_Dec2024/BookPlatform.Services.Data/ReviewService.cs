﻿using BookPlatform.Core.Services.Interfaces;
using BookPlatform.Core.ViewModels.ApplicationUser;
using BookPlatform.Core.ViewModels.Review;
using BookPlatform.Data.Models;
using BookPlatform.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.CompilerServices;

namespace BookPlatform.Core.Services
{
    public class ReviewService : BaseService, IReviewService
    {
        private readonly IRepository<Review, Guid> reviewRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewService(
            IRepository<Review, Guid> reviewRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.reviewRepository = reviewRepository;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<ReviewViewModel>> GetAllNewReviewsAsync(string userId)
        {
            IEnumerable<ReviewViewModel> reviews = new List<ReviewViewModel>();

            // check if user id is a valid guid
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return reviews;
            }

            // find user
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return reviews;
            }

            // generate reviews
            reviews = await this.reviewRepository
                .GetAllAttached()
                .Include(r => r.BookApplicationUser)
                .ThenInclude(bau => bau.ApplicationUser)
                .Where(bau => bau.ApplicationUserId == userGuid)
                .Where(r => r.CreatedOn > user.LastLogin || r.ModifiedOn > user.LastLogin)
                .Select(r => new ReviewViewModel()
                {
                    Id = r.Id.ToString(),
                    BookId = r.BookId.ToString(),
                    Content = r.Content,
                    IsModified = r.ModifiedOn != null ? true : false,
                    Author = r.BookApplicationUser.ApplicationUser.UserName!
                })
                .ToListAsync();

            return reviews;
        }

        public async Task<IEnumerable<ReviewViewModel>> GetAllReviewsPerBookAsync(string bookId)
        {
            IEnumerable<ReviewViewModel> reviews = await this.reviewRepository
                .GetAllAttached()
                .Include(r => r.BookApplicationUser)
                .ThenInclude(bau => bau.ApplicationUser)
                .Where(r => r.BookId.ToString().ToLower() == bookId.ToLower())
                .Select(r => new ReviewViewModel()
                {
                    Id = r.Id.ToString(),
                    BookId = r.BookId.ToString(),
                    Content = r.Content,
                    IsModified = r.ModifiedOn != null ? true : false,
                    Author = r.BookApplicationUser.ApplicationUser.UserName!
                })
                .ToListAsync();

            return reviews;
        }
    }
}
