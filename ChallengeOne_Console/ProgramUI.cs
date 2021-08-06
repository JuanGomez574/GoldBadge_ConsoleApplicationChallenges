
using ChallengeOne_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Console
{
    class ProgramUI
    {
        private MenuItemRepository _menuItemRepo = new MenuItemRepository();
        public void Run()
        {
            SeedMenuItemsToList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select an option:\n" +
                    "1. Create New Cafe Menu Item\n" +
                    "2. View All Items In Cafe Menu\n" +
                    "3. Delete Existing Cafe Menu Item\n" +
                    "4. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        CreateNewItem();
                        break;
                    case "2":
                        DisplayAllItems();
                        break;
                    case "3":
                        DeleteExistingItem();
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // Create new menu item
        private void CreateNewItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();
            //Meal Number
            Console.WriteLine("Enter the meal number for the menu item:");
            newItem.Number = int.Parse(Console.ReadLine());
            //Meal Name
            Console.WriteLine("Enter the name of the meal:");
            newItem.Name = Console.ReadLine();
            //Description
            Console.WriteLine("Enter the description for menu item:");
            newItem.Description = Console.ReadLine();
            //List of ingredients
            List<string> ingredients = new List<string>();

            bool keepRunning2 = true;
            while (keepRunning2)
            {   //Display 2 options to the user
                Console.WriteLine("Select option below to enter ingredients (one at a time):\n" +
                    "1. Enter ingredient.\n" +
                    "2. Done entering ingredients.");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter an ingredient for the menu item:");
                        string ingredient = Console.ReadLine();
                        ingredients.Add(ingredient);
                        newItem.Ingredients = ingredients;
                        break;
                    case "2":
                        Console.WriteLine("Finished entering ingredients.");
                        keepRunning2 = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

            }
            //Price
            Console.WriteLine("Enter the price of the menu item:");
            newItem.Price = decimal.Parse(Console.ReadLine());

            _menuItemRepo.AddItemToList(newItem);

        }
        // View Current Menu Items
        private void DisplayAllItems()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _menuItemRepo.GetItemList();

            foreach (MenuItem item in listOfMenuItems)
            {
                Console.WriteLine($"\nMeal Number: {item.Number}\n" +
                    $"Meal Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredient List: ");
                foreach (var ingredient in item.Ingredients)
                {
                    Console.WriteLine(ingredient);
                }
                Console.WriteLine($"Price: ${item.Price}");

            }
        }
        // Delete Item From Menu
        private void DeleteExistingItem()
        {
            DisplayAllItems();

            // Get the menu item they want to remove
            Console.WriteLine("\nEnter the meal number of the menu item you'd like to remove:");

            int input = int.Parse(Console.ReadLine());

            // Call the delete method
            bool wasDeleted = _menuItemRepo.RemoveItemFromList(input);

            // If the content was deleted, say so
            // Otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully removed from the menu.");
            }
            else
            {
                Console.WriteLine("The item could not be removed from the menu.");
            }
        }
        //Seed method
        private void SeedMenuItemsToList()
        {
            // Building the first MenuItem object
            List<string> sandwichIngredients = new List<string>();
            string ingredient = "2 Whole Wheat Breads";
            string secondIngredient = "Cheese";
            string thirdIngredient = "Ham";
            string fourthIngredient = "Lettuce";
            sandwichIngredients.Add(ingredient);
            sandwichIngredients.Add(secondIngredient);
            sandwichIngredients.Add(thirdIngredient);
            sandwichIngredients.Add(fourthIngredient);
            MenuItem sandwich = new MenuItem(1, "Ham Sandwich", "Our award winning low calorie sandwich", sandwichIngredients, 2.99m);
            _menuItemRepo.AddItemToList(sandwich);
            // Building the second MenuItem object
            List<string> soupIngredients = new List<string>();
            string soupIngredient = "Chicken";
            string soupSecondIngredient = "Water";
            string soupThirdIngredient = "Vegetables";
            string soupFourthIngredient = "Butter";
            string soupFifthIngredient = "Rice";
            string soupSixthIngredient = "Spices";
            soupIngredients.Add(soupIngredient);
            soupIngredients.Add(soupSecondIngredient);
            soupIngredients.Add(soupThirdIngredient);
            soupIngredients.Add(soupFourthIngredient);
            soupIngredients.Add(soupFifthIngredient);
            soupIngredients.Add(soupSixthIngredient);
            MenuItem soup = new MenuItem(2, "Chicken Soup", "A hearty soup served with top quality ingredients", soupIngredients, 4.99m);
            _menuItemRepo.AddItemToList(soup);
        }
    }

}
