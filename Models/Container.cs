using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine
{
    public class Container : Thing
    {
        private bool lockable = false;
        private bool locked = false;
        private bool isopen = false;
        private string oDesc;
        private string cDesc;
        private string key;

        public bool Lockable { get { return lockable; } set { lockable = value; } }
        public bool Locked { get { return locked; } set { locked = value; } }
        public bool isOpen { get { return isopen; } set { isopen = value; } }
        public string ODesc { get { return oDesc; } set { oDesc = value; } }
        public string CDesc { get { return cDesc; } set { cDesc = value; } }
        public string Key { get { return key; } set { key = value; } }

        public List<Thing> Contents;

        public Container() : base()
        {
        }

        public Container(string name, string description, List<Thing> contents, bool lockable, bool locked)
            : base(name, description)
        {
            Lockable = lockable;
            Locked = locked;

            Contents = contents;
        }
        public Container(string name, string description, List<Thing> contents, bool lockable, bool locked, string key) 
            : base(name, description)
        {
            Lockable = lockable;
            Locked = locked;

            Contents = contents;
            Key = key;
        }

        public void Open()
        {
            isOpen = true;
        }

        public void Close()
        {
            isOpen = false;
        }
    }
}
