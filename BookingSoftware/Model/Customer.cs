using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware.Model
{
    public class Customer : User
    {
        public Customer()
        {
            Name = "";
            Password = "";
            Email = "";
        }


        public Customer(string name, string password, string email, string gender)
        {
            Name = name;
            Password = password;
            Email = email;
            Gender = gender;
        }
    }
}
