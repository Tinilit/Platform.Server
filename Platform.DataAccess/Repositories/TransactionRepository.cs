using System;
using System.Collections.Generic;
using Platform.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        private PlatformContext _context;

        public TransactionRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Add(Transaction entity)
        {
            _context.Add(entity);
        }

        public void Delete(Transaction entity)
        {
            _context.Remove(entity);
        }

        public Transaction GetTransaction(int transactionId)
        {
            return _context.Transactions.FirstOrDefault(s => s.Id == transactionId);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetTransactionWithProduct(int transactionId)
        {
            return _context.Transactions.Include(x => x.Product).FirstOrDefault(x => x.Id == transactionId);
        }
    }
}
