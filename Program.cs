using System;
using System.Collections.Generic;

namespace Mission3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store all food items
            List<FoodItem> foodBank = new List<FoodItem>();

            // This is our true/flase statement for the user inputs
            bool userAnswer = true;

            // while loop that keeps the events going until the user exits the program
            while (userAnswer)
            {
                // Options the user can make 
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Items");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit the Program");
                Console.Write("\nEnter your choice (1-4): ");

                // this gets the user input so it can be used for the options
                string userChoice = Console.ReadLine();

                // takes the user input and based on the number they input it'll run one of the events
                switch (userChoice)
                {
                    case "1":
                        AddFoodItem(foodBank);
                        break;
                    case "2":
                        DeleteFoodItem(foodBank);
                        break;
                    case "3":
                        inventoryList(foodBank);
                        break;
                    case "4":
                        userAnswer = false;
                        Console.WriteLine("\nThank you, Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please choose a number between 1 and 4.");
                        break;
                }
            }
        }

        // This adds a new food item to our foodBank
        static void AddFoodItem(List<FoodItem> foodBank)
        {
            // holds the users input to be added to the foodBank
            FoodItem newItem = FoodItem.UserInput();
            foodBank.Add(newItem);
            Console.WriteLine("Item has been added!");
            Console.WriteLine();
        }

        // THis deletes an item from our foodBank
        static void DeleteFoodItem(List<FoodItem> foodBank)
        {
            // Shows that there aren't any items in the inventory 
            //if (foodBank.Count == 0)
            //{
            //    Console.WriteLine("\nThe inventory is empty. There are no items to delete.");
            //    return;
            //}
            Console.WriteLine("\nDelete Food Item:");
            Console.WriteLine("\nCurrent Inventory:");

            // Display all the food items with their experation dates
            for (int i = 0; i < foodBank.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Food Name");
                Console.WriteLine($"{i + 1}. {foodBank[i].foodName}");
            }

            // Gets the users choice and deletes item accordingly
            Console.Write("\nEnter the number of the item to delete (or 0 to cancel): ");
            string input = Console.ReadLine();

            // if the user enters 0 the delete item method will cancel and they can return 
            if (int.TryParse(input, out int itemNumber))
            {
                if (itemNumber == 0)
                {
                    Console.WriteLine("Delete operation cancelled.");
                    return;
                }
                else if (itemNumber > 0 && itemNumber <= foodBank.Count)
                {
                    string deletedItemName = foodBank[itemNumber - 1].foodName;
                    foodBank.RemoveAt(itemNumber - 1);
                    Console.WriteLine($"\n✓ '{deletedItemName}' has been removed from inventory.");
                }
                else
                {
                    Console.WriteLine($"\nInvalid selection. Please enter a number between 1 and {foodBank.Count}.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number.");
            }
        }

        // This prints the list of all the items in the inventory
        static void inventoryList(List<FoodItem> foodBank)
        {
            Console.WriteLine("Food Bank Inventory: ");

            // if foodBank is empty display this text
            if (foodBank.Count == 0)
            {
                Console.WriteLine("\nThe inventory is currently empty.");
                return;
            }

            for (int i = 0; i < foodBank.Count; i++)
            {
                Console.WriteLine($"Item #{i + 1}:");
                foodBank[i].showItems();
            }
        }
    }
}