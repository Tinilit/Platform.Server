﻿using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Platform.DataAccess.Repositories
{
    public class UserTestRepository:IUserTestRepository
    {
        private PlatformContext _context;

        public UserTestRepository(PlatformContext context)
        {
            _context = context;
        }

        public UserTest GetUserTestById(int userTestId)
        {
            return _context.UserTests
                .Include(x=>x.User)
                .Include(x => x.Test)
                .ThenInclude(x=>x.TestType)
                .FirstOrDefault(arg => arg.UserTestId == userTestId);
        }

        public IEnumerable<UserTest> GetAllUserTests()
        {
            return _context.UserTests
                .Include(x => x.User).ThenInclude(x=>x.Profile)
                .Include(x => x.Test).ThenInclude(x => x.TestType)
                .ToList();
        }

        public void Add(UserTest entity)
        {
            _context.Add(entity);
        }

        public void Delete(UserTest entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<UserTest> GetUserTestsByProviderId(string providerId)
        {
            return _context.UserTests
                .Where(x => x.Test.ProviderId.Equals(providerId))
                .Include(x => x.User).ThenInclude(x => x.Profile)
                .Include(x => x.Test).ThenInclude(x => x.TestType)
                .ToList();
        }
    }
}
