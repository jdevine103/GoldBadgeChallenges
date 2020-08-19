using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using ChallengeTwo_ProgramUI;
using ChallengeTwo_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ChallengeTwo_Repo.Claim;

namespace ChallengeTwo_Tests
{
    [TestClass]
    public class ChallengeTwo_Tests
    {
        [TestMethod]
        public void AddClaimTest()
        {
            //Arrange
            ClaimRepository _testRepo = new ClaimRepository();

            DateTime claim1accident = new DateTime(2020, 02, 11);
            DateTime claim1date = new DateTime(2020, 02, 13);
            DateTime claim2accident = new DateTime(2020, 02, 11);
            DateTime claim2date = new DateTime(2020, 11, 11);

            Claim carCrash = new Claim(1, ClaimType.Car, "Car Crash", 300, claim1accident, claim1date);
            Claim houseFire = new Claim(2, ClaimType.Home, "House Fire", 4500, claim2accident, claim2date);

            //Act
            _testRepo.AddClaim(carCrash);
            _testRepo.AddClaim(houseFire);

            //Assert
            //probably should use other method in repo to test
            Queue<Claim> retrieveQueue = _testRepo.GetClaimDirectory();
            Assert.AreEqual(carCrash, retrieveQueue.Dequeue());
        }
        [TestMethod]
        public void GetDirectoryTest()
        {
            //Arrange
            ClaimRepository _testRepo = new ClaimRepository();

            DateTime claim1accident = new DateTime(2020, 02, 11);
            DateTime claim1date = new DateTime(2020, 02, 13);
            DateTime claim2accident = new DateTime(2020, 02, 11);
            DateTime claim2date = new DateTime(2020, 11, 11);

            Claim carCrash = new Claim(1, ClaimType.Car, "Car Crash", 300, claim1accident, claim1date);
            Claim houseFire = new Claim(2, ClaimType.Home, "House Fire", 4500, claim2accident, claim2date);

            //Act
            _testRepo.AddClaim(carCrash);
            _testRepo.AddClaim(houseFire);

            //Assert
            //probably should use other method in repo to test
            Queue<Claim> retrieveQueue = _testRepo.GetClaimDirectory();
            Assert.AreEqual(carCrash, retrieveQueue.Dequeue());
        }
        [TestMethod]
        public void DequeueClaimTest()
        {
            //Arrange
            ClaimRepository _testRepo = new ClaimRepository();

            DateTime claim1accident = new DateTime(2020, 02, 11);
            DateTime claim1date = new DateTime(2020, 02, 13);
            DateTime claim2accident = new DateTime(2020, 02, 11);
            DateTime claim2date = new DateTime(2020, 11, 11);

            Claim carCrash = new Claim(1, ClaimType.Car, "Car Crash", 300, claim1accident, claim1date);
            Claim houseFire = new Claim(2, ClaimType.Home, "House Fire", 4500, claim2accident, claim2date);

            //Act
            _testRepo.AddClaim(carCrash);
            _testRepo.AddClaim(houseFire);
            _testRepo.DealWithNextClaim();

            //Assert
            Queue<Claim> retrieveQueue = _testRepo.GetClaimDirectory();
            Assert.AreEqual(houseFire, retrieveQueue.Dequeue());
        }
        [TestMethod]
        public void GetClaimByIDTest()
        {
            //Arrange
            ClaimRepository _testRepo = new ClaimRepository();

            DateTime claim1accident = new DateTime(2020, 02, 11);
            DateTime claim1date = new DateTime(2020, 02, 13);
            DateTime claim2accident = new DateTime(2020, 02, 11);
            DateTime claim2date = new DateTime(2020, 11, 11);

            Claim carCrash = new Claim(1, ClaimType.Car, "Car Crash", 300, claim1accident, claim1date);
            Claim houseFire = new Claim(2, ClaimType.Home, "House Fire", 4500, claim2accident, claim2date);

            //Act
            _testRepo.AddClaim(carCrash);
            _testRepo.AddClaim(houseFire);
            Claim testClaim = _testRepo.GetClaimById(1);
            //Assert
            //probably should use other method in repo to test

            Assert.AreEqual(testClaim, carCrash);
        }

    }
}
