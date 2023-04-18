using CSIFEngine;
using NetrunGame;


Main();

static void Main() {

    string Version = "0.1.5 Alpha";
    string codeName = "Syphon";

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("CSIFEngine V." + Version + "\nC# Interactive Fiction Engine <Codename: " + codeName + ">  \n");
    Console.WriteLine("Developed by Chopping Block Studios");
    Console.WriteLine("Lead Developer: J.S. Brown ( aka Old Jobobo )");

    List<Room> roomsList = new List<Room>();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Which game? [");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("1");
    Console.ForegroundColor= ConsoleColor.Yellow;
    Console.Write("]Netrun [");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("2");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("]TradeWar4040 > ");

    
    
        
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



