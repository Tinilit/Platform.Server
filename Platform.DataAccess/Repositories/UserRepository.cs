﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using System.Collections.Generic;

namespace Platform.DataAccess.Repositories
{
    public class UserRepository:IUserRepository
    {
        private PlatformContext _context;

        public UserRepository(PlatformContext context)
        {
            _context = context;
        }

        public User GetUserById(string userId)
        {
            return _context.Users.FirstOrDefault(arg => arg.Id == userId);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Include(x=>x.Profile).ToList();
        }

        public void Add(User entity)
        {
            _context.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Remove(entity);
        }
        public User GetUser(string userName)
        {
            return _context.Users
              .Include(u => u.Claims)
              .Include(u => u.Roles)
              .Where(u => u.UserName == userName)
              .Cast<User>()
              .FirstOrDefault();
        }
    }
}
