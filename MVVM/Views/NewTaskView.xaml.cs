using System.ComponentModel.DataAnnotations.Schema;
using Task.MVVM.Models;
using Task.MVVM.ViewModels;
using Task.Service;

namespace Task.MVVM.Views;

public partial class NewTaskView : ContentPage	
{
	private readonly DatabaseService Database = new DatabaseService();


    public NewTaskView()
	{
		InitializeComponent();
	}

    private async void AddTaskClicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;

		var selectedCategory = vm.Categories.Where(x => x.IsSelected == true).FirstOrDefault();


        if (selectedCategory != null )
		{
			var task = new MyTask
			{
				TaskName = vm.Task,
				CategoryId = selectedCategory.Id,
			};
			
			await Database.SaveTaskAsync(task);

			var totalTasks = await Database.GetTasksAsync();
			vm.Tasks.Clear();

			foreach (var eachTask in totalTasks)
			{
				vm.Tasks.Add(eachTask);
			}

			await Navigation.PopAsync();
		}
		else
		{
			await DisplayAlert("Invalid Selection", "You must select a category", "Ok");
		}
    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;

		string category =
			await DisplayPromptAsync("New Category",
			"Write the new category name",
			maxLength: 15,
			keyboard: Keyboard.Text);

		var r = new Random();

		if(!string.IsNullOrEmpty(category))
		{
			var newCategory = new Category
			{
				
				Color = Color.FromRgb(
					r.Next(0, 255),
					r.Next(0, 255),
					r.Next(0, 255)).ToHex(),
				CategoryName = category
			};

			await Database.SaveCategoryAsync(newCategory);

			var categories = await Database.GetCategoriesAsync();
			vm.Categories.Clear();

			foreach (var cat in categories)
			{
				vm.Categories.Add(cat);
			}

			
		}
		
    }
}