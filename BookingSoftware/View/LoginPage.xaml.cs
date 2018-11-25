using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookingSoftware.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {

        //List<string> gender;
        public LoginPage()
        {
            this.InitializeComponent();

            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }

        private new void PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ChangeButtonState();
        }

        private new void PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ChangeButtonState();
        }

        private void ChangeButtonState()
        {
            if (SignUpEmailBox.Text != string.Empty && SignUpPasswordBox.Password != string.Empty && SignUpPasswordConfirmBox.Password != string.Empty &&  NameBox.Text != string.Empty)
            {
                if (SignUpPasswordConfirmBox.Password == SignUpPasswordBox.Password)
                {
                    SignUpBtn.Opacity = 100;
                    SignUpBtn.IsEnabled = true;
                }
                else
                {
                    SignUpBtn.Opacity = 0;
                    SignUpBtn.IsEnabled = false;
                }
            }
            else
            {
                SignUpBtn.Opacity = 0;
                SignUpBtn.IsEnabled = false;
            }
        }
    }
}
