using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;

namespace HelpMee
{
    public partial class SecondPage : ContentPage
    {
        public ObservableCollection<Film> Films { get; set; }
        public ObservableCollection<Film> SearchResults { get; set; } // For search results

        public SecondPage()
        {
            InitializeComponent();

            Films = new ObservableCollection<Film>();
            SearchResults = new ObservableCollection<Film>(); // Initialize search results

            FilmListView.ItemsSource = Films;
            SearchResultsView.ItemsSource = SearchResults;
        }

        private async void AccountClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountPage());
        }

        private async void AddMovieClicked(object sender, EventArgs e)
        {
            var addMoviePage = new AddMovie();
            addMoviePage.MovieAdded += (newFilm) =>
            {
                Films.Add(newFilm);
                Debug.WriteLine($"Film hinzugefügt: {newFilm.Title}, Bewertung: {newFilm.Rating}/10");
            };
            await Navigation.PushAsync(addMoviePage);
        }

        private async void HowToClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HowTo());
        }

        private void SearchButtonClicked(object sender, EventArgs e)
        {
            string searchInput = SearchEntry.Text.ToLower();

            if (string.IsNullOrEmpty(searchInput))
            {
                DisplayAlert("Error", "Please enter a movie title to search.", "OK");
                return;
            }

            // Filter films based on search input
            var filteredFilms = Films.Where(f => f.Title.ToLower().Contains(searchInput)).ToList();

            // Update SearchResults ObservableCollection
            SearchResults.Clear();
            foreach (var film in filteredFilms)
            {
                SearchResults.Add(film);
            }

            // Show or hide search results
            SearchResultsLabel.IsVisible = SearchResults.Count > 0;
            SearchResultsView.IsVisible = SearchResults.Count > 0;

            if (SearchResults.Count == 0)
            {
                DisplayAlert("Result", "No movies found.", "OK");
            }
        }
    }
}
