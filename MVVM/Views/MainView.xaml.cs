using System.Security.Cryptography.X509Certificates;
using Task.MVVM.ViewModels;

namespace Task.MVVM.Views;

public partial class MainView : ContentPage
{
	private MainViewModel vm = new MainViewModel();
	public MainView()
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		vm.UpdateData();
	}
	
    private void Button_Clicked(object sender, EventArgs e)
    {
		var taskView = new NewTaskView
		{
			BindingContext = new NewTaskViewModel
			{
				Tasks = vm.Tasks,
				Categories = vm.Categories,
			}
		};

		Navigation.PushAsync(taskView);

    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		if (BindingContext is MainViewModel viewModel)
		{
			viewModel.UpdateData();
		}
	}

    private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
		
    }
}