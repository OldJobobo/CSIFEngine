using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine
{
    public class Exit : Thing
    {
   
        private string dir;
        private int toroomid;
        private int exitid;
        private bool lockable;
        private bool locked;
        private string key;
        private string oDesc;
        private string cDesc;


        public string Dir { get { return dir; } set { dir = value; } }
        public int toRoomID { get { return toroomid; } set { toroomid = value; } }
        public int ExitID { get { return exitid; } set { exitid = value; } }    
        public bool Lockable { get { return lockable; } set { lockable = value; } }
        public bool Locked { get { return locked; } set { locked = value; } }   
        public string Key { get { return key; } set { key = value; } }
        public string ODesc { get { return oDesc; } set { oDesc = value; } }
        public string CDesc { get { return cDesc; } set { cDesc = value; } }


        public List<string> aliases;

        public Exit(int id, string name, string desc, string direction, int roomID, int exitID )
        {
            ID = id;
            Name = name;
            Description = desc; 
            Dir = direction;
            toRoomID = roomID;
            ExitID = exitID;

            aliases = new List<string>();
        }
        public Exit(int id, string name, string desc, string direction, int roomID, int exitID, bool lockable, bool locked, string key)
        {
            ID = id;
            Name = name;
            Description = desc;
            Dir = direction;
            toRoomID = roomID;
            ExitID = exitID;
            Lockable = lockable; 
            Locked = locked;
            Key = key;

            aliases = new List<string>();
        }
    }

 
}
