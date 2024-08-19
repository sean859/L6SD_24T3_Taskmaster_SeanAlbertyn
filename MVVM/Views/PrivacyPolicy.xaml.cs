using Task.MVVM.ViewModels;

namespace Task.MVVM.Views;

public partial class PrivacyPolicy : ContentPage
{
	public PrivacyPolicy()
	{
        InitializeComponent();
    }

    private async void PrivacyPolicyButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainView());
    }
}