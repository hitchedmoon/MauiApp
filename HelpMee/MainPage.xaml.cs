using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace HelpMee
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLogInClicked(object sender, EventArgs e)
        {
            string email = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {    // only for testing
                if (email == "test" && password == "test")
                {
                    User newUser = new User
                    {
                        Name = "test",
                        EMail = email,
                        Password = password,
                    };

                    ((App)Application.Current).CurrentUser = newUser;
                    await Navigation.PushAsync(new SecondPage());
                }
                else
                {
                    await DisplayAlert("Error", $"This User doesnt exist!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please enter a username and password.", "OK");
            }
        }

        private async void OnRegisterPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private void OnShowPasswordCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            PasswordEntry.IsPassword = !e.Value;
        }

        private async void OnLinkTapped(object sender, EventArgs e)
        {
            string url = "https://www.google.com";
            if (await Launcher.CanOpenAsync(url))
            {
                await Launcher.OpenAsync(url);
            }
            else
            {
                await DisplayAlert("Error", "Unable to open the link check internet connection.", "OK");
            }
        }


    }

}
