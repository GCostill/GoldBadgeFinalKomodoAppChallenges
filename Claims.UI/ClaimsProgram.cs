using ClaimsClass.POCO;
using ClaimsClass.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.UI
{
    class ClaimsProgram
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Claims App! \n" +
                    "Please enter a menu option:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit program");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        ViewNextClaimInQueue();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for visiting!");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void DisplayAllClaims()
        {
            List<ClaimsPOCO> listOfClaims = _claimsRepo.DisplayAllClaims();
            if (!listOfClaims.Any())
            {
                Console.WriteLine("Phew! There are no claims to take care of.");
            }
            else
            {
                foreach(ClaimsPOCO claim in listOfClaims)
                {
                    Console.WriteLine($"");
                }
            }
        }
        private void ViewNextClaimInQueue()
        {
            Console.WriteLine();
        }
        private void CreateNewClaim()
        {
            Console.WriteLine();
        }
    }
}
