using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Mission3
{
    internal class FoodItem
    {

        // These are the properties of a food item that will be stored in the foodBank
        public string foodName { get; set; }
        public string foodCategory { get; set; }
        public int foodQuantity { get; set; }
        public DateTime foodExpiration { get; set; }

        // This creates a new food item with the given parameters and stores them
        public FoodItem(string foodName, string foodCategory, int foodQuantity, DateTime foodExpiration)
        {
            // Assign the parameters to the properties of the food item
            this.foodName = foodName;
            this.foodCategory = foodCategory;
            this.foodQuantity = foodQuantity;
            this.foodExpiration = foodExpiration;

        }
        // This gets the user input for a new food item and returns a new FoodItem object
        public static FoodItem UserInput()
        {
            Console.WriteLine("\nAdd New Food Item");

            Console.Write("Food Name: ");
            string name = Console.ReadLine();

            Console.Write("Food Category: ");
            string category = Console.ReadLine();

            // Validate quantity input to ensure it's a positive integer
            int quantity = 0;
            bool validQuantity = false;
            // Loop until a valid quantity is entered by the user
            while (!validQuantity)
            {
                Console.Write("Quantity: ");
                string quantityInput = Console.ReadLine();

                // Try to parse the input as an integer and check if it's positive 
                if (int.TryParse(quantityInput, out quantity) && quantity > 0)
                {
                    validQuantity = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }

            // Validate expiration date input to ensure it's a valid date
            DateTime expirationDate = DateTime.Now;
            bool validDate = false;
            // Loop until a valid date is entered by the user
            while (!validDate)
            {
                Console.Write("Expiration Date (MM/DD/YYYY): ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out expirationDate))
                {
                    validDate = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid date in MM/DD/YYYY format.");
                }
            }

            return new FoodItem(name, category, quantity, expirationDate);
        }
        // This displays the food item information in a readable format 
        public void showItems()
        {
            string expiredStatus = foodExpiration < DateTime.Now ? " [EXPIRED]" : "";
            Console.WriteLine($"Name: {foodName}");
            Console.WriteLine($"Category: {foodCategory}");
            Console.WriteLine($"Quantity: {foodQuantity}");
            Console.WriteLine($"Expiration Date: {foodExpiration.ToShortDateString()}{expiredStatus}");
            Console.WriteLine();
        }

    }
}
