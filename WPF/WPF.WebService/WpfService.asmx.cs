using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WPF.WebService
{
    /// <summary>
    /// Summary description for WpfService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WpfService : System.Web.Services.WebService
    {
        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WpfConnectionString"].ConnectionString;

        [WebMethod]
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
                return res;
            }
        }

        /// <summary>
        /// Метод для обноврения БД
        /// Пришлось добавить параметр employeeBefore, так как если нужно поменять имя,
        /// в параметр WHERE передавалось уже измененное ФИО, то есть мы изменяли то, чего нет
        /// </summary>
        /// <param name="employeeBefore">Выбираются основые парамерты первичного ключа ДО обновления, их можно выбрать при выделении сотрудника</param>
        /// <param name="employeeAfter">Обновление всех параметров в соответствии с заполненной формой</param>
        /// <returns></returns>
        [WebMethod]
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

        [WebMethod]
        public int Remove(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"DELETE FROM Employees WHERE FirstName = '{employee.FirstName}' AND LastName = '{employee.LastName}' AND MiddleName = '{employee.MiddleName}'";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
                return res;
            }
        }

        [WebMethod]
        public ObservableCollection<Employee> Load()
        {
            ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
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
                    return Employees;
                }
            }
        }
    }
}
