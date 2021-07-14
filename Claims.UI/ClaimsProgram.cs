using ClaimsClass.POCO;
using ClaimsClass.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                        keepRunning = false;
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
            Queue<ClaimsPOCO> queueOfClaims = _claimsRepo.DisplayAllClaims();
            if (!queueOfClaims.Any())
            {
                Console.WriteLine("Phew! There are no claims to take care of.");
            }
            else
            {
                foreach(ClaimsPOCO claim in queueOfClaims)
                {
                    Console.WriteLine("Current queue of claims:");
                    foreach (ClaimsPOCO claims in _claimsRepo.DisplayAllClaims())
                    {
                        DisplaySingleClaim(claims);
                    }
                }
            }
        }
        private void DisplaySingleClaim(ClaimsPOCO claimSingle)
        {
            Console.WriteLine($"{"Claim ID", -15}{"Type of Claim", -15}{"Description", -15}{"Amount", -15}{"Accident Date", -15}{"Claim Date", -15}{"IsValid"}");
            Console.WriteLine($"{claimSingle.ClaimID, -15}{claimSingle.ClaimType, -15}{claimSingle.ClaimDescription, -15}{claimSingle.ClaimAmount, -15}{claimSingle.DateOfIncident.ToString("d"), -15}{claimSingle.DateOfClaim.ToString("d"), -15}{claimSingle.IsClaimValid}");
        }
        private void ViewNextClaimInQueue()
        {
            DisplaySingleClaim(_claimsRepo.ViewNextClaim());
            Console.WriteLine("-----------------------------------------------------\n" +
                "Do you want to deal with this claim now? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            if(userInput == "y")
            {
                _claimsRepo.RemoveClaimFromQueue();
                //call current claim
            }
            else if(userInput == "n")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Please enter either 'y' or 'n'");
            }
        }
        private void CreateNewClaim()
        {

            Console.WriteLine("PLease input the type of claim you want to create\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int userInputClaimType = int.Parse(Console.ReadLine());
                ClaimType newClaimType = (ClaimType)userInputClaimType;

            Console.WriteLine("Now enter the claim ID:");
            string newClaimID = Console.ReadLine();

            Console.WriteLine("Please enter a description for your new claim:");
            string newDescription = Console.ReadLine();

            Console.WriteLine("What is the amount of the claim?");
            var newAmount = ProperNumber(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Enter the month the incident occured:");
            var incidentMonth = ProperNumber(Console.ReadLine());

            Console.WriteLine("Enter the day of the incident:");
            var incidentDay = ProperNumber(Console.ReadLine());

            Console.WriteLine("Enter the year of the incident:");
            var incidentYear = ProperNumber(Console.ReadLine());

            DateTime newClaimIncidentDate = new DateTime(incidentYear, incidentMonth, incidentDay );
            DateTime incidentDateOnly = newClaimIncidentDate.Date;
            Console.Clear();

            Console.WriteLine("Enter the month the claim was submitted:");
            var claimMonth = ProperNumber(Console.ReadLine());

            Console.WriteLine("Enter the day the claim was submitted:");
            var claimDay = ProperNumber(Console.ReadLine());

            Console.WriteLine("Enter the year the claim was submitted:");
            var claimYear = ProperNumber(Console.ReadLine());

            DateTime newClaimSubmitDate = new DateTime(claimYear, claimMonth, claimDay);
            DateTime submitDateOnly = newClaimSubmitDate.Date;
            Console.Clear();

            Console.WriteLine("Is the claim valid? (y/n)");
            bool isValid = false;
            string newIsClaimValid = Console.ReadLine().ToLower();
            if(newIsClaimValid == "y")
            {
                isValid = true;
            }
            else if(newIsClaimValid =="n")
            {
                isValid = false;
            }
            else
            {
                Console.WriteLine("Please input either 'y' or 'n'");
            }

            ClaimsPOCO newClaim = new ClaimsPOCO(newClaimID, newClaimType, newDescription, newAmount, incidentDateOnly, submitDateOnly, isValid) ;
            _claimsRepo.CreateNewClaim(newClaim);
            Console.Clear();
            DisplaySingleClaim(newClaim);
        }
        private int ProperNumber(string newNumber)
        {
            int newNum;
            while (!int.TryParse(newNumber, out newNum))
            {
                Console.WriteLine("Bah! That is not a valid number!");
            }
            return newNum;
        }
    }
}
