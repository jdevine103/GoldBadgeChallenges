using System;
using System.Collections.Generic;
using ChallengeFour_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeFour_Tests
{
    [TestClass]
    public class ChallengeFour_Tests
    {
        [TestMethod]
        public void AddOutingsTest()
        {
            //Arrange
            OutingsRepo _outingRepo = new OutingsRepo();    

            DateTime golfDate = new DateTime(2020, 05, 20);
            DateTime bowlingDate = new DateTime(2020, 04, 21);
            DateTime amusementDate = new DateTime(2020, 04, 22);
            DateTime concertDate = new DateTime(2020, 02, 23);

            Outing golf = new Outing(Outing.EventType.Golf, 25, golfDate);
            Outing bowling = new Outing(Outing.EventType.Bowling, 50, bowlingDate);
            Outing amusement = new Outing(Outing.EventType.AmusementPark, 20, amusementDate);
            Outing concert = new Outing(Outing.EventType.Concert, 75, concertDate);

            //Act
            _outingRepo.AddOuting(golf);
            _outingRepo.AddOuting(bowling);
            _outingRepo.AddOuting(amusement);
            _outingRepo.AddOuting(concert);

            List<Outing> _testRepo = _outingRepo.GetOutings();

            //Assert
            Assert.AreEqual(_testRepo[0], golf);

        }        
        
        [TestMethod]
        public void GetOutingsTest()
        {
            //Arrange
            OutingsRepo _outingRepo = new OutingsRepo();

            DateTime golfDate = new DateTime(2020, 05, 20);
            DateTime bowlingDate = new DateTime(2020, 04, 21);
            DateTime amusementDate = new DateTime(2020, 04, 22);
            DateTime concertDate = new DateTime(2020, 02, 23);

            Outing golf = new Outing(Outing.EventType.Golf, 25, golfDate);
            Outing bowling = new Outing(Outing.EventType.Bowling, 50, bowlingDate);
            Outing amusement = new Outing(Outing.EventType.AmusementPark, 20, amusementDate);
            Outing concert = new Outing(Outing.EventType.Concert, 75, concertDate);

            _outingRepo.AddOuting(golf);
            _outingRepo.AddOuting(bowling);
            _outingRepo.AddOuting(amusement);
            _outingRepo.AddOuting(concert);

            //Act
            List<Outing> _testRepo = _outingRepo.GetOutings();

            //Assert
            Assert.AreEqual(_testRepo[1], bowling);
        }

    }
}
