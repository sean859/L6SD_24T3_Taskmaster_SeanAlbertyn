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
    public class NewTaskViewModel
    {
        private readonly DatabaseService Database = new DatabaseService();
        public string Task {  get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
    }
}
