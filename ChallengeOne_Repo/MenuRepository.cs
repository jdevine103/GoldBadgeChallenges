using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repo
{
    public class MenuRepository
    {
        private readonly List<Menu> _menu = new List<Menu>();

        //Create 
        public void AddMenuItem(Menu item)
        {
            _menu.Add(item);
        }

        //Read
        public List<Menu> GetMenu()
        {
            return _menu;
        }

        public Menu GetMenuItemByName(string mealName)
        {
            for (int i = 0; i < _menu.Count; i++)
            {
                if (_menu[i].MealName.ToLower() == mealName.ToLower())
                {
                    return _menu[i];
                }
            }
            return null;
        }

        //Update 
        //

        //Delete
        public bool DeleteMenuItem(Menu item)
        {
            _menu.Remove(item);
            return true;
        }

        public bool DeleteMenuItemByName(string itemName)
        {
            Menu targetItem = GetMenuItemByName(itemName);
            if (targetItem != null)
            {
                DeleteMenuItem(targetItem);
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
