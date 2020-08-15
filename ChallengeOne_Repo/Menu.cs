using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repo
{
    //poco
    public class Menu
    {
        //constructors
        public Menu() { }
        public Menu(int mealNumber, string mealName, List<string> ingredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Ingredients = ingredients;
            Price = price;
        }

        //properties
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDesc
        {
            get
            {
                //set MealDesc to the list of ingredients
                string mealDesc = $"{MealName} consists of "; 
                foreach (var ingredient in Ingredients)
                {
                    mealDesc = mealDesc + ingredient + ", ";
                }

                return mealDesc;
            }
        }

        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}
