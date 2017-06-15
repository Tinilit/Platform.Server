using System.Collections.Generic;
using Platform.DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class TransactionEventRepository:ITransactionEventRepository
    {
        private PlatformContext _context;

        public TransactionEventRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Add(TransactionEvent entity)
        {
            _context.Add(entity);
        }

        public void Delete(TransactionEvent entity)
        {
            _context.Remove(entity);
        }

        public TransactionEvent GetTransactionEvent(int transactionEventId)
        {
            return _context.TransactionEvents
                .Include(x=>x.Transaction)
                .FirstOrDefault(s => s.Id == transactionEventId);
        }

        public IEnumerable<TransactionEvent> GetTransactionEvents()
        {
            return _context.TransactionEvents.ToList();
        }
    }
}
