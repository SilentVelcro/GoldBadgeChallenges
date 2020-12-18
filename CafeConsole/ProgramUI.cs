using CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsole
{
    class ProgramUI
    {
        private Cafe_Repo _cafeRepo = new Cafe_Repo();

        public void Run()
        {
            SeeContentList();
            ProgramMenu();
        }

        //Menu
        private void ProgramMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. View List of All Menu Items.\n" +
                    "2. Update New Menu Items.\n" +
                    "3. Delete New Menu Items\n" +
                    "4. Add New Menu Items\n" +
                    "5. Exit Program.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllMenuItems();
                        break;
                    case "2":
                        UpdateNewMenuItems();
                        break;
                    case "3":
                        RemoveItemFromList();
                        break;
                    case "4":
                        CreateNewMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
           
          
        }

        //1 - Display
        private void DisplayAllMenuItems()
        {
            Console.Clear();

            List<Cafe> menuList = _cafeRepo.GetMenuList();

            foreach (Cafe item in menuList)
            {
                Console.WriteLine($"Meal Number:{item.MealNumber}\n" +
                    $"Item Name: {item.MealName}\n" +
                    $"Description:{item.Description}\n" +
                    $"Ingredients:{item.Ingredinets}\n" +
                    $"Price:{item.Price}");
            }
        }

        //2 - Update
        public void UpdateNewMenuItems()
        {
            DisplayAllMenuItems();

            Console.WriteLine();

            //call
            Console.WriteLine("Enter the number of the menu item you wish to update:");
                int menuId = int.Parse(Console.ReadLine());

            //save
            Cafe updateMenuItem = new Cafe();

            Console.WriteLine("Enter the updated menu item number:");
                string itemNumber = Console.ReadLine();
                updateMenuItem.MealNumber = int.Parse(itemNumber);

            Console.WriteLine("Enter the updated menu item name:");
                updateMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the updated menu item description:");
                updateMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the updated menu item's ingredients :");
                updateMenuItem.Ingredinets = Console.ReadLine();

            Console.WriteLine("Enter the updated menu item's price:");
                string itemPrice = Console.ReadLine();
                updateMenuItem.Price = double.Parse(itemPrice);

            bool wasUpdated = _cafeRepo.UpdateExisitingMenuItem(menuId, updateMenuItem);
            if (wasUpdated)
            {
                Console.WriteLine("Item successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Item.");
            }
        }

        //3 - Delete
        public void RemoveItemFromList()
        {
            Console.Clear();
            DisplayAllMenuItems();
            //get item
            Console.WriteLine("Enter the item number that you would like remove from the menu:");
            int mealNumber = int.Parse(Console.ReadLine());

            //call delete method
            bool wasDeleted = _cafeRepo.RemoveItemFromList(mealNumber);

            //was it deleted?
            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted");
            }
            else
            {
                Console.WriteLine("The content could not be deleted");
            }
        }

        //4 - Create
        public void CreateNewMenuItem()
        {
            DisplayAllMenuItems();

            Console.WriteLine();

            Cafe newMenuItem = new Cafe();

            Console.WriteLine("Enter the menu item number:");
            string itemNumber = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(itemNumber);

            Console.WriteLine("Enter the updated menu item name:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the updated menu item description:");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the updated menu item's ingredients :");
            newMenuItem.Ingredinets = Console.ReadLine();

            Console.WriteLine("Enter the updated menu item's price:");
            string itemPrice = Console.ReadLine();
            newMenuItem.Price = double.Parse(itemPrice);

           _cafeRepo.AddNewMenuItems(newMenuItem);
        }

        // - see method
        private void SeeContentList()
        {
            Cafe smartSalad = new Cafe(1,"Smart Salad", "Fresh mixed salad with tomatoes, soy bacon, and cheese.", "Romaine Lettus, Spinanch, Tomatoes, Soy Bacon, Chesse.", 7.00);
            _cafeRepo.AddNewMenuItems(smartSalad);

            Cafe miniNachos = new Cafe(2,"Mini Nachos", "Corn Tortilla Chips Covered with Melted Cheese and Goodness", "Corn Tortilla Chips, Cheese, Jalapeños, Red Chile Sauce, Green Onion, Pico de Gallo, Guacamole, Black Beans.", 8.75);
            _cafeRepo.AddNewMenuItems(miniNachos);

            Cafe radicalRoastBeef = new Cafe(3,"Radical Roast Beef", "Roast Beef Sandwich", "Beef, Onion, leaf Lettus, Horseradish Mayo, Sourdough Bread", 9.50);
            _cafeRepo.AddNewMenuItems(radicalRoastBeef);

            Cafe fourCheesePizza = new Cafe(4, "Four Cheese Pizza", "It is what it is a 24 inch Cheese Pizza", "Mozzarella, Parmesan, Romano, Fontina Cheeses,Tomato Sauce, Pizza Dough", 13.50);
            _cafeRepo.AddNewMenuItems(fourCheesePizza);

        }
    }
}
