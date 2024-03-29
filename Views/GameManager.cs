﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


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
            // Create the game Prompt
            Console.Write(">");
            string? commands = Console.ReadLine();

            // Split the string of words into a string array
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

        public virtual void Parse(string[] words)
        {
            string command = words[0].ToLower();

            bool isTrig = false;

            // Check if the command is an exit trigger
            if (words.Length == 1)
            {
                foreach (Exit exit in player.Location.ExitList)
                {
                    if (exit.exitTrig != null && command == exit.exitTrig.ToLower())
                    {
                        isTrig = true;
                    }
                }

                // If the command is an exit trigger, change the command to "go"
                if (new string[] { "n", "s", "e", "w", "nw", "ne", "sw", "se" }.Contains(command) || isTrig)
                {
                    words = new string[2] { "go", command };
                    command = words[0].ToLower();
                }
            }

            // Begin parsing the command
            switch (command)
            {
                case "look":
                case "l":
                case "examine":
                case "ex":
                case "inspect":
                case "ins":
                case "search":
                case "sea":

                    // If the command is "look" or "l", check if there is a second word. If there is,
                    // use that as the target. If not, use "room" as the target.
                    player.Look(words.Length > 1 ? words[1].ToLower() : "room"); 
                    player.PlayerTurns++;
                    break;

                case "go":
                case "move":
                case "walk":
                case "run":

                    if (words.Length > 1)
                    {
                        player.Go(words[1].ToLower());
                        player.PlayerTurns++;
                    }
                    break;

                case "get":
                case "take":
                case "pickup":
                    if (words.Length == 2)
                    {
                        player.Get(words[1].ToLower());
                        player.PlayerTurns++;
                    }
                    else if (words.Length >= 3)
                    {
                        player.Get(words[1].ToLower(), words[words.Length == 3 ? 2 : 3]);
                        player.PlayerTurns++;
                    }
                    break;

                case "drop":

                    if (words.Length > 1)
                    {
                        player.Drop(words[1].ToLower());
                        player.PlayerTurns++;
                    }
                    break;

                case "inventory":
                case "inv":
                case "i":
                    player.ShowInv();
                    player.PlayerTurns++;
                    break;

                case "lock":
                   
                    if (words.Length > 1)
                    {
                        player.Lock(words[1].ToLower());
                        player.PlayerTurns++;
                    }
                    break;

                case "unlock":
                    if (words.Length > 1)
                    {
                        player.Unlock(words[1].ToLower());
                        player.PlayerTurns++;
                    }
                    break;

                case "open":

                    if (words.Length > 1)
                    {
                        player.Open(words[1].ToLower());
                        player.PlayerTurns++;
                    }
                    break;

                case "wear":
                case "equip":
                 
                    if (words.Length > 1)
                    {
                        player.Equip(words[1].ToLower());
                        player.PlayerTurns++;
                    }
                    break;

               

                case "info":
                    player.Info();
                    break;


                case "save":
                    this.SaveGame("save.json");
                    break;
                case "load":
                    this.LoadGame("save.json");
                    break;
                case "quit":
                    Game.GameOver = true;
                    break;

                default:
                    Console.WriteLine("Debug: fired");
                    foreach (Thing item in player.Inventory)
                    {
                        if (item != null && item.Listener)
                        {
                            Console.WriteLine("Debug: Inv Listerners fired");
                            item.Parse(words);
                        }
                    }
                    foreach (Thing thing in player.Equipment)
                    {
                        if (thing != null && thing.Listener)
                        {
                            Console.WriteLine("Debug: Equip Listerners fired");
                            thing.Parse(words);
                        }
                    }
                    foreach (Thing item in player.Location.Things)
                    {
                        if (item != null && item.Listener)
                        {
                            Console.WriteLine("Debug: Loc Listerners fired");
                            item.Parse(words);
                        }
                    }
                    break;
            }
        }

        public void SaveGame(string filePath)
        {
            // Assuming you have properties or fields named Rooms, Things, and Player in GameManager
            GameState gameState = new GameState(roomList, player);

            // Create a JsonSerializerSettings object with the ReferenceLoopHandling set to Ignore
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

            // Serialize the gameState object to a JSON string using the JsonSerializerSettings
            string gameStateJson = JsonConvert.SerializeObject(gameState, settings);

            try
            {
                // Save the JSON string to a file
                File.WriteAllText(filePath, gameStateJson);

                // Display a confirmation message to the player
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Game saved successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                // Display an error message to the player
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred while saving the game: " + ex.Message);
                Console.ResetColor();
            }

        }


        public void LoadGame(string filePath)
        {
            try
            {
                string gameStateJson = File.ReadAllText(filePath);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                };

                GameState gameState = JsonConvert.DeserializeObject<GameState>(gameStateJson, settings);

                // Ensure the player and room list are set up correctly after deserialization
                player = gameState.Player;
                roomList = gameState.Rooms;

                Console.WriteLine("Game loaded successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading game: {e.Message}");
            }
        }
    }
}
