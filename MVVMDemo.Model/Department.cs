using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MVVMDemo.Model
{
    public class Department : ObjectBase
    {
        private long _departmentID;
        private string _name;

        [Key]
        public virtual long DepartmentID
        { 
            get 
             { 
               return _departmentID;
             } 
            set 
            {
                if (_departmentID!=value)
                {
                    _departmentID = value;
                    OnPropertyChange("DepartmentID");
                }
            }
        }


        [MaxLength(100)]
        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChange("Name");
                }
            }
        }

        public virtual List<Employee> employess { get; set; }
    }
}
