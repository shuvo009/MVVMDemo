using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMDemo.Model;
using System.Collections.ObjectModel;
using System.Windows;
namespace MVVMDemo.ModelView
{
    public class EmployeeByDptViewModel : ViewModelBase
    {
        private readonly DemoDataContext _demoDataContext = new DemoDataContext();
        public EmployeeByDptViewModel():base("Search")
        {
            SearchBtnCont = "Search";
            Departments = new ObservableCollection<Department>(_demoDataContext.Departments.ToList());
            SearchCommand = new RealyCommand(Search_Execute, Search_CanExecute);
            Employees = new ObservableCollection<Employee>();
        }

        public string SearchBtnCont { get; set; }

        public RealyCommand SearchCommand { get; set; }

        private void Search_Execute(object department)
        {
            try
            {
                Employees.Clear();
                var xe = new ObservableCollection<Employee>(_demoDataContext.Departments.AsEnumerable().Where(x => x.DepartmentID == (department as Department).DepartmentID).Select(x=>x.employess).ToList().FirstOrDefault());
                foreach (var item in xe)
                {
                    Employees.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Search.");
            }
        }

        private bool Search_CanExecute(object department)
        {

            if ((department as Department) == null)
            {
                return false;
            }
            return true;
        }
    }
}
