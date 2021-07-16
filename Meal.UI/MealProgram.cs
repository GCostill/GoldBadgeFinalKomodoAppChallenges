using MealClass.POCO;
using MealClass.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.UI
{
    public class MealProgram
    {
        
        
        private readonly MenuItemRepo _itemRepo = new MenuItemRepo();
        
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe App!\n" +
                    "Please select a menu option:\n" +
                    "1. Create new menu item\n" +
                    "2. Delete existing menu item\n" +
                    "3. View all menu items\n" +
                    "4. Exit Program");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DeleteExistingMenuItem();
                        break;
                    case "3":
                        ViewAllMenuItems();
                        break;
                    case "4":
                        Console.WriteLine("Have a good day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a menu option number.");
                        break;
                }
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            }
        }
        private void CreateNewMenuItem()
        {
            MenuItemPOCO newMenuItem = new MenuItemPOCO();

            Console.WriteLine("Please enter the name of the meal you'd like to add:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("What will be the meal number?");
            var newNumberAsString = Console.ReadLine();
            newMenuItem.MealNumber = ProperNumber(newNumberAsString);

            Console.WriteLine("Enter in a price for the meal:");
            var priceAsString = Console.ReadLine();
            newMenuItem.MealPrice = ProperNumber(priceAsString);

            Console.WriteLine("Enter a brief description of the meal:");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("List the ingredients in the meal, please:");
            newMenuItem.MealIngredientList = Console.ReadLine();

            _itemRepo.AddMenuItemToList(newMenuItem);
        }

        private void DeleteExistingMenuItem()
        {
            Console.Clear();
            var listOfMenuItems = _itemRepo.GetMenuItems();
            bool isEmpty = listOfMenuItems.Any();
            if (!isEmpty)
            {
                Console.WriteLine("There are currently no menu items to delete.");
                return;
            }

            Console.WriteLine("Here is a list of current menu items:\n" +
                "--------------------------------------------");
            ViewAllMenuItems();
            Console.WriteLine("What is the number of the menu item you want to delete?");

            int itemID = int.Parse(Console.ReadLine());
            MenuItemPOCO menuItem = _itemRepo.GetItemByNum(itemID);
            if(menuItem !=null)
            {
                Console.Clear();
                Console.WriteLine($"Meal Number: {menuItem.MealNumber}\n" +
                    $"Meal Name: {menuItem.MealName}\n" +
                    $"Meal Price: {menuItem.MealName}\n" +
                    $"--------------------------------\n" +
                    $"Is this the menu item you would like to delete?(y/n)");
                string userResponse = Console.ReadLine().ToLower();
                if (userResponse == "y")
                {
                    _itemRepo.DeleteMenuItem(itemID);
                    Console.WriteLine("Delete Successful.\n" +
                        "Would you like to delete another menu item?(y/n)");
                    string userInput = Console.ReadLine();
                    if(userInput == "y")
                    {
                        DeleteExistingMenuItem();
                    }
                    if(userInput == "n")
                    {
                        Console.WriteLine("You will return to the main menu\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                    }
                }
                else if (userResponse == "n")
                {
                    DeleteExistingMenuItem();
                }
                else
                {
                    //call menu item again?
                    Console.WriteLine("plese enter y or n");
                }
                
            }
        }
        private void ViewAllMenuItems()
        {
            List<MenuItemPOCO> listOfMenuItems = _itemRepo.GetMenuItems();
            if(!listOfMenuItems.Any())
            {
                Console.WriteLine("There aren't any menu items made yet");
            }
            else
            {
                foreach(MenuItemPOCO menuItem in listOfMenuItems)
                {
                    Console.WriteLine($"Meal ID: {menuItem.MealNumber}\n" +
                        $"Meal Name: {menuItem.MealName}\n" +
                        $"Meal Price: {menuItem.MealPrice}\n" +
                        $"Meal Desc: {menuItem.MealDescription}\n" +
                        $"Ingredients: {menuItem.MealIngredientList}\n" +
                        $"---------------------------------------------");
                }
            }
        }

        private decimal ProperNumber(string newNumber)
        {
            decimal newNum;
            while (!decimal.TryParse(newNumber, out newNum))
            {
                Console.WriteLine("Bah! That is not a valid number!");
            }
            Console.WriteLine($"The new meal number is: {newNum}");
            return newNum;
        }
    }
}
