using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface ITransactionEventRepository: IRepository<TransactionEvent>
    {
        TransactionEvent GetTransactionEvent(int transactionEventId);
        IEnumerable<TransactionEvent> GetTransactionEvents();
    }
}
