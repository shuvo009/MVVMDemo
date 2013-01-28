using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MVVMDemo.Model
{
    public class Employee : ObjectBase
    {
        private long _employeeID;
        private string _name;
        private string _designation;
        private string _address;
        private string _contractNumber;
        private DateTime _joinDate;

        [Key]
        public virtual long EmployeeID
        {
            get { return _employeeID; }
            set
            {
                if (_employeeID != value)
                {
                    _employeeID = value;
                    OnPropertyChange("EmployeeID");
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
         [MaxLength(100)]
        public virtual string Designation
        {
            get { return _designation; }
            set
            {
                if (_designation != value)
                {
                    _designation = value;
                    OnPropertyChange("Designation");
                }
            }
        }
         [MaxLength(100)]
         public virtual string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChange("Address");
                }
            }
        }
         [MaxLength(100)]
         public virtual string ContractNumber
        {
            get { return _contractNumber; }
            set
            {
                if (_contractNumber != value)
                {
                    _contractNumber = value;
                    OnPropertyChange("ContractNumber");
                }
            }
        }

         public virtual DateTime JoinDate
        {
            get { return _joinDate; }
            set
            {
                if (_joinDate != value)
                {
                    _joinDate = value;
                    OnPropertyChange("JoinDate");
                }
            }
        }

         public virtual Department Departments { get; set; }
    }
}
