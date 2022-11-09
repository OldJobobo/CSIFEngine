using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine
{
    public class Room
    {
        private int id;
        private string name;
        private string description;
         
        private Exit north;
        private Exit south;
        private Exit west;
        private Exit east;
        private Exit southwest;
        private Exit southeast;
        private Exit northwest;
        private Exit northeast;
        private Exit up;
        private Exit down;

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int ID { get { return id; } set { id = value; } }
        public Exit N { get { return north; } set { north = value; } }
        public Exit S { get { return south; } set { south = value; } }   
        public Exit W { get { return west; } set { west = value; } }  
        public Exit E { get { return east; } set { east = value; } }    
        public Exit SW { get { return southwest; } set { southwest = value; } }  
        public Exit SE { get { return southeast; } set { southeast = value; } }  
        public Exit NW { get { return northwest; } set { northwest = value; } }    
        public Exit NE { get { return northeast; } set { northeast = value; } }
        public Exit U { get { return up; } set { up = value; } }    
        public Exit D { get { return down; } set { down = value; } }


        public List<Exit> ExitList { get; set; }
        public List<string> Exits { get; set; }
        public List<Thing> Things { get; set; }

        public Room()
        {
            ExitList = new List<Exit>();
            Exits = new List<string>();
            Things = new List<Thing>();
        }

        public bool CheckExit(string Dir)
        {
            if (Dir.ToLower() == "n" || Dir.ToLower() == "north")
            {
                if (N != null) { return true; } else { return false; }
            }
            else if (Dir.ToLower() == "s" || Dir.ToLower() == "south")
            {
                if (S != null) { return true; } else { return false; }
            }
            else if (Dir.ToLower() == "w" || Dir.ToLower() == "west")
            {
                if (W != null) { return true; } else { return false; }
            }
            else if (Dir.ToLower() == "e" || Dir.ToLower() == "east")
            {
                if (E != null) { return true; } else { return false;  }
            }
            else if (Dir.ToLower() == "nw" || Dir.ToLower() == "northwest")
            {
                if (NW != null) { return true; } else { return false; }
            }
            else if (Dir.ToLower() == "sw" || Dir.ToLower() == "southwest")
            {
                if (SW != null) { return true; } else { return false; }
            }
            else if (Dir.ToLower() == "se" || Dir.ToLower() == "southeast")
            {
                if (SE != null) { return true; } else { return false; }
            }
            else if (Dir.ToLower() == "ne" || Dir.ToLower() == "northeast")
            {
                if (NE != null) { return true; } else { return false; }
            }
            else if (Dir.ToLower() == "u" || Dir.ToLower() == "up")
            {
                if (U != null) { return true; } else { return false; }
            }
            else if (Dir.ToLower() == "d" || Dir.ToLower() == "down")
            {
                if (D != null) { return true; } else { return false; }
            }
            else { return false; }
        }

        public void AddExit(string exit)
        {
            this.Exits.Add(exit);
        }

        public void AddThing(Thing thing)
        {
            Things.Add(thing);
        }

        public Exit GetExit(string dir)
        {

  
            Exit x = null;
            if (ExitList != null)
            {
                foreach (Exit exit in this.ExitList)
                {
                    if (exit != null)
                    {
                        if (exit.Dir.ToLower() == dir.ToLower())
                        {
                            x = exit;
                            break;
                        }
                    }

                }
            }
            return x;
        }

    }
}
