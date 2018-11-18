using Prism.Windows.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookingSoftware.Model
{
    /// <summary>
    /// Base user class with shared properties
    /// </summary>
    public class User : ValidatableBindableBase, IUser
    {
        private string _userType { get; set; }
        private string _name;
        private string _password { get; set; }
        private string _email { get; set; }
        private string _gender { get; set; }
        private int _phoneNumber { get; set; }
        private string _address { get; set; }

        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        [Required(ErrorMessage = "Please fill out all fields")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
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
    }
}
