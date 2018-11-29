using BookingSoftware.Model;
using BookingSoftware.Model.Utlity;
using BookingSoftware.Persistency;
using BookingSoftware.View;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Input;

namespace BookingSoftware.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private IUser _user;

        public IUser User
        {
            get { return _user; }
            set { _user = value; }
        }
        

        //View commands
        public RelayCommand LogIn { get; set; }
        public RelayCommand ShowResetPassword { get; set; }
        public RelayCommand ShowCreateAccount { get; set; }
        
        //Create account view commands
        public RelayCommand CreateAccount { get; set; }
        
        
        public LoginViewModel()
        {
            LogIn = new RelayCommand(DoLogin);
            CreateAccount = new RelayCommand(DoCreateAccount);
            ShowResetPassword = new RelayCommand(ShowResetAccountView);

            _user = new Customer();
        }
        
        public void DoLogin(object s)
        {
            //TODO: Implement persistency method "CheckUserCredentials(string email, string password)

            //bool loginCorrect = CheckUserCredentials(string email, string password);
            //if (loginCorrect == true && _userType == "superAdmin") {
            //    FrameNavigation.ActivateFrameNavigation(typeof(SuperAdminLandingPage));
            //}
            //else if (loginCorrect == true && _userType == "salesUser")
            //{
            //    FrameNavigation.ActivateFrameNavigation(typeof(SalesLandingPage));
            //}
            //else if (loginCorrect == true && _userType == "customerUser")
            //{
            //    FrameNavigation.ActivateFrameNavigation(typeof(CustomerLandingPage));
            //}
            //else
            //{
            //    //TODO: Display an error in view
            //}
        }


        public void DoCreateAccount(object s)
        {
            //1. Check if e-mail not taken already - Persistency
            //2. Perform input validation - Model
            //3. Notify View of validation results
            //4. Pass model to Singleton
            //5. Persistency layer creates permanent record
        }


        public void ShowLoginView(object s)
        {
            FrameNavigation.ActivateFrameNavigation(typeof(LoginPage));
        }


        public void ShowResetAccountView(object s)
        {
            FrameNavigation.ActivateFrameNavigation(typeof(ForgetPasswordPage));
        }

        public void ShowCustomerLandingPageView(object s)
        {
            FrameNavigation.ActivateFrameNavigation(typeof(CustomerLandingPage));
        }
    }
}
