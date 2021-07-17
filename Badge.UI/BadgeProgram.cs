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
        //private readonly List<string> doorAccessList = new List<string>();
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
                switch (userInput) 
                {
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
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewBadge()
        {
            BadgeClass.POCO.Badge newBadge = new BadgeClass.POCO.Badge();
            Console.WriteLine("What is the number of the badge you would like to add?");
            newBadge.BadgeID = ProperNumber(Console.ReadLine());

            newBadge.DoorList = AddDoorAccess(newBadge);

            _badgeRepo.CreateNewBadge(newBadge);
        }
        private void EditExistingBadge()
        {
            var listOfBadges = _badgeRepo.ShowListOfBadgesAndDoorAccess();
            bool isEmpty = listOfBadges.Any();
            if (!isEmpty)
            {
                Console.WriteLine("There are currently no badges to be edited");
                return;
                //^this works like a break for loops
            }
            Console.WriteLine("What is the badge number to be updated?");
            var badgeID = ProperNumber(Console.ReadLine());
            BadgeClass.POCO.Badge badgeUpdate = _badgeRepo.GetBadgeByID(badgeID);
            
            Console.WriteLine($"{badgeUpdate.BadgeID} has access to door(s) {badgeUpdate.DoorList}\n" +
                $"What would you like to do?\n" +
                $"1. Remove a door\n" +
                $"2. Add a door/" +
                $"3. Delete all doors");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    var doorDeleteInput = Console.ReadLine();
                    if (badgeUpdate.DoorList.Contains(doorDeleteInput))
                    {
                        badgeUpdate.DoorList.Remove(doorDeleteInput);
                        bool isSuccessful = _badgeRepo.UpdateExistingBadge(badgeID, badgeUpdate);
                        if (isSuccessful)
                        {
                            Console.WriteLine("Door has been successfully removed\n" +
                                $"{badgeUpdate.BadgeID} currently has access to door(s) {badgeUpdate.DoorList}");
                        }
                        else
                        {
                            Console.WriteLine("Door has NOT been successfully removed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please input a valid door that is listed on the badge.");
                    }
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Which door would you like to add?");
                    var doorAddInput = Console.ReadLine();
                    if (badgeUpdate.DoorList.Contains(doorAddInput))
                    {
                        Console.WriteLine("The badge already has access to this door.");
                    }
                    else
                    {
                        badgeUpdate.DoorList.Add(doorAddInput);
                        bool isSuccessful = _badgeRepo.UpdateExistingBadge(badgeID, badgeUpdate);
                        if (isSuccessful)
                        {
                            Console.WriteLine("Door has been successfully added\n" +
                                $"{badgeUpdate.BadgeID} currently has access to door(s) {badgeUpdate.DoorList}");
                        }
                        else
                        {
                            Console.WriteLine("Door has NOT been successfully added");
                        }
                    }
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Are you sure you want to delete all doors?(y/n)");
                    var userDeleteAllInput = Console.ReadLine().ToLower();
                    if(userDeleteAllInput == "y")
                    {
                        badgeUpdate.DoorList.Clear();
                    }
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    Console.Clear();
                    break;
            }

        }
        private void DisplayAllBadges()
        {
            var listOfBadges = _badgeRepo.ShowListOfBadgesAndDoorAccess();
            if (!listOfBadges.Any())
            {
                Console.WriteLine("There are currently no badges");
            }
            else
            {
                foreach(var badge in listOfBadges)
                {
                    DisplaySingleBadge(badge.Value);
                }
            }
        }
        private void DisplaySingleBadge(BadgeClass.POCO.Badge badgeSingle)
        {
            Console.WriteLine($"Badge ID:");
            Console.WriteLine($"{badgeSingle.BadgeID}\n");
            Console.WriteLine("DoorAccess:");
            DisplayDoors(badgeSingle.DoorList);
        }
        private void DisplayDoors(List<string> badgeDoors)
        {
            foreach(string door in badgeDoors)
            {
                Console.WriteLine($"{door}");
                //return badgeDoors.DoorList;
            }
            Console.WriteLine("-----------------------------");
        }
        private List<string> AddDoorAccess(BadgeClass.POCO.Badge newBadge)
        {
            Console.WriteLine("List a door that the badge will have access to:");
            string doorAccess = Console.ReadLine();
            newBadge.DoorList.Add(doorAccess);

            Console.WriteLine("Are there any other doors?(y/n)");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                AddDoorAccess(newBadge);
            }
            else if (userInput == "n")
            {
                Console.WriteLine("Returning to main menu. Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Please input 'y' or 'n'");
            }
            return newBadge.DoorList;
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
