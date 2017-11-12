using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Platform.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public Profile Profile { get; set; }

        public List<UserTest> UserTests { get; set; }
    }
}
