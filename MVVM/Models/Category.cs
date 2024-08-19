using PropertyChanged;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Color { get; set; }

        public string PendingTasks { get; set; }

        public float Percentage { get; set; }

        public bool IsSelected { get; set; }


    }
}
