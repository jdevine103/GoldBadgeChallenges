using ChallengeTwo_ProgramUI.Consoles;
using ChallengeTwo_Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using static ChallengeTwo_Repo.Claim;
//using Claim = ChallengeTwo_Repo.Claim;

namespace ChallengeTwo_ProgramUI
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly ClaimRepository _claimQueue = new ClaimRepository();
        private readonly IConsole _console;

        public ProgramUI(IConsole console)
        {
            _console = console;
        }
        public void Start()
        {
            SeedContentList();
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
            _console.Clear();
            _console.WriteLine("" +
                "Choose a menu item: \n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. Modify an existing claim\n" +
                "5. Exit");

            string userInput = _console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            _console.Clear();
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
                    ModifyClaim();
                    break;
                case "5":
                    _isRunning = false;
                    break;
                default:
                    //handle this
                    break;
            }
            _console.WriteLine("Press any key to return to the menu...");
            _console.ReadKey();
        }
        private Queue<Claim> GetDirectory()
        {
            Queue<Claim> listOfClaims = _claimQueue.GetClaimDirectory();
            return listOfClaims;
        }
        private void DisplayAllClaims()
        {
            var listOfClaims = GetDirectory();
            _console.WriteLine("ClaimID  Type    Description Amount  DateOfAccident  DateOfClaim IsValid");

            foreach (var claim in listOfClaims)
            {
                _console.WriteLine($"{claim.ClaimId}         {claim.Type}    {claim.Description}    {claim.ClaimAmount}   {claim.DateOfIncident.ToString()}   {claim.DateOfClaim.ToString()}  {claim.IsValid}");
            }
        }

        private void AddressNextClaim()
        {
            Queue<Claim> claimQueue = _claimQueue.GetClaimDirectory();

            DisplayClaim(claimQueue.Peek());

            _console.WriteLine("Would you like to deal with this clain now(y/n)?");
            string input = _console.ReadLine();

            if (input == "y")
            {
                _claimQueue.DealWithNextClaim();
            }
            else
                GetMenuSelection();
        }
        private void DisplayClaim(Claim claim)
        {
            _console.WriteLine($"" +
                $"Claim ID: {claim.ClaimId}\n" +
                $"Type: {claim.Type}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.ClaimAmount}\n" +
                $"DateOfAccident: {claim.DateOfIncident}\n" +
                $"DateOfClaim: {claim.DateOfClaim}" +
                $"IsValid: {claim.IsValid}");
        }
        private void EnterNewClaim()
        {
            _console.WriteLine("Enter the claim ID: ");
            string idInput = _console.ReadLine();
            int idInputInt = Int32.Parse(idInput);

            _console.WriteLine("Choose the claim type: ");
            ClaimType typeInput = GetClaimType();

            _console.WriteLine("Enter the claim desription: ");
            string descInput = _console.ReadLine();

            _console.WriteLine("Amount of damage: $");
            string damageInput = _console.ReadLine();
            decimal decimalDamageInput = Decimal.Parse(damageInput);

            _console.WriteLine("Date of Accident (e.g. 01/22/2020): ");
            DateTime accidentDateInput = DateTime.Parse(_console.ReadLine());

            _console.WriteLine("Date of Claim(e.g. 01/22/2020): ");
            DateTime claimDateInput = DateTime.Parse(_console.ReadLine());

            _console.WriteLine("Program will decide if claim is valid");

            Claim newClaim = new Claim(idInputInt, typeInput, descInput, decimalDamageInput, accidentDateInput, claimDateInput);

            _claimQueue.AddClaim(newClaim);
        }

        private ClaimType GetClaimType()
        {
            _console.WriteLine("Select a type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            while (true)
            {
                string typeString = _console.ReadLine();
                bool parseResult = int.TryParse(typeString, out int parsedNumber);
                if (parseResult && parsedNumber >= 1 && parsedNumber < 4)
                {
                    ClaimType claimType = (ClaimType)parsedNumber - 1;
                    return claimType;
                }
                _console.WriteLine("Invalid selection. Please try again.");
            }
        }
        private void ModifyClaim()
        {
            _console.WriteLine("Which claim would you like to modify?(enter claim id)");
            string id = _console.ReadLine();
            int idInt = Int32.Parse(id);

            Claim updating = _claimQueue.GetClaimById(idInt);

            DisplayClaim(updating);

            _console.WriteLine("What do you want to update?");
            string updateChoice = UpdateMenu();
            ModifyComponent(updateChoice, updating);
        }
        private string UpdateMenu()
        {
            _console.WriteLine("1. Claim Id\n" +
                "2. Claim Type\n" +
                "3. Claim description\n" +
                "4. Damage Amount\n" +
                "5. Date of Accident\n" +
                "6. Date of Claim\n");
            string input = _console.ReadLine();
            return input;
        }
        private void ModifyComponent(string choice, Claim claim)
        {
            _console.Clear();
            switch (choice)
            {
                case "1":
                    _console.WriteLine("Enter the modified claim ID: ");
                    string idInput = _console.ReadLine();
                    int idInputInt = Int32.Parse(idInput);
                    claim.ClaimId = idInputInt;
                    break;
                case "2":
                    _console.WriteLine("Choose the modified claim type: ");
                    ClaimType typeInput = GetClaimType();
                    claim.Type = typeInput;
                    break;
                case "3":
                    _console.WriteLine("Enter the modified claim desription: ");
                    string descInput = _console.ReadLine();
                    claim.Description = descInput;
                    break;
                case "4":
                    _console.WriteLine("modified amount of damage: $");
                    string damageInput = _console.ReadLine();
                    decimal decimalDamageInput = Decimal.Parse(damageInput);
                    claim.ClaimAmount = decimalDamageInput;
                    break;
                case "5":
                    _console.WriteLine("Modified Date of Accident (e.g. 01/22/2020): ");
                    DateTime accidentDateInput = DateTime.Parse(_console.ReadLine());
                    claim.DateOfIncident = accidentDateInput;
                    break;
                case "6":
                    _console.WriteLine("Modified Date of Claim(e.g. 01/22/2020): ");
                    DateTime claimDateInput = DateTime.Parse(_console.ReadLine());
                    claim.DateOfClaim = claimDateInput;
                    break;
                default:
                    //handle this
                    break;
            }
            _console.WriteLine("Press any key to return to the menu...");
            _console.ReadKey();
        }
        private void SeedContentList()
        {
            DateTime claim1accident = new DateTime(2020, 02, 11);
            DateTime claim1date = new DateTime(2020, 02, 13);
            DateTime claim2accident = new DateTime(2020, 02, 11);
            DateTime claim2date = new DateTime(2020, 11, 11);

            Claim carCrash = new Claim(1, ClaimType.Car, "Car Crash", 300, claim1accident, claim1date);
            Claim houseFire = new Claim(2, ClaimType.Home, "House Fire", 4500, claim2accident, claim2date);

            _claimQueue.AddClaim(carCrash);
            _claimQueue.AddClaim(houseFire);

        }
    }
}
