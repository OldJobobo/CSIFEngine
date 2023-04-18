using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSIFEngine;

namespace NetrunGame
{
    internal class ARGlasses : Thing
    {
        private Player player;

        public ARGlasses(Player player) : base(null, null)
        {
            this.player = player;
        }

        public override void Parse(string[] words)
        {
            Console.WriteLine("Debug: ARGlasses.Parse()");
            
            string command = words[0];

            switch (command)
            {
                case "hack":
                    if (words.Length > 1)
                    {
                        string deviceName = words[1];
                        HackDevice(deviceName);
                    }
                    else
                    {
                        Console.WriteLine("You must specify a device to hack.");
                    }
                    break;
                default:
                    Console.WriteLine("The AR-Glasses do not understand this command.");
                    break;
            }
        }

        private void HackDevice(string deviceName)
        {
            List<HackableDevice> hackableDevices = GetHackableDevices();

            HackableDevice targetDevice = hackableDevices.FirstOrDefault(d => d.Name.Equals(deviceName, StringComparison.OrdinalIgnoreCase));

            if (targetDevice != null)
            {
                // Add your hacking logic here
                Console.WriteLine($"You successfully hack the {deviceName}.");
            }
            else
            {
                Console.WriteLine($"No hackable device named '{deviceName}' found.");
            }
        }

        private List<HackableDevice> GetHackableDevices()
        {
            List<HackableDevice> hackableDevices = new List<HackableDevice>();

            // Scan player's location
            hackableDevices.AddRange(player.Location.Things.OfType<HackableDevice>());

            // Scan player's inventory
            hackableDevices.AddRange(player.Inventory.OfType<HackableDevice>());

            return hackableDevices;
        }
    }
}
