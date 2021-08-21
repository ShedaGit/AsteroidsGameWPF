using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Communication.WpfService;

namespace MainWPF
{
    class EmployeeDatabase
    {
        WpfServiceSoapClient wpfServiceSoapClient = new WpfServiceSoapClient();

        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeDatabase()
        {
            Employees = new ObservableCollection<Employee>();
            Load();
        }

        public int Add(Employee employee)
        {
            var res = wpfServiceSoapClient.Add(employee);
            if (res > 0)
            {
                Employees.Add(employee);
            }
            return res;
        }

        //Пришлось добавить параметр employeeBefore, так как если нужно поменять имя, в параметр WHERE передавалось уже измененное ФИО, то есть мы изменяли то, чего нет
        public int Update(Employee employeeBefore, Employee employeeAfter)
        {
            return wpfServiceSoapClient.Update(employeeBefore, employeeAfter);
        }

        public int Remove(Employee employee)
        {
            var res = wpfServiceSoapClient.Remove(employee);
            if (res > 0)
            {
                Employees.Remove(employee);
            }
            return res;
        }

        private void Load()
        {
            foreach (var employee in wpfServiceSoapClient.Load())
            {
                Employees.Add(employee);
            }
        }
    }
}
