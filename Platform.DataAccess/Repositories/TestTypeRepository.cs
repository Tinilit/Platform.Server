using System;
using System.Collections.Generic;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using System.Linq;

namespace Platform.DataAccess.Repositories
{
    public class TestTypeRepository : ITestTypeRepository
    {
        private PlatformContext _context;

        public TestTypeRepository(PlatformContext context)
        {
            _context = context;
        }

        public void Add(TestType testType)
        {
            _context.TestTypes.Add(testType);
        }

        public void Delete(TestType testType)
        {
            _context.TestTypes.Remove(testType);
        }

        public IEnumerable<TestType> Get()
        {
            return _context.TestTypes.ToList();
        }

        public TestType GetById(int id)
        {
            return _context.TestTypes.FirstOrDefault(a => a.Id == id);
        }

        public void Put(TestType test)
        {
            _context.TestTypes.Update(test);
        }
    }
}
