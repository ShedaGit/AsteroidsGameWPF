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

namespace WPF.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        private Employee _employee;
        
        public EmployeeControl()
        {
            InitializeComponent();

            cbOfficeCategory.ItemsSource = Enum.GetValues(typeof(Department)).Cast<Department>();
        }

        public void SetEmployee(Employee employee)
        {
            _employee = employee;

            tbFirstname.Text = employee.FirstName;
            tbLastname.Text = employee.LastName;
            tbMiddlename.Text = employee.MiddleName;
            cbOfficeCategory.SelectedItem = employee.OfficeCategory;
            tbComment.Text = employee.Comment;
        }

        public void UpdateEmployee()
        {
            _employee.FirstName = tbFirstname.Text;
            _employee.LastName = tbLastname.Text;
            _employee.MiddleName = tbMiddlename.Text;
            _employee.OfficeCategory = (Department)cbOfficeCategory.SelectedItem;
            _employee.Comment = tbComment.Text;
        }
    }
}
