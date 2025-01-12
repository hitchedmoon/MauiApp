using Microsoft.Maui.Controls;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace HelpMee
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private static bool IsStringOk(string username)
        {
            if (!string.IsNullOrWhiteSpace(username)) { return true; }
            else { return false;}
        }

        private static bool IsUserNameOk(string username)
        {
            int maxLength = 16;

            if (IsStringOk(username) == true && username.Length <= maxLength) { return true; }
            else { return false; }
        }

        private static bool IsEmailOk(string email)
        {
            if (email.Contains("@") && IsStringOk(email)) { return true; }
            else { return false; }
        }

        private static bool IsPWOk(string pw)
        {
            int minLength = 12;
            int maxLength = 64;
            if (IsStringOk(pw) && pw.Length <= maxLength && pw.Length >= minLength)
            {
                bool hasLetter = Regex.IsMatch(pw, @"[a-zA-Z]");
                bool hasDigit = Regex.IsMatch(pw, @"\d");
                bool hasSC = Regex.IsMatch(pw, @"[!@#$%^&*(),.?""{}|<>~`_-]");
                return hasLetter && hasDigit && hasSC;
            }
            else { return false; }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string username = UserNameEntry.Text;
            string email = EMailEntry.Text;
            string pw1 = PasswordEntryOne.Text;
            string pw2 = PasswordEntryTwo.Text;

            if (IsUserNameOk(username) == true)
            {
                if (IsEmailOk(email) == true)
                {
                    if (IsPWOk(pw1) == true)
                    {
                        if (pw1 == pw2)
                        {
                            User newUser = new User
                            {
                                Name = username,
                                EMail = email,
                                Password = pw1
                            };

                            ((App)Application.Current).CurrentUser = newUser;
                            await Navigation.PushAsync(new SecondPage());
                        }
                        else
                        {
                            await DisplayAlert("Error", "Password dont match!", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Password is not correct!", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Email is not correct!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Username is not correct!", "OK");
            }
        }

        private void OnShowPasswordCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Wenn die Checkbox aktiviert ist, setze IsPassword auf false, sonst auf true
            PasswordEntryTwo.IsPassword = !e.Value;
        }

        private void OnShowPasswordCheckedChangedOne(object sender, CheckedChangedEventArgs e)
        {
            // Wenn die Checkbox aktiviert ist, setze IsPassword auf false, sonst auf true
            PasswordEntryOne.IsPassword = !e.Value;
        }
    }
}
