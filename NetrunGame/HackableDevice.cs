using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSIFEngine;

namespace NetrunGame
{
  


    public class HackableDevice : Thing
    {
        public int SecurityLevel { get; set; }
        public bool IsHacked { get; set; }

        public HackableDevice(string name, string description, int securityLevel)
            : base(name, description)
        {
            SecurityLevel = securityLevel;
            IsHacked = false;
        }

        public HackableDevice(string name = null, string description = null, string hackMessage = null) : base(name, description)
        {
        }

        // Add any other properties, methods, or events specific to hackable devices here.
    }
}
