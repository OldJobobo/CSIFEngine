using CSIFEngine;
using System.Collections.Generic;


Main();

static void Main() {

    string Version = "Alpha 00.00.42";
    string codeName = "Syphon aka CSIF-Engine";
    string gameName = "Netrun";

    Console.WriteLine("C# Interactive Fiction Engine <Codename: " + codeName + ">  \nVersion: " + Version + "\n");
    Console.WriteLine("Developed by Chopping Block Studios");
    Console.WriteLine("Lead Developer: J.S. Brown ( aka Old Jobobo )");

    List<Room> roomsList = new List<Room>();
     
    Console.WriteLine("\n\nLoading Game: " + gameName + "\n\n\n");
    NetrunGame.Start(roomsList);

}

namespace CSIFEngine
{
    static class Game
    {
        public static bool GameOver = false;
    }

}


