using ChallengeThree_ProgramUI.Consoles;
using ChallengeThree_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChallengeThree_ProgramUI
{
    public class ProgramUI
    {
        //constructors
        public ProgramUI(IConsole console)
        {
            _console = console;
        }
        //fields
        private bool _isRunning = true;
        private readonly IConsole _console;
        //repo
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Start()
        {
            SeedContent();
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
            _console.WriteLine(
                "Welcome to Badge Management!\n" +
                "Select a Menu Item:\n" +
                "1. Create a new badge\n" +
                "2. Update doors on existing badge\n" +
                "3. Delete all doors form existing badge\n" +
                "4. Show list of all badge numbers and door access\n" +
                "5. Exit");
            string userInput = _console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    CreateNewBadge();
                    break;
                case "2":
                    UpdateBadge();
                    break;
                case "3":
                    DeleteAll();
                    break;
                case "4":
                    ShowAllBadges();
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

        private void CreateNewBadge()
        {
            //get ID
            _console.WriteLine("What is the number on the badge: ");
            string badgeNum = _console.ReadLine();
            int badgeNumInt = Int32.Parse(badgeNum);
            //get Doors
            List<string> accessList = new List<string>();
            bool moreDoors = true;
            while (moreDoors)
            {
                _console.WriteLine("List a door that it needs access to: ");
                string newDoor = _console.ReadLine();
                accessList.Add(newDoor);
                _console.WriteLine("Any other doors(y/n)?");
                string anotherDoor = _console.ReadLine();
                if (anotherDoor == "n")
                    moreDoors = false;
            }

            Badge newBadge = new Badge(badgeNumInt, accessList);

            _badgeRepo.AddNewBadgeToDict(newBadge);
        }
        private void UpdateBadge()
        {
            _console.WriteLine("What is the badge number to update?");
            string id = _console.ReadLine();
            int idInt = Int32.Parse(id);

            Badge updating = _badgeRepo.GetBadgeById(idInt);

            HasAccessTo(updating);

            _console.WriteLine("What would you like to do?\n" +
                "\t 1. Remove a door\n" +
                "\t 2. Add a door");
            string input = _console.ReadLine();

            if (input == "1")
            {
                _console.WriteLine("Which door would you like to remove?");
                string removeThis = _console.ReadLine();
                _badgeRepo.RemoveDoor(updating, removeThis);
                HasAccessTo(updating);
            }
            else if (input == "2")
            {
                _console.WriteLine("Which door would you like to add?");
                string addThis = _console.ReadLine();
                _badgeRepo.AddDoor(updating, addThis);
                HasAccessTo(updating);
            }


        }
        private void DeleteAll()
        {
            _console.WriteLine("What is the badge number do you want to delete all access?");
            string id = _console.ReadLine();
            int idInt = Int32.Parse(id);

            _badgeRepo.DeleteAllDoors(idInt);
        }
        private void ShowAllBadges()
        {
            Dictionary<int, Badge> repo = _badgeRepo.GetDict();
            _console.WriteLine(String.Format("{0,-10}{1,-10}", "Badge#", "Door Access"));

            foreach (var badge in repo)
            {
                DisplayBadge(badge.Value);
            }
        }
        private void DisplayBadge(Badge badge)
        {
            string combindedString = string.Join(",", badge.Doors);
            _console.WriteLine(String.Format("{0,-10}{1,-10}", badge.ID, combindedString)); ;
        }
        private void HasAccessTo(Badge badge)
        {
            _console.Write($"{badge.ID} has access to door(s) ");
            foreach (var door in badge.Doors)
            {
                _console.Write(door + ", ");
            }
            _console.WriteLine("");
        }
        private void SeedContent()
        {
            List<string> testListOne = new List<string>() { "a1", "a2" };
            List<string> testListTwo = new List<string>() { "b1", "b2" };

            Badge testBadgeOne = new Badge(1, testListOne);
            Badge testBadgeTwo = new Badge(2, testListTwo);

            _badgeRepo.AddNewBadgeToDict(testBadgeOne);
            _badgeRepo.AddNewBadgeToDict(testBadgeTwo);
        }
    }
}
