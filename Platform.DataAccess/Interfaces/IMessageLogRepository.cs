using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface IMessageLogRepository:IRepository<MessageLog>
    {
        IEnumerable<MessageLog> GetAllMessageLog();
        MessageLog GetMessageLog(int id);
        MessageLog GetMessageLogWithProducts(int id);
        MessageLog GetMessageLogWithAll(int id);
    }
}
