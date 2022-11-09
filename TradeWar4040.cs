using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine
{
    public static class TradeWar4040
    {

        public static void Start(List<Room> rooms)
        {
            Room homeSector = new Room();
            homeSector.Name = "Sector: 3457";
            homeSector.Description = "This is your Home Sector.";
            

            //Initialize Player and GameManager
            Player player = new Player(rooms, homeSector);  //Create the player, pass list of rooms and starting location
            GameManager gameManager = new GameManager(rooms, player);  //Create the GameManager, pass the list of rooms and the player

            player.roomExitsDisplay = "Warps to Sector(s): ";  //Customize how Exits are displayed
            player.roomInvDisplay = "Planets: "; //Change Things to Planets

            //TODO: Code an example Intro Scene sequence.

            player.Look("room"); //Look at the start location to display something on start.

            


            //Initiate Main Game Loop
            while (Game.GameOver == false)
            {
                string[] commands = gameManager.Prompt(); //Display prompt and get user input

                gameManager.Parse(commands); //Parse the users commands
            }
        }
    }
}
