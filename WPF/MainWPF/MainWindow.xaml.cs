using Database;
using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();

            employeesListView.ItemsSource = database.Employees;
        }

        private void employeesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                employeesControl.SetEmployee((Employee)e.AddedItems[0]);
            }
        }

        private void UpdateBinding()
        {
            employeesListView.ItemsSource = null;
            employeesListView.ItemsSource = database.Employees;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (employeesListView.SelectedItems.Count < 1) return;

            employeesControl.UpdateEmployee();
            UpdateBinding();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeCreateWindow window = new EmployeeCreateWindow();

            if (window.ShowDialog() == true)
            {
                database.Employees.Add(window.Employee);
                UpdateBinding();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (employeesListView.SelectedItems.Count < 1) return;

            if (MessageBox.Show("Вы действительно желаете удалить анкету сотрудника?", "Удаление анкеты", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                database.Employees.Remove((Employee)employeesListView.SelectedItems[0]);
                UpdateBinding();
            }
        }
    }
}
