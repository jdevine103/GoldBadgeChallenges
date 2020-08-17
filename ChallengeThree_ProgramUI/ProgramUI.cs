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
                    //UpdateBadge();
                    break;
                case "3":
                    //DeleteAll();
                    break;
                case "4":
                    //ShowAllBAdges();
                    break;
                case "5":
                    _isRunning = false;
                    break;
                default:
                    //handle this
                    break;
            }
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
    }
}
