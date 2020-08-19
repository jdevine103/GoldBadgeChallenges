using ChallengeFive_ProgramUI.Consoles;
using ChallengeFive_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChallengeFive_Repo.Customer;

namespace ChallengeFive_ProgramUI
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly IConsole _console;
        private readonly CustomerRepository _custRepo = new CustomerRepository();
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
            _console.WriteLine(
                            "Welcome to the email greeting program\n" +
                            "Select Menu Item:\n" +
                            "1. Add Customer\n" +
                            "2. Display all customers\n" +
                            "3. Update customer\n" +
                            "4. Delete Customer\n" +
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
                    AddCustomer();
                    break;
                case "2":
                    DisplayCustomers();
                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "5":

                    _isRunning = false;
                    return;
                default:

                    return;
            }
            _console.WriteLine("Press any key to return to the menu...");
            _console.ReadKey();
        }

        private void AddCustomer()
        {
            _console.WriteLine("Enter Customer First Name: ");
            string firstName = _console.ReadLine();
            _console.WriteLine("Enter Customer Last Name: ");
            string lastName = _console.ReadLine();

            _console.WriteLine("What is the customer type? ");
            CustType type = GetCustType();

            Customer newCust = new Customer(firstName, lastName, type);

            _custRepo.AddCustomer(newCust);
        }
        private CustType GetCustType()
        {
            _console.WriteLine("Select a type:\n" +
                "1. Potential\n2. Current\n3. Past");
            while (true)
            {
                string typeString = _console.ReadLine();
                bool parseResult = int.TryParse(typeString, out int parsedNumber);
                if (parseResult && parsedNumber >= 1 && parsedNumber < 4)
                {
                    CustType type = (CustType)parsedNumber - 1;
                    return type;
                }
            }

        }

        private void DisplayCustomers()
        {
            List<Customer> listOfCust = _custRepo.GetDict();
            _console.WriteLine("FirstName\tLastName\tType\t\tEmail");
            foreach (var cust in listOfCust)
            {
                DisplaySingle(cust);
            }
        }
        private void DisplaySingle(Customer cust)
        {
            _console.WriteLine($"{cust.FirstName}\t\t{cust.LastName}\t\t{cust.Type.ToString()}\t\t{cust.Email}");
        }

        private void SeedContentList()
        {
            Customer custOne = new Customer("Jason", "Bourne",
                Customer.CustType.Potential);

            Customer custTwo = new Customer("Reggie", "Miller",
                Customer.CustType.Current);
            Customer custThree = new Customer("George", "Lopez",
                 Customer.CustType.Past);

            _custRepo.AddCustomer(custOne);
            _custRepo.AddCustomer(custTwo);
            _custRepo.AddCustomer(custThree);

        }
    }
}
