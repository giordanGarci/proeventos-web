using System.Text.Json.Serialization;
namespace ProEventos.Domain
{
    public class SpeakerEvent
    {
        public int Id { get; set; }
        public int? SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }
        public int? EventId { get; set; }
        
        [JsonIgnore]
        public Event? Event { get; set; }
    }
}