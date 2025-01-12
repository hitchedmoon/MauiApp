using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace HelpMee
{
    public partial class AddMovie : ContentPage
    {
        public event Action<Film>? MovieAdded;

        public AddMovie()
        {
            InitializeComponent();
        }

        private async void SaveMovieClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MovieTitleEntry.Text) || string.IsNullOrWhiteSpace(MovieDescriptionEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            if (MovieStatusPicker.SelectedItem == null)
            {
                await DisplayAlert("Error", "Please select a movie status.", "OK");
                return;
            }

            var newFilm = new Film
            {
                Title = MovieTitleEntry.Text,
                Description = MovieDescriptionEntry.Text,
                Status = MovieStatusPicker.SelectedItem?.ToString(),
                IsAdult = IsAdultCheckBox.IsChecked,
                Rating = (int)(MovieRatingSlider?.Value ?? 0)
            };

            Debug.WriteLine($"Film added: {newFilm.Title}, {newFilm.Description}, {newFilm.Status}");


            MovieAdded?.Invoke(newFilm);
            await Navigation.PopAsync();
        }
        private async void BackToMain(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }
        private async void BackToHomePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }
    }
}