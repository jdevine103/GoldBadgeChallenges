using System;
using System.Collections.Generic;
using System.Net;
using System.Security.AccessControl;
using ChallengeOne_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOne_Tests
{
    [TestClass]
    public class ChallengeOneTests
    {
        [TestMethod]
        public void AddMenuItemTest()
        {
            //Arrange
            MenuRepository _menuRepo = new MenuRepository();

            List<string> ingredientsList = new List<string>();
            List<string> ingredientsListTwo = new List<string>();

            ingredientsList.Add("Cheese");
            ingredientsList.Add("Pattie");
            ingredientsList.Add("Bun");

            ingredientsListTwo.Add("Cheddar");
            ingredientsListTwo.Add("Tomato");
            ingredientsListTwo.Add("Bread");

            //Act
            Menu _item = new Menu(1, "Burger", ingredientsList, 10);
            Menu _itemTwo = new Menu(2, "Sandwhich", ingredientsListTwo, 20);
            _menuRepo.AddMenuItem(_item);
            _menuRepo.AddMenuItem(_itemTwo);
            List<Menu> _menu = _menuRepo.GetMenu();

            //Assert
            Assert.AreEqual(_menu[0], _item);

        }
        [TestMethod]
        public void GetMenuTest()
        {
            //Arrange
            MenuRepository _menuRepo = new MenuRepository();

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

            //Act
            _menuRepo.AddMenuItem(_item);
            _menuRepo.AddMenuItem(_itemTwo);
            List<Menu> _menu = _menuRepo.GetMenu();

            //Assert
            Assert.AreEqual(_menu[1], _itemTwo);
        }

        [TestMethod]
        public void GetItemByNameTest()
        {

        }        
        [TestMethod]
        public void DeleteMenuItemTest()
        {

        }
    }
}

