using CSIFEngine;
using System.Collections.Generic;


Main();

static void Main() {

    string Version = "00.00.54 Alpha";
    string codeName = "Syphon";
    string gameName = "Netrun";

    Console.WriteLine("CSIFEngine V." + Version + "\nC# Interactive Fiction Engine <Codename: " + codeName + ">  \n");
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


