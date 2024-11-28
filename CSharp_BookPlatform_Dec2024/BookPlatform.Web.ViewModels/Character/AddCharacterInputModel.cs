﻿using BookPlatform.Core.ViewModels.Book;
using System.ComponentModel.DataAnnotations;

using static BookPlatform.Common.EntityValidationConstants.CharacterValidationConstants;

namespace BookPlatform.Core.ViewModels.Character
{
    public class AddCharacterInputModel
    {
        [Required]
        [MinLength(CharacterNameMinLength)]
        [MaxLength(CharacterNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string BookId { get; set; } = null!;

        [Required]
        public ICollection<SelectBookViewModel> Books { get; set; } = new List<SelectBookViewModel>();
    }
}