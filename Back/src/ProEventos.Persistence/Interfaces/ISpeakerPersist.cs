using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interfaces;

public interface ISpeakerPersist
{
    Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false);
    Task<Speaker?> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false);
    Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false);
}