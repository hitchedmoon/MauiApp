using Microsoft.Maui.Controls;

namespace HelpMee
{
    public partial class App : Application
    {
        public User CurrentUser { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
