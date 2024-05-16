
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine
{
    public class Player
    {
        public Room Location;
        public int PlayerTurns;

        public List<Thing> Inventory;
        public List<Thing> Equipment;

        public List<Room> roomList;

        public string roomExitsDisplay = "Exits: ";
        public string roomInvDisplay = "Things: ";

        public Player(List<Room> rooms = null, Room loc = null)
        {
            roomList = rooms;
            Location = loc;
            Inventory = new List<Thing>();
            Equipment = new List<Thing>();
        }

        public void Look(string lookAt)
        {

            if (lookAt.Length >= 3)
            {

                if (lookAt == "room" || lookAt == "here")
                {
                    DisplayRoom();
                }
                else
                {
                    bool inInv = false;
                    bool inRoom = false;

                    foreach (Thing thing in this.Inventory)
                    {
                        if (thing.Name.ToLower() == lookAt || thing.Name.StartsWith(lookAt, StringComparison.CurrentCultureIgnoreCase))
                        {
                            inInv = true;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(thing.Description + "\n");
                            Console.ResetColor();

                        }
                    }
                    if (!inInv)
                    {
                        foreach (Thing thing in Location.Things)
                        {
                            if (thing.Name.ToLower() == lookAt || thing.Name.StartsWith(lookAt, StringComparison.CurrentCultureIgnoreCase))
                            {
                                inRoom = true;

                                Console.WriteLine(thing.Description + "\n");
                                if (thing.GetType() == typeof(Container))
                                {
                                    Container container = (Container)thing;

                                    if (container != null)
                                    {
                                        DisplayContents(container);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Exit exit in this.Location.ExitList)
                        {
                            if (exit.Name.ToLower() == lookAt || exit.exitTrig.StartsWith(lookAt, StringComparison.CurrentCultureIgnoreCase))
                            {
                                Console.WriteLine(exit.Description + "\n");
                            }
                        }
                    }



                }
            }
        }
        public void Go(string Dir)
        {
            Room gotoRoom;
            foreach (Exit exit in this.Location.ExitList)
            {
                if (exit.Dir != null)
                {
                    if (exit.Dir.ToLower() == Dir.ToLower())
                    {
                        Move(exit);
                        break;
                    }
                }
                else if (exit.exitTrig.ToLower() == Dir.ToLower())
                {
                    Move(exit);
                    break;
                }



            }
        }


        public void Move(Exit exit)
        {
            Room gotoRoom;

            Console.ForegroundColor = ConsoleColor.Yellow;

            if (!exit.Locked)
            {
                int goTo = exit.toRoomID;
                if (goTo != 0)
                {
                    foreach (Room room in roomList)
                    {
                        if (room.ID == goTo)
                        {
                            gotoRoom = room;
                            Console.WriteLine(exit.EDesc);
                            this.Location = null;
                            this.Location = gotoRoom;
                            break;
                        }
                    }

                    Look("room");
                }

            }
            else { Console.WriteLine("The door is locked."); }

            Console.ResetColor();

        }

        public void Get(string get)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (Thing thing in Location.Things)
            {
                if (get.Length >= 3)
                {
                    if (thing.Name.ToLower() == get || thing.Name.StartsWith(get, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (!thing.Fixed)
                        {
                            Inventory.Add(thing);
                            Location.Things.Remove(thing);
                            Console.WriteLine("You pick up the " + thing.Name);
                            break;
                        }
                        else if (thing.Fixed)
                        {
                            Console.WriteLine("You can not take that.");
                        }
                    }
                }
            }

            Console.ResetColor();

        }

        public void Get(string get, string container)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (Thing thing in Location.Things)
            {
                if (get.Length >= 3)
                {

                    if (thing.Name.ToLower() == container || thing.Name.StartsWith(get, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Container container1 = (Container)thing;
                        foreach (Thing content in container1.Contents)
                        {
                            if (content.Name.ToLower() == get || content.Name.StartsWith(get, StringComparison.CurrentCultureIgnoreCase))
                                if (!content.Fixed)
                                {
                                    Inventory.Add(content);
                                    container1.Contents.Remove(content);
                                    Console.WriteLine("You take the " + content.Name + " from the " + container1.Name);
                                    break;
                                }
                                else if (content.Fixed)
                                {
                                    Console.WriteLine("You can not take that.");
                                    break;
                                }
                        }
                    }
                }
            }

            Console.ResetColor();
        }


        public void Drop(string drop)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (Thing thing in Inventory)
            {
                if (drop.Length >= 3)
                {
                    if (thing.Name.ToLower() == drop || thing.Name.StartsWith(drop, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Location.Things.Add(thing);
                        Inventory.Remove(thing);
                        Console.WriteLine("You drop the " + thing.Name);
                        break;
                    }
                }


            }

            Console.ResetColor();
        }


        public void ShowInv()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Equipped: ");
            foreach (Thing thing in Equipment)
            {
                Console.Write(" " + thing.Name);
            }
            Console.Write("\n");
            Console.Write("Carrying: ");
            foreach (Thing thing in Inventory)
            {
                Console.Write(" " + thing.Name);
            }
            Console.Write("\n");
            Console.ResetColor();
        }


        public void Lock(string dir)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (Inventory.Count > 0)
            {
                foreach (Thing inv in Inventory)
                {
                    Exit x = this.Location.GetExit(dir.ToLower());

                    if (inv.Name.ToLower() == x.Key.ToLower() || inv.Name.StartsWith(x.Key, StringComparison.CurrentCultureIgnoreCase))
                    {
                        x.Locked = true;

                        Console.WriteLine("You lock the door with the " + inv.Name.ToLower() + ".");
                        int exitID = x.ExitID;
                        int roomID = x.toRoomID;
                        foreach (Room room in roomList)
                        {
                            if (room.ID == roomID)
                            {
                                foreach (Exit exit in room.ExitList)
                                {
                                    if (exit.ID == exitID)
                                    {
                                        exit.Locked = true;
                                    }
                                }
                            }
                        }
                        break;
                    }
                    else { Console.WriteLine("You do not seem to have a key for that."); }
                }

            }
            else { Console.WriteLine("You aren't carrying anything, let alone a key that might lock that."); }

            Console.ResetColor();
        } //end Lock method


        public void Unlock(string dir)
        {
            bool hasKey = false;

            Console.ForegroundColor = ConsoleColor.Yellow;

            if (Inventory.Count > 0)
            {
                Exit x = this.Location.GetExit(dir.ToLower());
                Console.WriteLine($"Exit Object: {x}"); // Debug output

                if (x != null) // Add a null check for the Exit object
                {
                    Console.WriteLine($"Exit ID: {x.ExitID}");
                    Console.WriteLine($"Exit toRoomID: {x.toRoomID}");
                    Console.WriteLine($"Exit Key: {x.Key}");

                    if (dir.ToLower() == "n" || dir.ToLower() == "s" || dir.ToLower() == "e" || dir.ToLower() == "w" ||
                        dir.ToLower() == "nw" || dir.ToLower() == "ne" || dir.ToLower() == "sw" || dir.ToLower() == "se" ||
                        dir.ToLower() == "u" || dir.ToLower() == "d" || dir.ToLower() == x.exitTrig.ToLower())
                    {
                        int exitID = x.ExitID;
                        int roomID = x.toRoomID;

                        foreach (Thing inv in Inventory)
                        {
                            if (inv.Name.ToLower() == x.Key.ToLower())
                            {
                                hasKey = true;
                                x.Locked = false;
                                Console.WriteLine(x.ODesc);

                                foreach (Room room in roomList)
                                {
                                    if (room.ID == roomID)
                                    {
                                        foreach (Exit exit in room.ExitList)
                                        {
                                            if (exit.ID == exitID)
                                            {
                                                exit.Locked = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        }

                    }
                }
                else { Console.WriteLine("I'm not sure which direction the " + dir + " is."); }
            }
            else { Console.WriteLine("You aren't carrying anything, let alone a key that might open that."); }

            if (!hasKey && Inventory.Count > 0)
            {
                Console.WriteLine("You do not seem to have a key for that.");
            }

            Console.ResetColor();
        } //end Unlock method


        public void Open(string container)
        {
            foreach (Thing thing in this.Location.Things)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (thing.Name.ToLower() == container)
                {
                    if (thing is Container container1)
                    {
                        // Your code here, e.g., interact with the container
                        Console.WriteLine($"IsLocked before opening: {container1.Locked}"); // Debug message
                        container1.Open();
                        Console.WriteLine(container1.ODesc);
                        Console.WriteLine($"IsLocked after opening: {container1.Locked}"); // Debug message
                        Console.WriteLine($"IsOpen after opening: {container1.isOpen}"); // Debug message
                    }
                }
                else
                {
                    // Handle the case where the Thing is not a Container
                    // or the Thing's name doesn't match the input
                }
            }

            Console.ResetColor();
        }




        public void Close(string container)
        {

            foreach (Thing thing in this.Location.Things)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (thing.Name.ToLower() == container)
                {
                    Container container1 = (Container)thing;
                    container1.Close();
                }
                Console.ResetColor();

            }

        }

        public void Equip(string item)
        {
            foreach (Thing thing in this.Inventory)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (thing.Name.ToLower() == item)
                {
                    if (thing.Wearable)
                    {
                        this.Equipment.Add(thing);
                        this.Inventory.Remove(thing);
                        Console.WriteLine(thing.EDesc);
                        break;
                    }
                    else
                        Console.WriteLine("You can't seem to find a way to wear that.");
                }
                Console.ResetColor();
            }
        }

        public void DisplayContents(Container container)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (container.isOpen)
            {
                if (container.Contents != null)
                {
                    Console.Write("Contents: ");
                    foreach (Thing content in container.Contents)
                    {
                        Console.Write(" [" + content.Name + "] ");
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                Console.WriteLine("It's closed.");
            }

            Console.ResetColor();
        }

        public void DisplayRoom()
        {
            if (Location.Things != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Location.Name + "\n");
                Console.Write(Location.Description);
                foreach (Thing thing in Location.Things)
                {
                    Console.Write(" " + thing.RDesc);
                }
                Console.Write("\n\n" + roomInvDisplay);
                foreach (Thing thing in Location.Things)
                {
                    Console.Write(" [" + thing.Name + "] ");
                }
                
            }

            Console.Write("\n");

            Console.Write(roomExitsDisplay);
            if (Location.Exits != null)
            {
                foreach (Exit exit in Location.ExitList)
                {
                    Console.Write(" " + exit.exitName + " ");
                }
            }
            Console.Write("\n");
            Console.ResetColor();
        }


        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Turns: " + this.PlayerTurns);    
            Console.ResetColor();
        }

        public void AdjustPlayerTurns(object sender, PlayerTurnsEventArgs e)
        {
            this.PlayerTurns += e.TurnsAdjustment;
        }

    }   //end Class Player


}   //end Namespace


