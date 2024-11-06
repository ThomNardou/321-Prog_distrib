using ActorSerial;
using System.Xml;
using System.IO;
using System.Text.Json;

Actor actor1 = new Actor("Joachim", "berchel", DateTime.Now, "Suisse", false);

Character chara1 = new Character("Gerard", "DuBois","rjkehgioaenhh", actor1);
Character chara2 = new Character("Michel", "DUPONT", "rjkehgioaenhh", actor1);

Episode ep1 = new Episode("Road to Diamond 1", 14768, 5, "moi", "Un gros puant qui essaie de monter master sur LOL", new List<Character> { chara1, chara2 });
Episode ep2 = new Episode("Road to Master 1", 14768, 5, "moi", "Un gros puant qui essaie de monter master sur LOL", new List<Character> { chara1, chara2 });
Episode ep3 = new Episode("Road to Grand-master 1", 14768, 5, "moi", "Un gros puant qui essaie de monter master sur LOL", new List<Character> { chara1, chara2 });

List<Episode> epList = new List<Episode>();

epList.Add(ep1);
epList.Add(ep2);
epList.Add(ep3);


File.WriteAllLines("gerard.json", new string[] { chara1.ToJSON() });
File.WriteAllLines("joachim.json", new string[] { actor1.ToJSON() });
File.WriteAllLines("roadToMaster-EP1.json", new string[] { ep1.ToJSON() });
File.WriteAllLines("Lol-Ranked-Episodes.json", new string[] { JsonSerializer.Serialize<List<Episode>>(epList) });

string json = File.ReadAllLines("Bob.json")[0];
Character test = Character.ToClass(json);

string jsonActor = File.ReadAllLines("thomas.json")[0];
Actor thomas = Actor.ToClass(jsonActor);

string jsonEP = File.ReadAllLines("la-mort-de-bob.json")[0];
Episode laMortDeBob = Episode.ToClass(jsonEP);

Console.WriteLine("TEST CHARACTER TO CLASS : " + test.Description);
Console.WriteLine("TEST ACTOR TO CLASS : " + thomas.LastName);
Console.WriteLine($"Le personnage de {chara1.FirstName} {chara1.LastName} est joué par {chara1.PlayedBy.FirstName} {chara1.PlayedBy.LastName}");
Console.WriteLine($"L'épisode 1 de {laMortDeBob.Title} possède {laMortDeBob.Characters.Count} épisode");






