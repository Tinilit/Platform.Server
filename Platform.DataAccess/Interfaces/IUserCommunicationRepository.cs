using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface IUserCommunicationRepository: IRepository<UserCommunication>
    {
        UserCommunication GetUserCommunication(int id);
        IEnumerable<UserCommunication> GetUserCommunications();
    }
}
