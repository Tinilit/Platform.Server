using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Platform.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public Profile Profile { get; set; }
    }
}
