using System;
using System.Collections.Generic;
using ChallengeFive_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeFive_Tests
{
    [TestClass]
    public class ChallengeFive_Tests
    {
        [TestMethod]
        public void AddCustomerTest()
        {
            //Arrange
            CustomerRepository _custRepo = new CustomerRepository();

            Customer custOne = new Customer("Jason", "Bourne",
                Customer.CustType.Potential);

            Customer custTwo = new Customer("Reggie", "Miller",
                Customer.CustType.Current);
            Customer custThree = new Customer("George", "Lopez",
                 Customer.CustType.Past);
            //Act
            _custRepo.AddCustomer(custOne);
            _custRepo.AddCustomer(custTwo);
            _custRepo.AddCustomer(custThree);

            //Assert
            List<Customer> _testList = _custRepo.GetDict();
            Assert.AreEqual(_testList[0], custOne);
        }
        [TestMethod]
        public void GetDict()
        {
            //Arrange
            CustomerRepository _custRepo = new CustomerRepository();

            Customer custOne = new Customer("Jason", "Bourne",
                Customer.CustType.Potential);

            Customer custTwo = new Customer("Reggie", "Miller",
                Customer.CustType.Current);
            Customer custThree = new Customer("George", "Lopez",
                 Customer.CustType.Past);
            //Act
            _custRepo.AddCustomer(custOne);
            _custRepo.AddCustomer(custTwo);
            _custRepo.AddCustomer(custThree);
            List<Customer> _testList = _custRepo.GetDict();

            //Assert
            Assert.AreEqual(_testList[2], custThree);
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
