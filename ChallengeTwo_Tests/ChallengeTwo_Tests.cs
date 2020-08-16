using System;
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
            _repo = new ClaimRepository();
            DateTime incidentDateOne = new DateTime(2020, 11, 02);
            DateTime claimDateOne = new DateTime(2020, 11, 03);

            _claim = new Claim(1, 0, "Crash on 465", 500, incidentDateOne, claimDateOne);
        }
        [TestMethod]
        public void DisplayAllClaimRepo()
        {
            ClaimRepository repo = new ClaimRepository();
            repo.AddClaim(_claim);


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
