using ChallengeTwo_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ChallengeTwo_Repo.Claim;
using Claim = ChallengeTwo_Repo.Claim;

namespace ChallengeTwo_ProgramUI
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly ClaimRepository _claimQueue = new ClaimRepository();
        public void Start()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("" +
                "Choose a menu item: \n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. Modify an existing claim\n" +
                "5. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    AddressNextClaim();
                    break;
                case "3":
                    EnterNewClaim();
                    break;
                case "4":
                    //ModifyClaim();
                    break;
                case "5":
                    _isRunning = false;
                    break;
                default:
                    //handle this
                    break;
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        private void DisplayAllClaims()
        {
            Queue<Claim> listOfClaims = _claimQueue.GetClaimDirectory();

            Console.WriteLine("ClaimID  Type    Description Amount  DateOfAccident  DateOfClaim IsValid");

            foreach (var claim in listOfClaims)
            {
                Console.WriteLine($"{claim.ClaimId}         {claim.Type}        {claim.ClaimAmount}   {claim.DateOfIncident.Date}   {claim.DateOfClaim.Date}  {claim.IsValid}");
            }
        }

        private void AddressNextClaim()
        {
            Queue<Claim> claimQueue = _claimQueue.GetClaimDirectory();

            DisplayClaim(claimQueue.Peek());

            Console.WriteLine("Would you like to deal with this clain now(y/n)?");
            string input = Console.ReadLine();

            if (input == "y")
            {
                _claimQueue.DealWithNextClaim();
            }
            else
                GetMenuSelection();
        }
        public void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"" +
                $"Claim ID: {claim.ClaimId}\n" +
                $"Type: {claim.Type}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.ClaimAmount}\n" +
                $"DateOfAccident: {claim.DateOfIncident}\n" +
                $"DateOfClaim: {claim.DateOfClaim}" +
                $"IsValid: {claim.IsValid}");
        }
        public void EnterNewClaim()
        {
            Console.WriteLine("Enter the claim ID: ");
            string idInput = Console.ReadLine();
            int idInputInt = Int32.Parse(idInput);

            Console.WriteLine("Choose the claim type: ");
            ClaimType typeInput = GetClaimType();

            Console.WriteLine("Enter the claim desription: ");
            string descInput = Console.ReadLine();

            Console.WriteLine("Amount of damage: $");
            string damageInput = Console.ReadLine();
            decimal decimalDamageInput = Decimal.Parse(damageInput);

            Console.WriteLine("Date of Accident (e.g. 01/22/2020): ");
            DateTime accidentDateInput = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Date of Claim(e.g. 01/22/2020): ");
            DateTime claimDateInput = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Program will decide if claim is valid");

            Claim newClaim = new Claim(idInputInt, typeInput, descInput, decimalDamageInput, accidentDateInput, claimDateInput);

            _claimQueue.AddClaim(newClaim);
        }

        public ClaimType GetClaimType()
        {
            Console.WriteLine("Select a type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            while (true)
            {
                string typeString = Console.ReadLine();
                bool parseResult = int.TryParse(typeString, out int parsedNumber);
                if (parseResult && parsedNumber >= 1 && parsedNumber < 3)
                {
                    ClaimType claimType = (ClaimType)parsedNumber - 1;
                    return claimType;
                }
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }
}
