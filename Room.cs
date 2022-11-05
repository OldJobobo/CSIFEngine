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
            else { return false; }
        }

        public void AddExit(string exit)
        {
            this.Exits.Add(exit);
            this.ExitList.Add(GetExit(exit));
        }

        public void AddThing(Thing thing)
        {
            Things.Add(thing);
        }

        public Exit GetExit(string dir)
        {
            if (dir.ToLower() == "n" || dir.ToLower() == "north") { Exit x = this.N; return x; }
            else if (dir.ToLower() == "s" || dir.ToLower() == "south") { Exit x = this.S; return x; }
            else if (dir.ToLower() == "e" || dir.ToLower() == "east") { Exit x = this.E; return x; }
            else if (dir.ToLower() == "w" || dir.ToLower() == "west") { Exit x = this.W; return x; }
            else if (dir.ToLower() == "sw" || dir.ToLower() == "southwest") { Exit x = this.SW; return x; }
            else if (dir.ToLower() == "se" || dir.ToLower() == "southeast") { Exit x = this.SE; return x; }
            else if (dir.ToLower() == "nw" || dir.ToLower() == "northwest") { Exit x = this.NW; return x; }
            else if (dir.ToLower() == "ne" || dir.ToLower() == "northeast") { Exit x = this.SE; return x; }
            else { return null; }

          
        }

    }
}
