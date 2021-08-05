using ChallengeThree_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Console
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();

        // Method that runs/starts the application
        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. View door access by badge\n" +
                    "5. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Create new badge
                        CreateNewBadge();
                        break;
                    case "2":
                        // Update Existing Badges
                        UpdateABadge();
                        break;
                    case "3":
                        // View All Badges
                        DisplayAllBadges();
                        break;
                    case "4":
                        GetDoorsByBadgeID();
                        break;
                    case "5":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            //Badge ID
            Console.WriteLine("What is the number on the badge?");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            //First Door
            List<string> doors = new List<string>();
            Console.WriteLine("List a door that it needs access to:");
            string firstDoor = Console.ReadLine();
            doors.Add(firstDoor);

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Any other doors(y/n)?");
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    Console.WriteLine("List a door that it needs access to:");
                    string anotherDoor = Console.ReadLine();
                    doors.Add(anotherDoor);
                    newBadge.DoorNames = doors;
                    _badgeRepo.AddBadgeToDictionary(newBadge);
                }
                else if (answer == "n")
                {
                    keepRunning = false;
                    Menu();
                }
                else
                {
                    Console.WriteLine("Invalid answer. Try again.");
                }
            }
            //newBadge.DoorNames = doors;
            //_badgeRepo.AddBadgeToDictionary(newBadge);
        }
        private void DisplayAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetBadgeDictionary();
            Console.Write($"{"Badge #",-15}{"Door Access"}");
            foreach (var kvp in badgeDictionary)
            {
                Console.Write($"\n{kvp.Key,-15}");
                foreach (var value in kvp.Value)
                {
                    Console.Write($"{value.TrimEnd(',')},");

                }
            }
        }
        private void UpdateABadge()
        {
            Console.WriteLine("What is the badge number to update?");
            int id = int.Parse(Console.ReadLine());

            List<string> retrievedDoors = _badgeRepo.GetDoorsByBadgeID(id);

            Console.Write($"{id} has access to doors ");
            foreach (var door in retrievedDoors)
            {
                Console.Write($"{door}, ");
            }
            Console.WriteLine("\nWhat would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    // Remove A Door From Badge
                    Console.WriteLine("Which door would you like to remove?");
                    string doorResponse = Console.ReadLine();
                    bool wasDeleted = _badgeRepo.DeleteDoorOnBadge(doorResponse, id);
                    if (wasDeleted)
                    {
                        Console.WriteLine("Door removed.");
                    }
                    else
                    {
                        Console.WriteLine("The door could not be removed.");
                    }
                    Console.Write($"{id} has access to doors ");
                    foreach (var door in retrievedDoors)
                    {
                        Console.Write($"{door}. ");
                    }
                    break;
                case "2":
                    // Add a door
                    Console.WriteLine("Enter the door you would like to add:");
                    string firstDoor = Console.ReadLine();
                    //retrievedDoors.Add(firstDoor);
                    bool wasAdded = _badgeRepo.AddDoorToDoorValueOfSpecificBadge(firstDoor, id);
                    if (wasAdded)
                    {
                        Console.WriteLine("Door added.");
                        bool keepRunning = true;
                        while (keepRunning)
                        {
                            Console.WriteLine("\nAny other doors(y/n)?");
                            string input = Console.ReadLine();
                            if (input == "y")
                            {
                                Console.WriteLine("Enter the door name:");
                                string anotherDoor = Console.ReadLine();
                                bool additionalDoorWasAdded = _badgeRepo.AddDoorToDoorValueOfSpecificBadge(anotherDoor, id);
                                if (additionalDoorWasAdded)
                                {
                                    Console.WriteLine("Door added.");
                                }
                                else
                                {
                                    Console.WriteLine("Door could not be added.");
                                }
                                Console.Write($"{id} has access to doors ");
                                foreach (var door in retrievedDoors)
                                {
                                    Console.Write($"{door}, ");
                                }

                            }
                            else if (input == "n")
                            {
                                keepRunning = false;
                                Menu();
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid answer.");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Door could not be added.");
                    }
                    Console.Write($"{id} has access to doors ");
                    foreach (var door in retrievedDoors)
                    {
                        Console.Write($"{door}, ");
                    }
                    break;
                default:
                    Console.WriteLine("Please enter a valid number.");
                    break;
            }


        }
        private void GetDoorsByBadgeID()
        {
            Console.WriteLine("What is the badge number to update?");
            int id = int.Parse(Console.ReadLine());

            List<string> retrievedDoors = _badgeRepo.GetDoorsByBadgeID(id);

            foreach (var door in retrievedDoors)
            {
                Console.Write($"{door} ");
            }
        }
        private void SeedBadgeDictionary()
        {
            //First Badge that I will add to dictionary
            Badge newBadge = new Badge();
            newBadge.BadgeID = 12345;

            List<string> newDoors = new List<string>();
            string door = "A5";
            newDoors.Add(door);
            string doorTwo = "A7";
            newDoors.Add(doorTwo);
            newBadge.DoorNames = newDoors;

            _badgeRepo.AddBadgeToDictionary(newBadge);

            //Second Badge that will be added to dictionary
            Badge secondBadge = new Badge();
            secondBadge.BadgeID = 22345;

            List<string> doorsForSecondBadge = new List<string>();
            string a1Door = "A1";
            doorsForSecondBadge.Add(a1Door);
            string a4Door = "A4";
            doorsForSecondBadge.Add(a4Door);
            string b1Door = "B1";
            doorsForSecondBadge.Add(b1Door);
            string b2Door = "B2";
            doorsForSecondBadge.Add(b2Door);

            secondBadge.DoorNames = doorsForSecondBadge;

            _badgeRepo.AddBadgeToDictionary(secondBadge);

            //Third Badge that will be added to dictionary
            Badge thirdBadge = new Badge();
            thirdBadge.BadgeID = 32345;

            List<string> doorsForThirdBadge = new List<string>();
            string doorForThirdBadge = "A4";
            doorsForThirdBadge.Add(doorForThirdBadge);
            string secondDoorForThirdBadge = "A5";
            doorsForThirdBadge.Add(secondDoorForThirdBadge);

            thirdBadge.DoorNames = doorsForThirdBadge;

            _badgeRepo.AddBadgeToDictionary(thirdBadge);





        }
    }
}
