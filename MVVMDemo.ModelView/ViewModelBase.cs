using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MVVMDemo.Model;

namespace MVVMDemo.ModelView
{
    public abstract  class ViewModelBase
    {
        public ViewModelBase(string title)
        {
            Title = title;
            SaveBtnContent = "Save";
            UpdateBtnContent = "Update";
            DeleteBtnContent = "Delete";
        }
        public string Title { get; set; }
        public string SaveBtnContent { get; set; }
        public string UpdateBtnContent { get; set; }
        public string DeleteBtnContent { get; set; }

        public ObservableCollection<Department> Departments { get; set; }

        public ObservableCollection<Employee> Employees { get; set; }
    }
}
