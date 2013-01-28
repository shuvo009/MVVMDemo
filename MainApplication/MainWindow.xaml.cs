using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVMDemo.ModelView;
using MVVM.View;
namespace MainApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RealyCommand MenuCommand { get; set; }
        public MainWindow()
        {
            MenuCommand = new RealyCommand(Menu_Execute);
            InitializeComponent();
            
        }

        private void Menu_Execute(object name)
        {
            switch (name.ToString())
            {
                case "Employee":
                    contentPresenter.Content = new EmployeeView();
                    break;
                case "Dpt":
                    contentPresenter.Content = new DepartmentView();
                    break;
                case "Search":
                    contentPresenter.Content = new SearchView();
                    break;
                default:
                    break;
            }
        }
    }
}
