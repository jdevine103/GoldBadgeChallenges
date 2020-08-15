using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repo
{
    public class Menu
    {
        //constructors
        public Menu() { }
        public Menu (int mealNumber, string mealName, string mealDesc, List<string> ingredients, decimal price) 
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDesc = mealDesc;
            Ingredients = ingredients;
            Price = price;
        }

        //properties
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDesc { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}
