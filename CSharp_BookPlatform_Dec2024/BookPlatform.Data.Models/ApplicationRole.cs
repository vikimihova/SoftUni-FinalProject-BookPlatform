﻿using Microsoft.AspNetCore.Identity;

namespace BookPlatform.Data.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        {
            
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            
        }
    }
}
