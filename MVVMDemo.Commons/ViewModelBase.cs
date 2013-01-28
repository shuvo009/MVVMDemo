using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMDemo.Commons
{
    public partial  class ViewModelBase
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
    }
}
