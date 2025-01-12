using Microsoft.Maui.Controls;
using Windows.Devices.AllJoyn;

namespace HelpMee
{
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();

            // Abrufen des Benutzers aus der App-Klasse
            var currentUser = ((App)Application.Current).CurrentUser;

            if (currentUser != null)
            {
                WelcomeLabel.Text = $"Welcome, {currentUser.Name}!";
                EmailLabel.Text = $"Email: {currentUser.EMail}";
                PasswordLabel.Text = $"Password: {new string('*', currentUser.Password.Length)}"; // Passwort wird standardmäßig versteckt
            }
        }

        private async void ReturnMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }

        private async void GoToInfoPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }

        private void OnShowPasswordCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var currentUser = ((App)Application.Current).CurrentUser;

            if (currentUser != null)
            {
                if (e.Value)
                {
                    // Passwort anzeigen
                    PasswordLabel.Text = $"Password: {currentUser.Password}";
                }
                else
                {
                    // Passwort verstecken
                    PasswordLabel.Text = $"Password: {new string('*', currentUser.Password.Length)}";
                }
            }
        }
    }
}
