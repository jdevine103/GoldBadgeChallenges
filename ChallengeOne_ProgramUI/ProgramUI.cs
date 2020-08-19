using ChallengeOne_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_ProgramUI
{
    class ProgramUI
    {
        private bool _isRunning = true;
        private readonly MenuRepository _menuRepo = new MenuRepository();

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
            Console.Clear();
            Console.WriteLine(
                "Welcome to the managers Menu program" +
                "\n Select what you would like to do: " +
                "\n 1.) Show all Menu Items" +
                "\n 2.) Create new meal and add it to the Menu" +
                "\n 3.) Delete Item from menu" + //add selector by all menu item names
                "\n 4.) Exit"
                );
            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayMenu();
                    break;
                case "2":
                    CreateNewItem();
                    break;
                case "3":
                    DeleteItem();
                    break;
                case "4":
                    _isRunning = false;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        private void DisplayMenu()
        {
            List<Menu> listOfMenu = _menuRepo.GetMenu();

            foreach (Menu item in listOfMenu)
            {
                DisplayItem(item);
            }
        }
        private void DisplayItem(Menu item)
        {
            Console.WriteLine(
                $"Meal number: {item.MealNumber}\n" +
                $"Meal name: {item.MealName}\n" +
                $"Meal Description: {item.MealDesc}\n" +
                $"Price: {item.Price}\n");
        }

        private void CreateNewItem()
        {
            Console.WriteLine("Enter Meal Number: ");
            string number = Console.ReadLine();
            int numberInteger = Int32.Parse(number);

            Console.WriteLine("Enter Meal Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Add Ingredients... ");
            List<string> ingredients = CreateIngredientList();

            Console.WriteLine("Enter Meal Price: ");
            string price = Console.ReadLine();
            decimal priceDecimal = Decimal.Parse(price);

            Menu newItem = new Menu(numberInteger, name, ingredients, priceDecimal);
            _menuRepo.AddMenuItem(newItem);
        }

        private List<string> CreateIngredientList()
        {
            List<string> ingredients = new List<string>();
            bool done = false;

            while (!done)
            {
                Console.WriteLine("If there are no more ingredients to add, enter 0 to be done.");
                Console.WriteLine("Enter an ingredient to add to the meal: ");
                string newIngredient = Console.ReadLine();
                if (newIngredient != "0")
                    ingredients.Add(newIngredient);
                else
                    done = true;
            }

            return ingredients;

        }

        private void DeleteItem()
        {
            DisplayMenu();
            Console.WriteLine("\nEnter the meal name you wish to delete: ");
            string input = Console.ReadLine();
            _menuRepo.DeleteMenuItemByName(input);


        }


        private void SeedContentList()
        {
            List<string> ingredientsList = new List<string>();
            List<string> ingredientsListTwo = new List<string>();

            ingredientsList.Add("Cheese");
            ingredientsList.Add("Pattie");
            ingredientsList.Add("Bun");
            Menu _item = new Menu(1, "Burger", ingredientsList, 10);

            ingredientsListTwo.Add("Cheddar");
            ingredientsListTwo.Add("Tomato");
            ingredientsListTwo.Add("Bread");
            Menu _itemTwo = new Menu(2, "Sandwhich", ingredientsListTwo, 20);


            _menuRepo.AddMenuItem(_item);
            _menuRepo.AddMenuItem(_itemTwo);
            
        }
    }
}
