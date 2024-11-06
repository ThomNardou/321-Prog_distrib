using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ActorSerial
{
    internal class Episode
    {
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public int SequenceNumber { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();

        public Episode(string title, int durationMinutes, int sequenceNumber, string director, string synopsis, List<Character> characters)
        {
            Title = title;
            DurationMinutes = durationMinutes;
            SequenceNumber = sequenceNumber;
            Director = director;
            Synopsis = synopsis;
            Characters = characters;
        }

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Episode ToClass(string json)
        {
            return JsonSerializer.Deserialize<Episode>(json);
        }
    }
}
