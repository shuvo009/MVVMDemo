using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMDemo.Model;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
namespace MVVMDemo.ModelView
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly DemoDataContext _demoDataContext = new DemoDataContext();
        public EmployeeViewModel():base("Employee")
        {
            Employees = new ObservableCollection<Employee>(_demoDataContext.Employees.ToList());
            Departments = new ObservableCollection<Department>(_demoDataContext.Departments.ToList());
            SaveCommand = new RealyCommand(Save_Execute, Save_CanExecute);
            UpdateCommand = new RealyCommand(Update_Execute, Update_CanExecute);
            DeletedCommand = new RealyCommand(Delete_Execute, Update_CanExecute);
        }

        public RealyCommand SaveCommand { get; set; }
        public RealyCommand UpdateCommand { get; set; }
        public RealyCommand DeletedCommand { get; set; }
        private void Save_Execute(object employee)
        {
            try
            {
               
                var newemployee = employee as Employee;
                _demoDataContext.Employees.Add(newemployee);
                _demoDataContext.Entry(newemployee).State = EntityState.Added;
                _demoDataContext.SaveChanges();
                MessageBox.Show(string.Format("{0} Save Successfully!", newemployee.Name));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Save employee Information.");
            }
        }

        private bool Save_CanExecute(object employee)
        {
            var newemployee = employee as Employee;
            if (newemployee==null || String.IsNullOrEmpty(newemployee.Name) || String.IsNullOrWhiteSpace(newemployee.Name))
            {
                return false;
            }
            return true;
        }

        private void Update_Execute(object employee)
        {
            try
            {
                var selectedemployee = employee as Employee;
                var orginalEmployee = _demoDataContext.Employees.Single(x => x.EmployeeID == selectedemployee.EmployeeID);
                _demoDataContext.Entry(orginalEmployee).CurrentValues.SetValues(selectedemployee);
                orginalEmployee.Departments = _demoDataContext.Departments.Single(x => x.DepartmentID == selectedemployee.Departments.DepartmentID); // Update relationship manually 
                _demoDataContext.SaveChanges();
                MessageBox.Show(string.Format("{0} Updated Successfully.", selectedemployee.Name));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to update.");
            }
        }

        private bool Update_CanExecute(object employee)
        {
            if ((employee as Employee) == null)
            {
                return false;
            }
            return true;
        }

        private void Delete_Execute(object employee)
        {
            try
            {
                var selectedemployee = employee as Employee;
                _demoDataContext.Employees.Add(selectedemployee);
                _demoDataContext.Entry(selectedemployee).State = EntityState.Deleted;
                _demoDataContext.SaveChanges();
                MessageBox.Show(string.Format("{0} Deleted Successfully", selectedemployee.Name));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to delete.");
            }
        }

    }
}
