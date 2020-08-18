using ChallengeFour_ProgramUI.Consoles;
using ChallengeFour_Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_ProgramUI
{
    class ProgramUI
    {
        private bool _isRunning = true;
        private readonly IConsole _console;
        private readonly OutingsRepo _outingRepo = new OutingsRepo();

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
            _console.WriteLine("Welcome to the Outings menu.\n" +
                "Choose an option:\n" +
                "1. Display all outings\n" +
                "2. Add an outing\n" +
                "3. See total cost for all outings\n" +
                "4. See total cost for outings by type\n" +
                "5. Exit");
            string input = _console.ReadLine();
            return input;
        }
        private void OpenMenuItem(string userInput)
        {
            _console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllOutings();
                    break;
                case "2":
                    //AddOuting();
                    break;
                case "3":
                    //SeeTotalForAllOutings();
                    break;
                case "4":
                    //SeeTotalByType();
                    break;
                case "5":
                    _isRunning = false;
                    return;
                default:
                       //handle this 
                    return;
            }
            _console.WriteLine("Press any key to return to the menu...");
            _console.ReadKey();
        }

        private void DisplayAllOutings()
        {
            List<Outing> outingList = _outingRepo.GetOutings();

            foreach (var outing in outingList)
            {
                DisplayOuting(outing);
            }
        }
        private void DisplayOuting(Outing outing)
        {
            _console.WriteLine($"{outing.Type.ToString()} outing of {outing.Attendance} people, on {outing.Date} ");
        }

        private void SeedContentList()
        {
            DateTime golfDate = new DateTime(2020, 05, 20);
            DateTime bowlingDate = new DateTime(2020, 04, 21);
            DateTime amusementDate = new DateTime(2020, 04, 22);
            DateTime concertDate = new DateTime(2020, 02, 23);

            Outing golf = new Outing(Outing.EventType.Golf, 25, golfDate);
            Outing bowling = new Outing(Outing.EventType.Bowling, 50, bowlingDate);
            Outing amusement = new Outing(Outing.EventType.AmusementPark, 20, amusementDate);
            Outing concert = new Outing(Outing.EventType.Concert, 75, concertDate);

            _outingRepo.AddOuting(golf);
            _outingRepo.AddOuting(bowling);
            _outingRepo.AddOuting(amusement);
            _outingRepo.AddOuting(concert);
        }
    }
}
