using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSoftware.Model;

namespace BookingSoftware.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged, ICustomer
    {
        public event PropertyChangedEventHandler PropertyChanged;
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

        public void DoLogin(string email, string password)
        {
            //TODO: Implement persistency method "CheckUserCredentials(string email, string password)
        }

        public void DoRegister()
        {
            //TODO: Find out how to switch to a new view and it's viewmodel while disposing of LoginView and LoginViewModel
        }

        public void DoReset()
        {
            //TODO: Same as DoRegister()
        }
    }
}
