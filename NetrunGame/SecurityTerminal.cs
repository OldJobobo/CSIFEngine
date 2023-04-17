using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSIFEngine;

namespace NetrunGame
{
    public class SecurityTerminal : HackableDevice
    {
        public string HackMessage { get; set; }
        public List<Action> HackActions { get; set; }

        public SecurityTerminal(string name, string description, string hackMessage)
            : base(name, description, hackMessage)
        {
            IsHacked = false;
            HackMessage = hackMessage;
            HackActions = new List<Action>();
        }


        public void Hack(Player player)
        {
            if (IsHacked)
            {
                Console.WriteLine("The terminal has already been hacked.");
                return;
            }

            // Implement the hacking process here (e.g., solving a puzzle or using a hacking tool)
            // If successful, set IsHacked to true, display HackMessage, and execute HackActions
        }
        // Add any additional properties or methods related to the security terminal here
    }

}
