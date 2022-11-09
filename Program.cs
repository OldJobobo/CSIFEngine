using CSIFEngine;
using System.Collections.Generic;


Main();

static void Main() {

    string Version = "0.1.00 Alpha";
    string codeName = "Syphon";
    
    string gameName = "Netrun";
    //string gameName = "Trade War 4040";

    Console.WriteLine("CSIFEngine V." + Version + "\nC# Interactive Fiction Engine <Codename: " + codeName + ">  \n");
    Console.WriteLine("Developed by Chopping Block Studios");
    Console.WriteLine("Lead Developer: J.S. Brown ( aka Old Jobobo )");

    List<Room> roomsList = new List<Room>();
     
    Console.WriteLine("\n\nLoading Game: " + gameName + "\n\n\n");

    NetrunGame.Start(roomsList);
   //TradeWar4040.Start(roomsList);
}

namespace CSIFEngine
{
    static class Game
    {
        public static bool GameOver = false;
    }

}


