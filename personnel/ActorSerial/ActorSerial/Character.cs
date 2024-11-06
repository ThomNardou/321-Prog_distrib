using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ActorSerial
{
    public class Character
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public Actor PlayedBy { get; set; }

        public Character(string firstName, string lastName, string description, Actor playedBy)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            PlayedBy = playedBy;
        }

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Character ToClass(string json)
        {
            return JsonSerializer.Deserialize<Character>(json);
        }
    }
}
