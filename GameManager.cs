using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSIFEngine
{
   

    internal class GameManager
    {
        private List<Room> roomList;
        public Player player;

        public GameManager(List<Room> rooms, Player playerObj)
        {
            roomList = rooms;
            player = playerObj;
        }

        public string[] Prompt()
        {
            Console.Write(">");
            string? commands = Console.ReadLine();

            string[] words;

            if (commands != null)
            {
                words = commands.Split(' ');
                return words;
            }
            else
            {
                words = new string[] { "null" }; return words;
            }
        }

        public void Parse(string[] words)
        {
            string command = words[0];
            //string arg1 = "null";
            //string arg2 = "null";
            //string arg3 = "null";
            if (words.Length == 1)
            {
                if (command.ToLower() == "n" || command.ToLower() == "s" || command.ToLower() == "e" || command.ToLower() == "w" || 
                    command.ToLower() == "nw" || command.ToLower() == "ne" || command.ToLower() == "sw" || command.ToLower() == "se")
                {
                    words = new string[2] { "go" ,  command};
                   
                    command = words[0];

                    
                }
            }

            if (command.ToLower() == "look" || command.ToLower() == "l")
            {
                if (words.Length > 1)
                {
                    player.Look(words[1].ToLower());
                    player.PlayerTurns++;
                }
                else
                {
                    player.Look("room");
                    player.PlayerTurns++;
                }
            }
            else if (command.ToLower() == "go")
            {
                if (words.Length > 1)
                {
                    string arg1 = words[1];

                    player.Go(arg1.ToLower());
                    player.PlayerTurns++;
                }
            }
            else if (command.ToLower() == "get")
            {
                if (words.Length == 2)
                {
                    string arg1 = words[1];
                    
                    player.Get(arg1.ToLower());
                    player.PlayerTurns++;
                }
                else if (words.Length > 2)
                {
                    if (words.Length == 3)
                    {
                        string arg1 = words[1];
                        string arg2 = words[2];

                        player.Get(arg1.ToLower(), arg2);
                        player.PlayerTurns++;
                    }
                    else if (words.Length == 4)
                    {
                        string arg1 = words[1];
                        string arg2 = words[2];
                        string arg3 = words[3];

                        player.Get(arg1.ToLower(), arg3);
                        player.PlayerTurns++;
                    }
                }
            }
            else if (command.ToLower() == "drop")
            {
                if (words.Length > 1)
                {
                    string arg1 = words[1];

                    player.Drop(arg1.ToLower());
                    player.PlayerTurns++;
                }
            }
            else if (command.ToLower() == "inventory" || command.ToLower() == "inv" || command.ToLower() == "i")
            {
                player.ShowInv();
                player.PlayerTurns++;
            }
            else if (command.ToLower() == "lock")
            {
                if (words.Length > 1)
                {
                    string arg1 = words[1];

                    player.Lock(arg1.ToLower());
                    player.PlayerTurns++;
                }
            }
            else if (command.ToLower() == "unlock")
            {

                if (words.Length > 1)
                {
                    string arg1 = words[1];

                    player.Unlock(arg1.ToLower());
                    player.PlayerTurns++;
                }
       
            }
            else if (command.ToLower() == "open")
            {
                if (words.Length > 1)
                {
                    string arg1 = words[1];

                    player.Open(arg1.ToLower());
                    player.PlayerTurns++;
                }
            }
            else if (command.ToLower() == "wear" || command.ToLower() == "equip")
            {
                if (words.Length > 1)
                {
                    string arg1 = words[1];

                    player.Equip(arg1.ToLower());
                    player.PlayerTurns++;
                }
            }
            else if (command.ToLower() == "info")
            {
                player.Info();
            }


            else if (command.ToLower() == "quit")
            {
                Game.GameOver = true;
            }
            else
            {
                foreach (Thing item in player.Inventory)
                {
                    if (item != null )
                    {
                        if (item.Listener)
                        {
                            item.Parse(words);
                        }
                    }
                }
            }
        }
    }
}
