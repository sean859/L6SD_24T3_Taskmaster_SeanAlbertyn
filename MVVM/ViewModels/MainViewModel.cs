using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.MVVM.Models;
using Task.Service;

namespace Task.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class MainViewModel : ObservableObject
    {
        private readonly DatabaseService Database = new DatabaseService();

        private int _nextId = 1;
        public ObservableCollection<Category> Categories { get; set; }

        public ObservableCollection<MyTask> Tasks { get; set; }



        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = ".NET MAUI Course",
                    Color = "#CF14DF"
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Test",
                    Color = "#df6f14"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Shopping",
                    Color = "#14df80"
                }
            };

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Do the work bruh",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName= "Plan next course",
                    Completed = true,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Upload exercise files",
                    Completed = false,
                    CategoryId= 3
                }
            };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;


                c.PendingTasks = notCompleted.Count().ToString();   
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor = 
                    (from c in Categories
                     where c.Id == t.CategoryId
                     select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }




        }

        private async void LoadData()
        {
            var categories = await Database.GetCategoriesAsync();
            Categories.Clear();
            
                foreach (var category in Categories)
                {
                    Categories.Add(category);
                }

                foreach (var task in Tasks)
                {
                    Tasks.Add(task);
                }
            
            

            UpdateData();
        }
    }
}
