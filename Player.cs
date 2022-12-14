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

        private List<Room> roomList;

        public string roomExitsDisplay = "Exits: ";
        public string roomInvDisplay = "Things: ";

        public Player(List<Room> rooms, Room loc)
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
                    if (Location.Things != null)
                    {
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

                            Console.WriteLine(thing.Description + "\n");

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
                                }
                            }
                        }  
                    }
                    else
                    {
                        foreach (Exit exit in this.Location.ExitList)
                        {
                            if (exit.Name.ToLower() == lookAt || exit.Name.StartsWith(lookAt, StringComparison.CurrentCultureIgnoreCase))
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
                if (exit.Dir.ToLower() == Dir.ToLower())
                {
                    Move(exit);
                    break;
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

         
        }

        public void Get(string get)
        {
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

        }

        public void Get(string get, string container)
        {
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
        }


        public void Drop(string drop)
        {
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
        }


        public void ShowInv()
        {
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
        }


        public void Lock(string dir)
        {
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

        } //end Lock method


        public void Unlock(string dir)
        {

            if (Inventory.Count > 0)
            {
                foreach (Thing inv in Inventory)
                {
                    if (dir.ToLower() == "n" || dir.ToLower() == "s" || dir.ToLower() == "e" || dir.ToLower() == "w" ||
                       dir.ToLower() == "nw" || dir.ToLower() == "ne" || dir.ToLower() == "sw" || dir.ToLower() == "se" ||
                       dir.ToLower() == "u" || dir.ToLower() == "d")
                    {
                        Exit x = this.Location.GetExit(dir.ToLower());
                        int exitID = x.ExitID;
                        int roomID = x.toRoomID;

                        if (inv.Name.ToLower() == x.Key.ToLower())
                        {
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
                        }
                        else { Console.WriteLine("You do not seem to have a key for that."); }

                    }
                    else { Console.WriteLine("I'm not sure which direction the " + dir + " is."); }
                }
            }
            else { Console.WriteLine("You aren't carrying anything, let alone a key that might open that."); }


        } //end Unlock method

        public void Open(string container)
        {
            foreach (Thing thing in this.Location.Things)
            {
                if (thing.Name.ToLower() == container)
                {
                    Container container1 = (Container)thing;
                    container1.Open();
                    Console.WriteLine(container1.ODesc);
                }
            }
            //container.Open();
        }
        public void Close(string container)
        {

            foreach (Thing thing in this.Location.Things)
            {
                if (thing.Name.ToLower() == container)
                {
                    Container container1 = (Container)thing;
                    container1.Close();
                }
            }
        }

        public void Equip(string item)
        {
            foreach (Thing thing in this.Inventory)
            {
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
            }
        }

        public void Info()
        {
            Console.WriteLine("Turns: " + this.PlayerTurns);    
        }



    }   //end Class Player


}   //end Namespace


