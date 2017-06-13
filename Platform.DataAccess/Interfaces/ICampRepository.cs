using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface ICampRepository:IRepository<Camp>
    {
        // Camps
        IEnumerable<Camp> GetAllCamps();
        Camp GetCamp(int id);
        Camp GetCampWithSpeakers(int id);
        Camp GetCampByMoniker(string moniker);
        Camp GetCampByMonikerWithSpeakers(string moniker);
    }
}