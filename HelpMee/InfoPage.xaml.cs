using Microsoft.Maui.Controls;

namespace HelpMee
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage() 
        {
            InitializeComponent();
        }

        private async void ReturnToMainPage1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }
    }
}