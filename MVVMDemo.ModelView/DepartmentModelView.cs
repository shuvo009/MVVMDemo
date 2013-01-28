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
    public class DepartmentModelView : ViewModelBase 
    {
        private readonly DemoDataContext _demoDataContext = new DemoDataContext();
        public DepartmentModelView():base("Department")
        { 
           Departments = new ObservableCollection<Department>(_demoDataContext.Departments.ToList());
           SaveCommand = new RealyCommand(Save_Execute, Save_CanExecute);
           UpdateCommand = new RealyCommand(Update_Execute, Update_CanExecute);
           DeletedCommand = new RealyCommand(Delete_Execute, Update_CanExecute);
        }

        public RealyCommand SaveCommand { get; set; }
        public RealyCommand UpdateCommand { get; set; }
        public RealyCommand DeletedCommand { get; set; }

        private void Save_Execute(object department)
        {
            try
            {
                var newDepartment = department as Department;
                _demoDataContext.Departments.Add(newDepartment);
                _demoDataContext.Entry(newDepartment).State = EntityState.Added;
                _demoDataContext.SaveChanges();
                MessageBox.Show(string.Format("{0} Save Successfully!",newDepartment.Name));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Save Department Information.");
            }
        }

        private bool Save_CanExecute(object department)
        {
            var newDepartment = department as Department;
            if (newDepartment==null || (String.IsNullOrEmpty(newDepartment.Name) || String.IsNullOrWhiteSpace(newDepartment.Name)))
            {
                return false;
            }
            return true;
        }

        private void Update_Execute(object depaartment)
        {
            try
            {
                var selectedDepartment = depaartment as Department;
                _demoDataContext.Departments.Add(selectedDepartment);
                _demoDataContext.Entry(selectedDepartment).State = EntityState.Modified;
                _demoDataContext.SaveChanges();
                MessageBox.Show(string.Format("{0} Updated Successfully.",selectedDepartment.Name));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to update.");
            }
        }

        private bool Update_CanExecute(object department)
        {
            if ((department as Department)==null)
            {
                return false;
            }
            return true;
        }

        private void Delete_Execute(object department)
        {
            try
            {
                var selectedDeparment = department as Department;
                //Remove Department form Employee
                var DptEmp = _demoDataContext.Employees.Where(x => x.Departments.DepartmentID == selectedDeparment.DepartmentID);
                foreach (var item in DptEmp)
                {
                    item.Departments = null;
                }
                _demoDataContext.SaveChanges();
                //Remove Department
                _demoDataContext.Departments.Add(selectedDeparment);
                _demoDataContext.Entry(selectedDeparment).State = EntityState.Deleted;
                _demoDataContext.SaveChanges();
                MessageBox.Show(string.Format("{0} Deleted Successfully",selectedDeparment.Name));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to delete.");
            }
        }
    }
}
