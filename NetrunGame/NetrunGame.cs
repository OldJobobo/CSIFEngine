using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSIFEngine;


/*
 * This is the main Demo Game for CSIFEngine.  
 */
namespace NetrunGame
{

    public static class World
    {
        public static void Start(List<Room> rooms)
        {

            Player player = new Player();  //Create the base player object


            //Initial Rooms and Things

            //Starting location Players Apartment
            Room apartment = new Room();
            apartment.Name = "Your Apartment";
            apartment.Description = "          You find yourself in a dimly lit, cramped apartment, the embodiment of urban decay. The \n" +
                                    "damp, musty smell of old wallpaper mixed with the scent of lingering cigarette smoke hangs in the \n" +
                                    "air. The rain beats a relentless rhythm against the window, a barrier between you and the sprawling\n" +
                                    " metropolis outside. As you peer through the grimy glass, the cityscape reveals itself as a cacophony \n" +
                                    "of neon signs and massive, ever-shifting LED billboards, their garish hues bleeding into one another. \n" +
                                    "The oppressive hum of machinery and the distant wail of sirens provide a fitting soundtrack to this \n" +
                                    "dystopian tableau.\n\n" +
                                    "The apartment itself is a testament to neglect; clutter is strewn haphazardly across the worn, threadbare \n" +
                                    "carpet. A sagging, stained mattress in one corner serves as a makeshift bed, the only concession to \n" +
                                    "comfort in this dismal space. The peeling wallpaper, a faded relic from a bygone era, curls away from \n" +
                                    "the damp plaster in defiance of gravity, revealing the cold, unfeeling concrete beneath.\n\n" +
                                    "A single, flickering lightbulb casts sinister shadows across the cracked walls, its erratic dance \n" +
                                    "reflecting the uncertainty and chaos that lies just beyond the apartment's door. The air feels thick, \n" +
                                    "suffocating, laden with the weight of countless untold stories and forgotten lives. This dingy refuge \n" +
                                    "is a microcosm of the city itself: a desperate, decaying haven for those struggling to survive in a world \n" +
                                    "grown indifferent to their plight.\n";


            apartment.ID = 1;

            //Apartment Door Exit
            Exit aptDoor = new Exit
                (
                    id: 1,
                    name: "Apartment Door",
                    desc: "An average looking metal apartment door. The same one you come in and out of every day.",
                    //direction: "N",
                    roomID: 2,
                    exitID: 2,
                    lockable: true,
                    locked: true,
                    key: "keycard"
                );

            aptDoor.exitName = "<H>allway";
            aptDoor.exitTrig = "H";
            aptDoor.aliases = new List<string> { "door", "aptdoor" };
            aptDoor.ODesc = "You hold the " + aptDoor.Key + " up to the small touchscreen to the left of the door and it slides open.";
            apartment.ExitList.Add(aptDoor);
            apartment.N = aptDoor;
            apartment.AddExit("N");

            //Batheroom Door in Apt
            Exit bathDoor = new(4, "Bathroom Door", "The door to your apartment bathroom.", 3, 3);
            bathDoor.exitName = "<B>athroom";
            bathDoor.exitTrig = "B";
            bathDoor.EDesc = "You move into the Bathroom.";
            apartment.E = bathDoor;
            apartment.AddExit("E");
            apartment.ExitList.Add(bathDoor);

            //AR-Glasses Item
            Thing arGlasses = new ARGlasses(player);
            arGlasses.ID = 2;
            arGlasses.Name = "AR-Glasses";
            arGlasses.Description = "          A pair AR-Glasses, yours to be exact.  They look like a regular pair of glasses but with slightly\n" +
                                    "     chunky frames to hold the internal components.";
            arGlasses.RDesc = "You see your AR-Glasses here.";
            arGlasses.EDesc = "You slip on the AR-Glasses and the old familiar logos and updates insue and finally your AR vision is fully activated.";
            arGlasses.Wearable = true;
            arGlasses.Listener = true;
            //apartment.AddThing(arGlasses);  //added to locker instead

            //Keycard Item
            Thing keycard = new Thing("","");
            keycard.Name = "Keycard";
            keycard.Description = "         You see a plastic keycard, slightly thick as if it contains a small amount of \n" +
                                  "    electronics within it's tiny form.";
            keycard.ID = 1;
            keycard.RDesc = "You see a keycard here.";
            //apartment.AddThing(keycard);    //added to locker instead

            //Locker Container
            Container locker = new Container("", "", new List<Thing> { arGlasses, keycard }, false, false);
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
            hallway.Description = "          The hallway is long and closterphobic. The paint is cracked and pealing in places as the flourecent lights \n" +
                                     "     hum  overhead. A few wires are hung or loosly mounted along the walls.";
            hallway.ID = 2;

            //Hallway door to apartment
            Exit aptDoor2 = new(2, "Apartment Door", "An average looking metal apartment door. The same one you come in and out of every day.", 1, 1, true, true, "keycard");
            aptDoor2.exitName = "<A>partment 303";
            aptDoor2.exitTrig = "A";
            hallway.S = aptDoor2;
            hallway.AddExit("S");
            hallway.ExitList.Add(aptDoor2);

            //Hallway door to Elevator
            Exit hallElevator = new(6, "Hallway Elevator", "    An aging elevator to the first floor lobby of the Building.", 4, 5);
            hallElevator.exitName = "E<L>evator";
            hallElevator.exitTrig = "L";

            hallway.W = hallElevator;
            hallway.AddExit("W");
            hallway.ExitList.Add(hallElevator);

            //Add Hallway to roomslist
            rooms.Add(hallway);

            // Apartment bathroom
            Room bathroom = new Room();
            bathroom.Name = "Apartment Bathroom";
            bathroom.Description = "          The cramped apartment bathroom, also known as the Relax-O-Clean 2087, is neither clean nor relaxing. The\n" +
                                     "     size of a single standing shower stall. The waterproof smart mirror has commands to control the toilet, sink,\n" +
                                     "     and shower which slide out of the wall as needed..";
            bathroom.ID = 3;

            //Bathroom door back to apartment
            Exit bathDoor2 = new(3, "Bathroom Door", "The back to the rest of your apartment.", 1, 4);
            bathDoor2.Locked = false;
            bathDoor2.Lockable = false;
            bathDoor2.exitName = "<L>iving Room";
            bathDoor2.exitTrig = "L";
            bathroom.W = bathDoor2;
            bathroom.AddExit("W");
            bathroom.ExitList.Add(bathDoor2);
            rooms.Add(bathroom);

            //Lobby room
            Room aptLobby = new Room();
            aptLobby.Name = "Apartment Building Lobby";
            aptLobby.Description = "          The lobby was obviously elegant and stylish at one time but now its clear that it has seen better days.  Dust\n" +
                                   "    and haze are illuminated by the eerie glow of magenta and yellow light from the neon and digital signs visible from\n" +
                                   "    the lobby windows which looking out onto the street outside.";
            aptLobby.ID = 4;
            // hacker npc
            NPC hacker = new NPC(1, "Hacker", "A mysterious hacker wearing a hood.", true, "The hacker says, 'I don't know anything about that.'");
            hacker.AddDialogue("password", "The hacker says, 'The password for the secret server is 12345.'");
            hacker.AddDialogue("mission", "The hacker says, 'Your mission is to infiltrate the secret server and retrieve valuable data.'");
            hacker.AddDialogue("server", "The hacker says, 'The secret server is located in the Cybersecurity Lab.'");
            hacker.RDesc = "You see a mysterious hacker here.";
            hacker.Fixed = true;
            aptLobby.AddThing(hacker);

            // Security Terminal
            SecurityTerminal securityTerminal = new SecurityTerminal(
                "Security Terminal",
                "An old security terminal that controls access to various security features of the building.",
                1 // Security level
            );
            securityTerminal.Fixed = true; // Can't be moved or picked up
            securityTerminal.HackableActionTypes.Add(HackableActionType.UnlockDoors);
            securityTerminal.HackableActionTypes.Add(HackableActionType.AccessCameras);

            aptLobby.AddThing(securityTerminal);



           

            //Lobby door to Elevator
            Exit lobbyElevator = new(5, "Lobby Elevator", "    An aging elevator to the upper floors of the Building.", 2, 6);
            lobbyElevator.exitName = "E<L>evator";
            lobbyElevator.exitTrig = "L";
            aptLobby.W = lobbyElevator;
            aptLobby.AddExit("W");
            aptLobby.ExitList.Add(lobbyElevator);

            // Lobby door to Slicer Ave
            Exit lobbyExit = new(4, "Exit to Slicer Ave", "     Aging but elegant and elaberatly designed is the building's entrance, which leads to Slicer Ave.", 5, 1);
            lobbyExit.exitName = "Lobby E<X>it";
            lobbyExit.exitTrig = "X";
            aptLobby.E = lobbyExit;
            aptLobby.AddExit("E");
            aptLobby.ExitList.Add(lobbyExit);
            rooms.Add(aptLobby);

            //Slicer Ave
            Room slicerAve = new Room();
            slicerAve.Name = "Slicer Ave";
            slicerAve.Description = "          A few random pedestrians wonder by but pretty deserted compared to other areas of the City.  Your\n" +
                                    "    apartment building looms over you to the west.";
            slicerAve.ID = 5;

            //Slicer Ave door to Apartment Building Lobby
            Exit aptBuilding = new(1, "Apartment Building", "     You see the front entrance to your apartment building.", 4, 4);
            aptBuilding.exitName = "<T>uring Apartments";
            aptBuilding.exitTrig = "T";
            slicerAve.W = aptBuilding;
            slicerAve.AddExit("W");
            slicerAve.ExitList.Add(aptBuilding);
            rooms.Add(slicerAve);

            //Send the rooms and start location to the player object
            player.roomList = rooms;
            player.Location = apartment;

            //Initialize GameManager
            GameManager gameManager = new GameManager(rooms, player);  //Create the GameManager, pass the list of rooms and the player

            //Subscribe to Events
            hacker.PlayerTurnsAdjustment += player.AdjustPlayerTurns;

            //TODO: Code an example Intro Scene sequence.

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
