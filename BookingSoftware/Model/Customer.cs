using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware.Model
{
    public class Customer : ICustomer
    {
        private string _name { get; set; }
        private string _password { get; set; }
        private string _email { get; set; }
        private string _gender { get; set; }
        private int _phoneNumber { get; set; }
        private string _address { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public Customer(string name, string password, string email, string gender, int phoneNumber, string address)
        {
            _name = name;
            _password = password;
            _email = email;
            _gender = gender;
            _phoneNumber = phoneNumber;
            _address = address; 
        }
    }
}
