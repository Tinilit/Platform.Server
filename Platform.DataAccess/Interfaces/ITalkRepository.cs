using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface ITalkRepository : IRepository<Talk>
    {
        // Talks
        IEnumerable<Talk> GetTalks(int speakerId);
        Talk GetTalk(int talkId);
    }
}
