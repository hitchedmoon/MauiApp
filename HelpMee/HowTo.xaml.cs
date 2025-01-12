using Microsoft.Maui.Controls;

namespace HelpMee
{
    public partial class HowTo : ContentPage
    {
        public HowTo()
        {
            InitializeComponent();
        }

        private async void R1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }

        private async void AccessAccount(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountPage());
        }

        // Toggle visibility for "How to add a new Movie"
        private void ToggleMovieDetails(object sender, EventArgs e)
        {
            var isVisible = MovieDetails.IsVisible;
            MovieDetails.IsVisible = !isVisible;
        }

        // Toggle visibility for "How to access account Information"
        private void ToggleAccountDetails(object sender, EventArgs e)
        {
            var isVisible = AccountDetails.IsVisible;
            AccountDetails.IsVisible = !isVisible;
        }
    }
}
