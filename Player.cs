using System;
using System.Collections.Generic;
using System.Linq;
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

        private List<Room> roomList;

        public Player(List<Room> rooms, Room loc)
        {
            roomList = rooms;
            Location = loc;
            Inventory = new List<Thing>();
        }
         
        public void Look(string lookAt)
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
                    Console.Write("\n\nThings: ");
                    foreach (Thing thing in Location.Things)
                    {
                        Console.Write(" [" + thing.Name + "] ");
                    }
                }

                Console.Write("\n");

                Console.Write("Exits: ");
                if (Location.Exits != null)
                {
                    foreach (string exit in Location.Exits)
                    {
                        Console.Write(" <" + exit + "> ");
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
                    if (thing.Name.ToLower() == lookAt)
                    {
                        inInv = true;
                      
                        Console.WriteLine(thing.Description + "\n");

                    }
                }
                if (!inInv)
                {
                    foreach (Thing thing in Location.Things)
                    {
                        if (thing.Name.ToLower() == lookAt)
                        {
                            inRoom = true;
                            
                            Console.WriteLine(thing.Description + "\n");

                        }
                    }
                }
                else
                {
                    foreach (Exit exit in this.Location.ExitList)
                    {
                        if (exit.Name.ToLower() == lookAt)
                        {
                            Console.WriteLine(exit.Description + "\n");
                        }
                    }
                }



            }
        }

        public void Go(string Dir)
        {
            Room gotoRoom;

            if (Dir == "n" || Dir == "north")
            {

                Move("north");

               /* if (this.Location.CheckExit("N"))
                {
                    if (!this.Location.N.Locked)
                    {
                        int goTo = this.Location.N.toRoomID;
                        if (goTo != 0)
                        {
                            foreach (Room room in roomList)
                            {
                                if (room.ID == goTo)
                                {
                                    gotoRoom = room;
                                    Console.WriteLine("You go to the north.");
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
                else { Console.WriteLine("There is no exit to the north."); }
               */

            }
            else if (Dir == "s" || Dir == "south")
            {
                Move("south");
             /*   if (this.Location.CheckExit("S"))
                {
                    if (!this.Location.S.Locked)
                    {
                        int goTo = this.Location.S.toRoomID;
                        if (goTo != 0)
                        {
                            foreach (Room room in roomList)
                            {
                                if (room.ID == goTo)
                                {
                                    gotoRoom = room;
                                    Console.WriteLine("You go to the south.");
                                    this.Location = gotoRoom;
                                    break;
                                }
                            }

                            Look("room");
                        }
                    }
                    else { Console.WriteLine("The door is locked."); }
                }

                else { Console.WriteLine("There is no exit to the south."); }
             */

            }
            else if (Dir == "w" || Dir == "west")
            {
                if (this.Location.CheckExit("W"))
                {
                    if (!this.Location.W.Locked)
                    {
                        int goTo = this.Location.W.toRoomID;
                        if (goTo != 0)
                        {
                            foreach (Room room in roomList)
                            {
                                if (room.ID == goTo)
                                {
                                    gotoRoom = room;
                                    Console.WriteLine("You go to the west.");
                                    this.Location = gotoRoom;
                                    break;
                                }
                            }

                            Look("room");
                        }
                    }
                    else { Console.WriteLine("The door is locked."); }
                }

                else { Console.WriteLine("There is no exit to the west."); }
            }
            else if (Dir == "e" || Dir == "east")
            {
                if (this.Location.CheckExit("E"))
                {
                    if (!this.Location.E.Locked)
                    {
                        int goTo = this.Location.E.toRoomID;
                        if (goTo != 0)
                        {
                            foreach (Room room in roomList)
                            {
                                if (room.ID == goTo)
                                {
                                    gotoRoom = room;
                                    Console.WriteLine("You go to the east.");
                                    this.Location = gotoRoom;
                                    break;
                                }
                            }

                            Look("room");
                        }
                    }
                    else { Console.WriteLine("The door is locked."); }
                }
                else { Console.WriteLine("There is no exit to the east."); }
            }
            else if (Dir == "nw" || Dir == "northwest")
            {
                if (this.Location.CheckExit("NW"))
                {
                    if (!this.Location.NW.Locked)
                    {
                        int goTo = this.Location.NW.toRoomID;
                        if (goTo != 0)
                        {
                            foreach (Room room in roomList)
                            {
                                if (room.ID == goTo)
                                {
                                    gotoRoom = room;
                                    Console.WriteLine("You go to the northwest.");
                                    this.Location = gotoRoom;
                                    break;
                                }
                            }

                            Look("room");
                        }
                    }
                    else { Console.WriteLine("The door is locked."); }
                }
                else { Console.WriteLine("There is no exit to the northwest."); }

            }
            else if (Dir == "ne" || Dir == "northeast")
            {
                if (Location.CheckExit("NE"))
                {
                    if (!this.Location.NE.Locked)
                    {
                        int goTo = this.Location.NE.toRoomID;
                        if (goTo != 0)
                        {
                            foreach (Room room in roomList)
                            {
                                if (room.ID == goTo)
                                {
                                    gotoRoom = room;
                                    Console.WriteLine("You go to the northeast.");
                                    this.Location = gotoRoom;
                                    break;
                                }
                            }

                            Look("room");
                        }
                    }
                    else { Console.WriteLine("The door is locked."); }
                }
                else { Console.WriteLine("There is no exit to the northeast."); }
            }
            else if (Dir == "sw" || Dir == "southwest")
            {

                if (this.Location.CheckExit("SW"))
                {
                    if (!this.Location.S.Locked)
                    {
                        int goTo = this.Location.SW.toRoomID;
                        if (goTo != 0)
                        {
                            foreach (Room room in roomList)
                            {
                                if (room.ID == goTo)
                                {
                                    gotoRoom = room;
                                    Console.WriteLine("You go to the southwest.");
                                    this.Location = gotoRoom;
                                    break;
                                }
                            }

                            Look("room");
                        }
                    }
                    else { Console.WriteLine("The door is locked."); }
                }
                else { Console.WriteLine("There is no exit to the southwest."); }
            }
            else if (Dir == "se" || Dir == "southeast")
            {

                if (this.Location.CheckExit("SE"))
                {
                    if (!this.Location.S.Locked)
                    {
                        int goTo = this.Location.SE.toRoomID;
                        if (goTo != 0)
                        {
                            foreach (Room room in roomList)
                            {
                                if (room.ID == goTo)
                                {
                                    gotoRoom = room;
                                    Console.WriteLine("You go to the southeast.");
                                    this.Location = gotoRoom;
                                    break;
                                }
                            }

                            Look("room");
                        }
                    }
                    else { Console.WriteLine("The door is locked."); }
                }
                else { Console.WriteLine("There is no exit to the southeast."); }
            }

        }


        public void Move(string direction)
        {
            Room gotoRoom;
            Exit exit = this.Location.GetExit(direction);

            if ( this.Location.CheckExit( direction.ToLower() ) )
            {
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
                                Console.WriteLine("You go to the " + direction + ".");
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
            else { Console.WriteLine("There is no exit to the " + direction.ToLower() + "."); }
        }

        public void Get(string get)
        {
            foreach (Thing thing in Location.Things)
            {
                if (get.Length >= 3)
                {
                    if (thing.Name.ToLower() == get || thing.Name.StartsWith(get, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Inventory.Add(thing);
                        Location.Things.Remove(thing);
                        Console.WriteLine("You pick up the " + thing.Name);
                        break;
                    }
                }
            }

        }


        public void Drop(string drop)
        {
            foreach (Thing thing in Inventory)
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


        public void ShowInv()
        {
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
                    if (inv.Name.ToLower() == x.Key.ToLower())
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
                       dir.ToLower() == "nw" || dir.ToLower() == "ne" || dir.ToLower() == "sw" || dir.ToLower() == "se")
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

        public void Info()
        {
            Console.WriteLine("Turns: " + this.PlayerTurns);    
        }



    }   //end Class Player


}   //end Namespace


