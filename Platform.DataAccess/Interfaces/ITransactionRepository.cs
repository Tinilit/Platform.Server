using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface ITransactionRepository: IRepository<Transaction>
    {
        Transaction GetTransaction(int transactionId);
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransactionWithProduct(int transactionId);
    }
}
