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
        public Customer(string firstName, string lastName, CustType type)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email
        {
            get
            {
                if (Type == CustType.Current)
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                else if (Type == CustType.Past)
                    return "It's been a long time since we've heard from you, we want you back";
                else if (Type == CustType.Potential)
                    return "We currently have the lowest rates on Helicopter Insurance!";
                else
                    return null;
            }
        }
        public CustType Type { get; set; }
        public enum CustType
        {
            Potential, Current, Past
        }
    }
}
