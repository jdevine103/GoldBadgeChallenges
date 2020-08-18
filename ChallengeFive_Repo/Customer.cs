using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive_Repo
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public CustType Type { get; set; }
        public enum CustType
        {
            Potential, Current, Past
        } 
    }
}
