using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ActorSerial
{
    public class Actor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public bool IsAlive { get; set; }

        public Actor(string firstName, string lastName, DateTime birthDate, string country, bool isAlive)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Country = country;
            IsAlive = isAlive;
        }

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Actor ToClass(string json)
        {
            return JsonSerializer.Deserialize<Actor>(json);
        }
    }

    
}
