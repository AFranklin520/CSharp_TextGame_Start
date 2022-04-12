// TravelOption
// Programer: Rob Garner (rgarner7@cnm.edu)
// Date: 25 May 2016
// Represents a travel option.

//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//Map.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Class that represents the game. 
    /// Has a map and location of player.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// List of map locations.
        /// </summary>
        public List<MapLocation> Locations { get; set; }

        //public MapLocation PlayerLocation { get; set; }

        /// AF PlayerLocation has been moved to new Player class

        /// <summary>
        /// Constructor that creates the game map.
        /// </summary>
        public Map()
        {
            //Create map locations first
            Locations = new List<MapLocation>();            
            Locations.Add(new MapLocation("You are on a road leading to a town.")); //0
            Locations.Add(new MapLocation("You are on a road in front of a saloon.")); //1
            Locations.Add(new MapLocation("You are in a saloon.")); //2
            Locations.Add(new MapLocation("You are on a road in front of a jail.")); //3
            Locations.Add(new MapLocation("You are in a jail.")); //4
            Locations.Add(new MapLocation("You are on a road in front of a general store.")); //5
            Locations.Add(new MapLocation("You are in a general store.")); //6
            Locations.Add(new MapLocation("You are in front of a dilapidated old house.")); //7
            Locations.Add(new MapLocation("You are in front of an old outhouse.")); //8
            Locations.Add(new MapLocation("You are in an outhouse.")); //9
            Locations.Add(new MapLocation("You are in front of something covered in bushes.")); //10
            Locations.Add(new MapLocation("You are on the second floor of a saloon.")); //11
            Locations.Add(new MapLocation("You are in a room in the saloon filled with card tables, but there is nobody inside.")); //12
            Locations.Add(new MapLocation("You are in one of the saloon's rooms. You see a bed and a night table with a drawer")); //13
            Locations.Add(new MapLocation("You are in front of the town's horse stables. The owner is watching you suspiciously.")); //14
            Locations.Add(new MapLocation("You are at the town's well.")); //15
            Locations.Add(new MapLocation("You enter the stables to check things out.\nSuddenly, the owner and 2 burly henchmen seize you and accuse you of horse theft!\n" +
                "You are lynched by the townsfolk as a horse thief without trial.")); //16
            Locations.Add(new MapLocation("You are in the jails cellblock wing")); //17
            Locations.Add(new MapLocation("You are in the Sherriff's office.")); //18
            Locations.Add(new MapLocation("You are at a cell door. You see a prisoner inside, playing the harmonica.")); //19
            Locations.Add(new MapLocation("You are on the road out of town.... \n\nSuddenly, you come across a gang of bandits lurking by the road!")); //20
            Locations.Add(new MapLocation("You run away but the bandits are prepared. \nThey rob you for everything you own and bury your body, never to be seen again!")); //21
            Locations.Add(new MapLocation("You ride a bit back the way you came and find a trail that leads past the bandits. \nYou have made your escape and ride off into the sunset!")); //22
            Locations.Add(new MapLocation("You try ride a bit back the way you came and find a trail that leads past the bandits. \nUnfortunately, their lookout spotted you. \nThe bandits rob you for everything you own and bury your body, never to be seen again!")); //23
            Locations.Add(new MapLocation("You walk through the door of the house. \nAs you step inside, you hear an ominous creaking under your feet. The floor collapses, leaving you dead in the basement.")); //24
            Locations.Add(new MapLocation("Quit?")); //25
            Locations.Add(new MapLocation("The sheriff sees you coming out of his private office.\nHe accuses you of theft and attempted jail-break.\n" +
                "You hang in the street in front of the town.")); //26

            //Add items to MapLocations
            //Outhouse
            PortableHidingPlace Satchel = new PortableHidingPlace("Leather Satchel"); //Satchel adds + 4 to player's MaxInventory without mouse skeleton.
            InventoryItem deadMouse = new InventoryItem("Petrified mouse skeleton");
            deadMouse.Size = 1;
            Satchel.HiddenObject = deadMouse;
            Locations[9].Items.Add(Satchel);
            
            //Well
            HidingPlace Well = new HidingPlace("Old water well");
            InventoryItem coltRevolver = new InventoryItem("Colt revolver");
            coltRevolver.Size = 4;
            Well.HiddenObject = coltRevolver;
            Locations[10].Items.Add(Well);

            //Saloon poker room
            HidingPlace PokerTable = new HidingPlace("Poker Table");
            InventoryItem pChip = new InventoryItem("50 Cent Poker Chip");
            pChip.Size = 1;
            PokerTable.HiddenObject = pChip;
            HidingPlace BlackJackTable = new HidingPlace("BlackJack Table");
            InventoryItem beer = new InventoryItem("A nearly empty glass of beer");
            beer.Size = 1;
            BlackJackTable.HiddenObject = beer;
            Locations[12].Items.Add(BlackJackTable);
            Locations[12].Items.Add(PokerTable);

            //Saloon room
            HidingPlace NightStand = new HidingPlace("Night stand");
            PortableHidingPlace Bible = new PortableHidingPlace("Hardcover Bible");
            InventoryItem porn = new InventoryItem("One of those pictures of a woman...you know, like from France...");
            NightStand.HiddenObject = Bible;
            porn.Size = 1;
            Bible.HiddenObject = porn;
            Locations[13].Items.Add(NightStand);

            //Sherriff's Office
            InventoryItem money = new InventoryItem("Five dollar bill on top of the desk");
            money.Size = 1;
            InventoryItem shotGun = new InventoryItem("Double Barrell Shotgun");
            shotGun.Size = 3;
            InventoryItem rifle = new InventoryItem("Remington Rifle");
            rifle.Size = 3;
            HidingPlace desk = new HidingPlace("Office Desk");
            InventoryItem bullet = new InventoryItem("Bullet");
            bullet.Size = 1;
            desk.HiddenObject = bullet;
            Locations[18].Items.Add(desk);
            Locations[18].Items.Add(rifle);
            Locations[18].Items.Add(shotGun);
            Locations[18].Items.Add(money);

            //Town Well
            PortableHidingPlace canvasBag = new PortableHidingPlace("Tattered canvas bag"); //Players MaxInventory += 3
            InventoryItem drinkingCup = new InventoryItem("Drinking mug");
            drinkingCup.Size = 2;
            canvasBag.HiddenObject = drinkingCup;
            Locations[15].Items.Add(canvasBag);

            //Store
            InventoryItem hairTonic = new InventoryItem("Hair tonic to cure baldness");
            hairTonic.Size = 1;
            InventoryItem snakeOil = new InventoryItem("Snake oil to cure what ails ya'.");
            snakeOil.Size = 1;
            InventoryItem laudnum = new InventoryItem("Laudnum to make you feel real good!");
            laudnum.Size = 1;
            InventoryItem childsToy = new InventoryItem("A nice toy for your kids.");
            childsToy.Size = 2;
            InventoryItem sandwich = new InventoryItem("A delicious sandwich, only 3 days old! Hardly any mold.");
            sandwich.Size = 1;
            Locations[6].Items.Add(hairTonic);
            Locations[6].Items.Add(snakeOil);
            Locations[6].Items.Add(laudnum);
            Locations[6].Items.Add(childsToy);
            Locations[6].Items.Add(sandwich);

            //Now add travel options to each map location
            //Outside the abandoned house
            Locations[7].TravelOptions.Add(new TravelOption("The road to town is to the northwest.", Locations[0]));
            Locations[7].TravelOptions.Add(new TravelOption("The front door seems to be ajar.", Locations[24])); //Attenpting to enter the house will kill Player
            Locations[7].TravelOptions.Add(new TravelOption("There is an overgrown path leading to the structure you saw before to the north", Locations[10]));
            Locations[7].TravelOptions.Add(new TravelOption("There is an old outhouse to the south", Locations[8]));

            //Outside the outhouse
            Locations[8].TravelOptions.Add(new TravelOption("The road to town is to the northwest.", Locations[0]));
            Locations[8].TravelOptions.Add(new TravelOption("The house is to the north.", Locations[7]));
            Locations[8].TravelOptions.Add(new TravelOption("Go inside the outhouse.", Locations[9]));

            //Inside the outhouse
            Locations[9].TravelOptions.Add(new TravelOption("The door leads back outside.", Locations[8]));

            //At the well
            Locations[10].TravelOptions.Add(new TravelOption("The road to town is to the northwest.", Locations[0]));
            Locations[10].TravelOptions.Add(new TravelOption("The house is to the north.", Locations[7]));

            //START
            Locations[0].TravelOptions.Add(new TravelOption("Some sort of abandoned building is to the southeast of you.", Locations[7])); //House
            Locations[0].TravelOptions.Add(new TravelOption("There's a structure covered in bushes to your northeast", Locations[10])); //Well
            Locations[0].TravelOptions.Add(new TravelOption("A town is to the west of you.",Locations[1]));

            //Road in front of saloon
            Locations[1].TravelOptions.Add(new TravelOption("The road out of town is to the east of you.", Locations[0]));
            Locations[1].TravelOptions.Add(new TravelOption("You see a faded path leading to the old building outside town to your south.", Locations[7]));
            Locations[1].TravelOptions.Add(new TravelOption("A saloon is to the north of you.", Locations[2]));            
            Locations[1].TravelOptions.Add(new TravelOption("A road leading further into town is to the west of you.", Locations[3]));

            //Saloon
            Locations[2].TravelOptions.Add(new TravelOption("The saloon door leads out to the street.", Locations[1]));
            Locations[2].TravelOptions.Add(new TravelOption("You see a set of stairs going to the second floor of the saloon.", Locations[11]));
            Locations[2].TravelOptions.Add(new TravelOption("You see an open door in the saloon.", Locations[12]));

            //Saloon Poker Room
            Locations[12].TravelOptions.Add(new TravelOption("The door leads back to the saloon.", Locations[2]));
            Locations[12].TravelOptions.Add(new TravelOption("You see a smaller set of stairs going to the second floor of the saloon.", Locations[11]));

            //Saloon 2nd Floor
            Locations[11].TravelOptions.Add(new TravelOption("The small stairs lead down to the poker room.", Locations[12]));
            Locations[11].TravelOptions.Add(new TravelOption("There are doors along both walls. Only one is open", Locations[13]));
            Locations[11].TravelOptions.Add(new TravelOption("The larger stairs lead down to the saloon.", Locations[2]));

            //Open saloon room
            Locations[13].TravelOptions.Add(new TravelOption("The door lead back to the hallway", Locations[11]));

            //Road in front of jail
            Locations[3].TravelOptions.Add(new TravelOption("The road back is to the east of you.", Locations[1]));
            Locations[3].TravelOptions.Add(new TravelOption("A jail is to the north of you.", Locations[4]));
            Locations[3].TravelOptions.Add(new TravelOption("A road leading further into town is to the west of you.", Locations[5]));
            Locations[3].TravelOptions.Add(new TravelOption("To the south you see a horse stable.", Locations[14]));
            Locations[3].TravelOptions.Add(new TravelOption("Next to the stables, you see a public well.", Locations[15]));

            //Jail
            Locations[4].TravelOptions.Add(new TravelOption("The jail door leads out to the street.", Locations[3]));
            Locations[4].TravelOptions.Add(new TravelOption("An open door leads back to the cells.", Locations[17]));
            Locations[4].TravelOptions.Add(new TravelOption("The Sherriff's office door is open.", Locations[18]));

            //Cell blocks
            Locations[17].TravelOptions.Add(new TravelOption("You can go back to the jail.", Locations[4]));
            Locations[17].TravelOptions.Add(new TravelOption("You see a row of closed cell doors. Harmonica music is coming from one of the cells at the end.", Locations[19]));

            Locations[19].TravelOptions.Add(new TravelOption("You can go back the way you came.", Locations[17]));

            //Sherriff's Office
            TravelOption temp;
            Random rand = new Random();
            int RNG = rand.Next() % 2;
            if (RNG == 0) temp = new TravelOption("The office door leads back out.", Locations[4]); //Player is safe
            else temp = new TravelOption("The office door leads back out.", Locations[26]);//Player dies
            Locations[18].TravelOptions.Add(temp); //Player is safe

            //Horse Stables
            Locations[14].TravelOptions.Add(new TravelOption("You can go back to the road.", Locations[3]));
            Locations[14].TravelOptions.Add(new TravelOption("The corral is open.", Locations[16])); //Player will hang for horse theft


            //Town Well
            Locations[15].TravelOptions.Add(new TravelOption("You can go back to the road.", Locations[3]));

            //Road in front of general store
            Locations[5].TravelOptions.Add(new TravelOption("The way back is east from here.", Locations[3]));
            Locations[5].TravelOptions.Add(new TravelOption("A general store is to the north of you.", Locations[6]));
            Locations[5].TravelOptions.Add(new TravelOption("To the west is the road out of town", Locations[20]));

            //Store
            Locations[6].TravelOptions.Add(new TravelOption("The store door leads out to the street.", Locations[5]));

            //Road out of town
            RNG = rand.Next() % 2;
            if (RNG == 0) temp = new TravelOption("Try to escape back to town", Locations[5]); //Escapes and lives; in town again
            else temp = new TravelOption("Try to escape back to town", Locations[21]); //Robbed and dies
            Locations[20].TravelOptions.Add(temp);

            RNG = rand.Next() % 2;
            if (RNG == 0) temp = new TravelOption("Try to sneak past the bandits.", Locations[22]); //Escapes and lives; game over
            else temp = new TravelOption("Try to sneak past the bandits.", Locations[23]); //Robbed and dies
            Locations[20].TravelOptions.Add(temp);

            //Set the player's starting location.
            //PlayerLocation = Locations[0];
        }

    }
}
