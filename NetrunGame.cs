using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSIFEngine
{
    public static class NetrunGame
    {
        public static void Start(List<Room> rooms)
        {
             
            //Initial Rooms and Things

            //Starting location Players Apartment
            Room apartment = new Room();
            apartment.Name = "Your Apartment";
            apartment.Description = "            You are in a dingy apartment. Rain spatters the window which frames a view of the city, plastered with \n" +
                                    "    neon signs and large shifting LED billboards.";
            apartment.ID = 1;

            //Apartment Door Exit
            Exit aptDoor = new Exit
                (
                    id: 1,
                    name: "Apartment Door",
                    desc: "An average looking metal apartment door. The same one you come in and out of every day.",
                    direction: "N",
                    roomID: 2,
                    exitID: 2,
                    lockable: true,
                    locked: true,
                    key: "keycard"
                );
            aptDoor.aliases = new List<string> { "door", "aptdoor" };
            aptDoor.ODesc = "You hold the " + aptDoor.Key + " up to the small touchscreen to the left of the door and it slides open.";
            apartment.N = aptDoor;
            apartment.AddExit("N");

            //Batheroom Door in Apt
            Exit bathDoor = new(4, "Bathroom Door", "The door to your apartment bathroom.", "e", 3, 3);
            apartment.E = bathDoor;
            apartment.AddExit("E");

            //AR-Glasses Item
            Thing arGlasses = new Thing();
            arGlasses.ID = 2;
            arGlasses.Name = "AR-Glasses";
            arGlasses.Description = "          A pair AR-Glasses, yours to be exact.  They look like a regular pair of glasses but with slightly\n" +
                                    "     chunky frames to hold the internal components.";
            arGlasses.RDesc = "You see your AR-Glasses here.";
            arGlasses.EDesc = "You slip on the AR-Glasses and the old familiar logos and updates insue and finally your AR vision is fully activated.";
            arGlasses.Wearable = true;
            //apartment.AddThing(arGlasses);  //added to locker instead

            //Keycard Item
            Thing keycard = new Thing();
            keycard.Name = "Keycard";
            keycard.Description = "         You see a plastic keycard, slightly thick as if it contains a small amount of \n" +
                                  "    electronics within it's tiny form.";
            keycard.ID = 1;
            keycard.RDesc = "You see a keycard here.";
            //apartment.AddThing(keycard);    //added to locker instead

            //Locker Container
            Container locker = new Container(new List<Thing> { arGlasses, keycard }, false, false);
            locker.Name = "Locker";
            locker.Description = "A personal locker were you keep some of your things.";
            locker.ODesc = "You touch the screen on the locker and look into the camera, you here a click and the locker swings open.";
            locker.Fixed = true;
            apartment.AddThing(locker);


            //Add Apartment to Roomlist
            rooms.Add(apartment);


     

            //Hallway Room
            Room hallway = new Room();
            hallway.Name = "Apartment Building Hallway";
            hallway.Description =    "          The hallway is long and closterphobic. The paint is cracked and pealing in places as the flourecent lights \n" +
                                     "     hum  overhead. A few wires are hung or loosly mounted along the walls.";
            hallway.ID = 2;
            Exit aptDoor2 = new(2, "Apartment Door", "An average looking metal apartment door. The same one you come in and out of every day.", "S", 1, 1, true, true, "keycard");
            hallway.S = aptDoor2;
            hallway.AddExit("S");
            Exit hallElevator = new(6, "Hallway Elevator", "    An aging elevator to the first floor lobby of the Building.", "W", 4, 5);
            hallway.W = hallElevator;
            hallway.AddExit("W");

            //Add Hallway to roomslist
            rooms.Add(hallway);


            Room bathroom = new Room();
            bathroom.Name = "Apartment Bathroom";
            bathroom.Description =   "          The cramped apartment bathroom, also known as the Relax-O-Clean 2087, is neither clean nor relaxing. The\n" +
                                     "     size of a single standing shower stall. The waterproof smart mirror has commands to control the toilet, sink,\n" +
                                     "     and shower which slide out of the wall as needed..";
            bathroom.ID = 3;
            Exit bathDoor2 = new(3, "Bathroom Door", "The back to the rest of your apartment.","W", 1, 4 );
            bathDoor2.Locked = false;
            bathDoor2.Lockable = false;
            bathroom.W = bathDoor2;
            bathroom.AddExit("W");

            rooms.Add(bathroom);


            Room aptLobby = new Room();
            aptLobby.Name = "Apartment Building Lobby";
            aptLobby.Description = "          The lobby was obviously elegant and stylish at one time but now its clear that it has seen better days.  Dust\n" +
                                   "    and haze are illuminated by the eerie glow of magenta and yellow light from the neon and digital signs visible from\n" +
                                   "    the lobby windows which looking out onto the street outside.";
            aptLobby.ID = 4;
            Exit lobbyElevator = new(5, "Lobby Elevator", "    An aging elevator to the upper floors of the Building.", "W", 2, 6);
            aptLobby.W = lobbyElevator;
            aptLobby.AddExit("W");
            Exit lobbyExit = new(4, "Exit to Slicer Ave", "     Aging but elegant and elaberatly designed is the building's entrance, which leads to Slicer Ave.", "E", 5, 1);
            aptLobby.E = lobbyExit;
            aptLobby.AddExit("E");

            rooms.Add(aptLobby);

            Room slicerAve = new Room();
            slicerAve.Name = "Slicer Ave";
            slicerAve.Description = "          A few random pedestrians wonder by but pretty deserted compared to other areas of the City.  Your\n" +
                                    "    apartment building looms over you to the west.";
            slicerAve.ID = 5;
            Exit aptBuilding = new(1, "Apartment Building", "     You see the front entrance to your apartment building.", "W", 4, 4 );
            slicerAve.W = aptBuilding;
            slicerAve.AddExit("W");

            rooms.Add(slicerAve);



            //Initialize Player and GameManager
            Player player = new Player(rooms, apartment);  //Create the player, pass list of rooms and starting location
            GameManager gameManager = new GameManager(rooms, player);  //Create the GameManager, pass the list of rooms and the player


            player.Look("room"); //Look at the start location on start.

            //Initiate Main Game Loop
            while (Game.GameOver == false)
            {
                string[] commands = gameManager.Prompt(); //Display prompt and get user input

                gameManager.Parse(commands); //Parse the users commands
            }
        }

    }
}
