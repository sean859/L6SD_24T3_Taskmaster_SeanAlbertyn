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
    public class MyTask
    {
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public bool Completed { get; set; }

        public int CategoryId { get; set; }

        public string TaskColor { get; set; }
    }
}
