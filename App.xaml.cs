using Task.MVVM.Views;
using Task.Service;

namespace Task
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PrivacyPolicy());
        }
    }
}
