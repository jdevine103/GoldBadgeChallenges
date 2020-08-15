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
        [TestClass]
        public class MenuRepoTests
        {
            private MenuRepository _repo;
            private Menu _item;
            private Menu _itemTwo;
            private List<string> _ingredients = new List<string>();
            private List<string> _ingredientsTwo = new List<string>();


            [TestInitialize]
            public void Arrange()
            {
                _ingredients.Add("cheese");
                _ingredients.Add("pattie");
                _ingredients.Add("bun");
                _repo = new MenuRepository();
                _item = new Menu(1, "Burger", _ingredients, 10);

                _ingredientsTwo.Add("cheddar");
                _ingredientsTwo.Add("tomato");
                _ingredientsTwo.Add("bread");
                _itemTwo = new Menu(2, "Sandwhich", _ingredientsTwo, 20);


                _repo.AddMenuItem(_item);

            }

            [TestMethod]
            public void ShowContentTest()
            {
                //Act
                List<Menu> directory = _repo.GetMenu();
                bool directoryHasItem = _repo.GetMenuItemByName(_item.MealName) == _item;

                //Assert
                Assert.IsTrue(directoryHasItem);


            }
            [TestMethod]
            public void AddContentTest()
            {
                //Act

                List<Menu> directory = _repo.GetMenu();
                directory.Add(_itemTwo);

                bool directoryHasItemAfterAdd = _repo.GetMenuItemByName(_itemTwo.MealName) == _itemTwo;

                //Assert
                Assert.IsTrue(directoryHasItemAfterAdd);
            }

            [TestMethod]
            public void DeleteContentTest()
            {
                //Act
                bool removeResult = _repo.DeleteMenuItem(_item);

                //Assert
                Assert.IsTrue(removeResult);
            }
        }
    }
}
