using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface ISpeakerRepository:IRepository<Speaker>
    {
        // Speakers
        IEnumerable<Speaker> GetSpeakers(int id);
        IEnumerable<Speaker> GetSpeakersWithTalks(int id);
        IEnumerable<Speaker> GetSpeakersByMoniker(string moniker);
        IEnumerable<Speaker> GetSpeakersByMonikerWithTalks(string moniker);
        Speaker GetSpeaker(int speakerId);
        Speaker GetSpeakerWithTalks(int speakerId);
    }
}
