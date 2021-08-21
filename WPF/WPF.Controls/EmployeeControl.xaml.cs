using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WPF.Communication.WpfService;

namespace WPF.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl, INotifyPropertyChanged
    {
        private Employee _employee;

        public event PropertyChangedEventHandler PropertyChanged;

        public Employee Employee
        {
            get { return _employee; }
            set 
            { 
                _employee = value;
                NotifyPropertyChanged();
            }
        }

        public List<Department> DepartmentsList { get; set; } = new List<Department>();

        public EmployeeControl()
        {
            InitializeComponent();

            this.DataContext = this;

            DepartmentsList.Add(Department.General);
            DepartmentsList.Add(Department.IT);
            DepartmentsList.Add(Department.Finance);
            DepartmentsList.Add(Department.HR);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
