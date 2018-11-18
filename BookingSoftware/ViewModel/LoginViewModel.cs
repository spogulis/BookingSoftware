using BookingSoftware.Model;
using BookingSoftware.Model.Utlity;
using BookingSoftware.View;

namespace BookingSoftware.ViewModel
{
    public class LoginViewModel : BaseViewModel, ICustomer
    {
        private string _name { get; set; }
        private string _password { get; set; }
        private string _email { get; set; }
        private string _gender { get; set; }
        private int _phoneNumber { get; set; }
        private string _address { get; set; }
        
        //View commands
        public RelayCommand LogIn { get; set; }
        public RelayCommand ShowResetPassword { get; set; }
        public RelayCommand ShowCreateAccount { get; set; }

        //Source properties
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
            }
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

        
        public LoginViewModel()
        {
            LogIn = new RelayCommand(DoLogin);
            ShowCreateAccount = new RelayCommand(ShowCreateAccountView);
            ShowResetPassword = new RelayCommand(ShowResetAccountView);
        }
        
        public void DoLogin(object s)
        {
            //TODO: Implement persistency method "CheckUserCredentials(string email, string password)

            //bool loginCorrect = CheckUserCredentials(string email, string password);
            //if (loginCorrect == true)
            //{
            //    //TODO: Find out how to switch to new view + viewmodel and dispose of old ones
            //}
            //else
            //{
            //    //TODO: Display an error in view
            //}
            FrameNavigation.ActivateFrameNavigation(typeof(TestCustomerPage));

        }

        public void ShowCreateAccountView(object s)
        {
            //TODO: Find out how to switch to a new view
            //CurrentView = new CreateAccountView();
        }

        public void ShowResetAccountView(object s)
        {
            //TODO: Same as DoCreateAccount()
        }
    }
}
