using CSIFEngine;
using NetrunGame;


Main();

static void Main() {

    string Version = "0.1.00 Alpha";
    string codeName = "Syphon";

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("CSIFEngine V." + Version + "\nC# Interactive Fiction Engine <Codename: " + codeName + ">  \n");
    Console.WriteLine("Developed by Chopping Block Studios");
    Console.WriteLine("Lead Developer: J.S. Brown ( aka Old Jobobo )");

    List<Room> roomsList = new List<Room>();

    Console.Write("Which game? [1]Netrun [2]TradeWar4040 > ");
    string? commands = Console.ReadLine();

    string[] words;

    if (commands != null)
    {
        words = commands.Split(' ');

        if (words[0] == "1")
        {
            string gameName = "Netrun";
            Console.WriteLine("\n\nLoading Game: " + gameName + "\n\n\n");
            World.Start(roomsList);
        }
        else if (words[0] == "2")
        {
            string gameName = "Trade War 4040";
            Console.WriteLine("\n\nLoading Game: " + gameName + "\n\n\n");
            TradeWar4040.Start(roomsList);
        }
    }
}



