using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive_Repo 
{
    public class CustomerRepository : IComparer
    {
        private readonly List<Customer> _custDict = new List<Customer>();

        //create
        public void AddCustomer(Customer customer)
        {
            _custDict.Add(customer);
        }

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();

        }

        //read
        public List<Customer> GetDict()
        {
            return _custDict;
        }
        //update

        //delete
    }
}
