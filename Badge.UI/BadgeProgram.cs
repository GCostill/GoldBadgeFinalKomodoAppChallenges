using BadgeClass.POCO;
using BadgeClass.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI
{
    class BadgeProgram
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        private readonly List<string> doorAccessList = new List<string>();
        private readonly BadgePOCO newBadge = new BadgePOCO();
        public void Run()
        {
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin! What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. View list of all badges\n" +
                    "4. Exit program");
                string userInput = Console.ReadLine();
                switch (userInput) {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        EditExistingBadge();
                        break;
                    case "3":
                        DisplayAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Have a good day! Press any key to continue...");
                        Console.ReadKey();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
            }
        }
        private void CreateNewBadge()
        {
            Console.WriteLine("What is the number on the badge you would like to add?");
            newBadge.BadgeID = ProperNumber(Console.ReadLine());

            AddDoorAccess();

            _badgeRepo.CreateNewBadge(newBadge);

            Console.WriteLine("");
            //BadgePOCO newBadge = new BadgePOCO(newBadgeID, new List<string> { newDoorAccess,});
        }
        private void EditExistingBadge()
        {

        }
        private void DisplayAllBadges()
        {

        }
        private void AddDoorAccess()
        {
            Console.WriteLine("List a door that the badge will have access to:");
            string doorAccess = Console.ReadLine();
            newBadge.DoorList.Add(doorAccess);

            Console.WriteLine("Are there any other doors?(y/n)");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                AddDoorAccess();
            }
            else if (userInput == "n")
            {
                Console.WriteLine("Returning to main menu. Press any key to continue..");
                Console.ReadKey();
                Menu();
            }
            else
            {
                Console.WriteLine("Please input 'y' or 'n'");
            }
        }
        private int ProperNumber(string checkNum)
        {
            int newNum;
                if(!int.TryParse(checkNum, out newNum))
            {
                Console.WriteLine("Please enter in a valid number.");
            }
            return newNum;
        }
    }
}
