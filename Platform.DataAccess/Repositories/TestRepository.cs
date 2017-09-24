using Platform.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Platform.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Platform.DataAccess.Repositories
{
    public class TestRepository : ITestRepository
    {
        private PlatformContext _context;

        public TestRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Add(Test test)
        {
            _context.Tests.Add(test);
        }

        public void Delete(Test test)
        {
            _context.Tests.Remove(test);
        }

        public IEnumerable<Test> Get()
        {
            return _context.Tests
                .Include(x=>x.TestType)
                .ToList();
        }

        public Test GetById(int id)
        {
            return _context.Tests
                .Include(x => x.TestType)
                .FirstOrDefault(a => a.TestId == id);
        }

        public void Put(Test test)
        {
            _context.Tests.Update(test);
        }
    }
}
