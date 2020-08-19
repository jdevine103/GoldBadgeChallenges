using System;
using System.Collections.Generic;
using ChallengeThree_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThree_Tests
{
    [TestClass]
    public class ChallengeThree_Tests
    {
        [TestMethod]
        public void GetDictTest()
        {
            //Arrange 
            BadgeRepo _testRepo = new BadgeRepo();

            List<string> testListOne = new List<string>() { "a1", "a2" };
            List<string> testListTwo = new List<string>() { "b1", "b2" };

            Badge testBadgeOne = new Badge(1, testListOne);
            Badge testBadgeTwo = new Badge(2, testListTwo);

            _testRepo.AddNewBadgeToDict(testBadgeOne);
            _testRepo.AddNewBadgeToDict(testBadgeTwo);

            //Act
            Dictionary<int, Badge> _testDict = _testRepo.GetDict();

            //Assert
            Assert.AreEqual(_testDict[1], testBadgeOne);
        }
        [TestMethod]
        public void AddBadgeTest()
        {
            //Arrange 
            BadgeRepo _testRepo = new BadgeRepo();

            List<string> testListOne = new List<string>() { "a1", "a2" };
            List<string> testListTwo = new List<string>() { "b1", "b2" };

            Badge testBadgeOne = new Badge(1, testListOne);
            Badge testBadgeTwo = new Badge(2, testListTwo);

            //Act
            _testRepo.AddNewBadgeToDict(testBadgeOne);
            _testRepo.AddNewBadgeToDict(testBadgeTwo);
            Dictionary<int, Badge> _testDict = _testRepo.GetDict();

            //Assert
            Assert.AreEqual(_testDict[2], testBadgeTwo);
        }
        [TestMethod]
        public void GetBadgeByIdTests()
        {
            //Arrange 
            BadgeRepo _testRepo = new BadgeRepo();

            List<string> testListOne = new List<string>() { "a1", "a2" };
            List<string> testListTwo = new List<string>() { "b1", "b2" };

            Badge testBadgeOne = new Badge(1, testListOne);
            Badge testBadgeTwo = new Badge(2, testListTwo);

            _testRepo.AddNewBadgeToDict(testBadgeOne);
            _testRepo.AddNewBadgeToDict(testBadgeTwo);

            //Act
            Badge testBadge =_testRepo.GetBadgeById(1);

            //Assert
            Assert.AreEqual(testBadge, testBadgeOne);
        }
        [TestMethod]
        public void RemoveDoorTest()
        {
            //Arrange 
            BadgeRepo _testRepo = new BadgeRepo();

            List<string> testListOne = new List<string>() { "a1", "a2" };
            List<string> testListTwo = new List<string>() { "b1", "b2" };

            Badge testBadgeOne = new Badge(1, testListOne);
            Badge testBadgeTwo = new Badge(2, testListTwo);

            _testRepo.AddNewBadgeToDict(testBadgeOne);
            _testRepo.AddNewBadgeToDict(testBadgeTwo);

            //Act
            _testRepo.RemoveDoor(testBadgeOne, "a2");

            //List<string> listAfterRemove = new List<string>() { "a1" };

            //Assert
            Assert.IsFalse(testBadgeOne.Doors.Contains("a2"));
        }
        [TestMethod]
        public void AddDoorTest()
        {
            //Arrange 
            BadgeRepo _testRepo = new BadgeRepo();

            List<string> testListOne = new List<string>() { "a1", "a2" };
            List<string> testListTwo = new List<string>() { "b1", "b2" };

            Badge testBadgeOne = new Badge(1, testListOne);
            Badge testBadgeTwo = new Badge(2, testListTwo);

            _testRepo.AddNewBadgeToDict(testBadgeOne);
            _testRepo.AddNewBadgeToDict(testBadgeTwo);

            //Act
            _testRepo.AddDoor(testBadgeOne, "a3");

            //List<string> listAfterAdd = new List<string>() { "a1","a2","a3" };


            //Assert
            //Assert.AreEqual(listAfterAdd, testBadgeOne.Doors);
            Assert.IsTrue(testBadgeOne.Doors.Contains("a3"));
        }
        [TestMethod]
        public void DeleteAllDoorsTest()
        {
            //Arrange 
            BadgeRepo _testRepo = new BadgeRepo();

            List<string> testListOne = new List<string>() { "a1", "a2" };
            List<string> testListTwo = new List<string>() { "b1", "b2" };

            Badge testBadgeOne = new Badge(1, testListOne);
            Badge testBadgeTwo = new Badge(2, testListTwo);

            _testRepo.AddNewBadgeToDict(testBadgeOne);
            _testRepo.AddNewBadgeToDict(testBadgeTwo);

            //Act
            _testRepo.DeleteAllDoors(1);

            List<string> listAfterDeleteAll = new List<string>() {};


            //Assert
            Assert.IsTrue(testBadgeOne.Doors.Count == 0);
        }

    }
}
