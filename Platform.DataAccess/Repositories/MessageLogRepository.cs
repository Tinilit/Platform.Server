using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class MessageLogRepository:IMessageLogRepository
    {
        private PlatformContext _context;

        public MessageLogRepository(PlatformContext context)
        {
            _context = context;
        }

        public void Add(MessageLog entity)
        {
            _context.Add(entity);
        }

        public void Delete(MessageLog entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<MessageLog> GetAllMessageLog()
        {
            return _context.MessageLogs.ToList();
        }

        public MessageLog GetMessageLog(int id)
        {
            return _context.MessageLogs.FirstOrDefault(c => c.Id == id);
        }

        public MessageLog GetMessageLogWithProducts(int id)
        {
            return _context.MessageLogs
              .Include(c => c.Product)
              .FirstOrDefault(c => c.Id == id);
        }

        public MessageLog GetMessageLogWithAll(int id)
        {
            return _context.MessageLogs
              .Include(c => c.Product)
              .Include(c=>c.User)
              .Include(c=>c.BuyOffer)
              .Include(c=>c.SellOffer)
              .Include(c=>c.Transaction)
              .FirstOrDefault(c => c.Id == id);
        }
    }
}
