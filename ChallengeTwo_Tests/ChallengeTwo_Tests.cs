using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using ChallengeTwo_ProgramUI;
using ChallengeTwo_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwo_Tests
{
    [TestClass]
    public class ChallengeTwo_Tests
    {
        private ClaimRepository _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            //console added
            var commandList = new List<string>() { "3", "1", "1", "car crash", "5000", "01/22/2020", "01/23/2020" };
            var console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //_repo = new ClaimRepository();
            //DateTime incidentDateOne = new DateTime(2020, 11, 02);
            //DateTime claimDateOne = new DateTime(2020, 11, 03);
            //_claim = new Claim(1, 0, "Crash on 465", 500, incidentDateOne, claimDateOne);
        }
        [TestMethod]
        public void DisplayAllClaimRepo()
        {
            var commandList = new List<string>() { "3", "1", "1", "car crash", "5000", "01/22/2020", "01/23/2020","10 ","1"};
            var console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            program.Start();
            Console.WriteLine(console.Output);

            Assert.IsTrue(console.Output.Contains("car crash"));
        }
        [TestMethod]
        public void AddressNextClaimAndDequeue()
        {

        }
        [TestMethod]
        public void NewClaim()
        {

        }

    }
}
