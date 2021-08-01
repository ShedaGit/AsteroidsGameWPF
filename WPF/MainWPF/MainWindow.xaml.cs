using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Controls;

namespace MainWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeDatabase database = new EmployeeDatabase();

        public ObservableCollection<Employee> EmployeesCollection{ get; set; }
        public Employee SelectedEmployee { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            EmployeesCollection = database.Employees;
        }

        private void employeesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                employeesControl.Employee = (Employee)SelectedEmployee.Clone();
            }
        }

        

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (employeesListView.SelectedItems.Count < 1) return;
            database.Employees[database.Employees.IndexOf(SelectedEmployee)] = employeesControl.Employee;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeCreateWindow window = new EmployeeCreateWindow();

            if (window.ShowDialog() == true)
            {
                database.Employees.Add(window.Employee);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (employeesListView.SelectedItems.Count < 1) return;

            if (MessageBox.Show("Вы действительно желаете удалить анкету сотрудника?", "Удаление анкеты", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                database.Employees.Remove(SelectedEmployee);
            }
        }
    }
}
