using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface IWantListRepository:IRepository<WantList>
    {
        WantList GetWantList(int id);
        IEnumerable<WantList> GetWantLists();
        IEnumerable<WantList> GetWantListsByUserName(string UserName);
    }
}
