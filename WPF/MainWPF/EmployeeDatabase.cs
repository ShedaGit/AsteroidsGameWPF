using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWPF
{
    class EmployeeDatabase
    {
        private const string ConnectionString = @"Data Source=(local);Initial Catalog=WPF;User ID=WPF_Root;Password=321123";

        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeDatabase()
        {
            Employees = new ObservableCollection<Employee>();
            LoadFromDatabase();
        }

        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                //TODO Добавить обязательную проверку на ввод полного имени
                string sqlExpression = $@"INSERT INTO Employees (FirstName, LastName, MiddleName, Comment, OfficeCategory)
                                     VALUES ('{employee.FirstName}', '{employee.LastName}', '{employee.MiddleName}', '{employee.Comment}', {(int)employee.OfficeCategory} )";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    Employees.Add(employee);
                }
                return res;
            }
        }

        //Пришлось добавить параметр employeeBefore, так как если нужно поменять имя, в параметр WHERE передавалось уже измененное ФИО, то есть мы изменяли то, чего нет
        public int Update(Employee employeeBefore, Employee employeeAfter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"UPDATE Employees 
                    SET FirstName = '{employeeAfter.FirstName}', LastName = '{employeeAfter.LastName}', MiddleName = '{employeeAfter.MiddleName}', Comment = '{employeeAfter.Comment}', OfficeCategory = {(int)employeeAfter.OfficeCategory}
                    WHERE FirstName = '{employeeBefore.FirstName}' AND LastName = '{employeeBefore.LastName}' AND MiddleName = '{employeeBefore.MiddleName}'";
                var command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
            }
        }

        public int Remove(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"DELETE FROM Employees WHERE FirstName = '{employee.FirstName}' AND LastName = '{employee.LastName}' AND MiddleName = '{employee.MiddleName}'";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    Employees.Remove(employee);
                }
                return res;
            }
        }

        private void LoadFromDatabase()
        {
            string sqlExpression = "SELECT * FROM Employees";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var contact = new Employee()
                            {
                                FirstName = reader.GetValue(0).ToString(),
                                LastName = reader["LastName"].ToString(),
                                MiddleName = reader.GetString(2),
                                Comment = reader["Comment"].ToString(),
                                OfficeCategory = (Department)reader.GetInt32(4)
                            };
                            Employees.Add(contact);
                        }
                    }
                }
            }
        }
    }
}
