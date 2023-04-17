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
        public List<HackableActionType> HackableActionTypes { get; set; } = new List<HackableActionType>();

        public SecurityTerminal(string name, string description, int securityLevel)
            : base(name, description, securityLevel)
        {
        }

        public void ExecuteHackableAction(HackableActionType actionType)
        {
            if (!IsHacked)
            {
                Console.WriteLine("You must hack the terminal first.");
                return;
            }

            switch (actionType)
            {
                case HackableActionType.UnlockDoors:
                    // Unlock all locked doors in the building
                    Console.WriteLine("All locked doors in the building are now unlocked.");
                    break;
                case HackableActionType.AccessCameras:
                    // Access security camera feeds
                    Console.WriteLine("You can now access the security camera feeds.");
                    break;
                default:
                    Console.WriteLine("Unknown hackable action.");
                    break;
            }
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
