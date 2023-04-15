using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSIFEngine
{
    public class NPC : Thing
    {
        private bool isFriendly;
        private Dictionary<string, string> dialogues;
        private string defaultDialogue;

        public bool IsFriendly { get { return isFriendly; } set { isFriendly = value; } }
        public Dictionary<string, string> Dialogues { get { return dialogues; } set { dialogues = value; } }
        public string DefaultDialogue { get { return defaultDialogue; } set { defaultDialogue = value; } }

        public NPC(int id, string name, string description, bool isFriendly, string defaultDialogue)
        {
            ID = id;
            Name = name;
            Description = description;
            IsFriendly = isFriendly;
            DefaultDialogue = defaultDialogue;
            Dialogues = new Dictionary<string, string>();
            Listener = true;
        }

        public void AddDialogue(string keyword, string response)
        {
            Dialogues.Add(keyword, response);
        }

        public string GetResponse(string keyword)
        {
            if (Dialogues.ContainsKey(keyword))
            {
                return Dialogues[keyword];
            }
            else
            {
                return DefaultDialogue;
            }
        }

        public override void Parse(string[] words)
        {
           

            string command = words[0];
            string target = words[1].ToLower();

            if (target != Name.ToLower())
            {
                Console.WriteLine("I don't see them here.");
                return;
            }

            switch (command)
            {
                case "talk":
                case "speak":
                    if (words.Length > 2)
                    {
                        string keyword = words[2];
                        Console.WriteLine(GetResponse(keyword));
                    }
                    else
                    {
                        Console.WriteLine(DefaultDialogue);
                    }
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
;