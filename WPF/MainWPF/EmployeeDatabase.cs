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

        private string[] maleFirstnames = { "Андрей", "Алексей", "Валентин", "Павел", "Михаил", "Константин", "Владислав" };
        private string[] femaleFirstnames = { "Юлия", "Дарья", "Наталья", "Зиноида", "Серафима", "Анастасия", "Елена" };

        private string[] maleLastnames = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Михайлов" };
        private string[] femaleLastnames = { "Иванова", "Смирнова", "Кузнецова", "Попова", "Васильева", "Петрова", "Михайлова" };

        private string[] maleMiddlenames = { "Андреевич", "Алексеевич", "Валентинович", "Павлович", "Михайлович", "Константинович", "Владиславович" };
        private string[] femaleMiddlenames = { "Андреевна", "Алексеевна", "Валентиновна", "Павловна", "Михайловна", "Константиновна", "Владиславовна" };

        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeDatabase()
        {
            Employees = new ObservableCollection<Employee>();
            GenerateContacts(50);
            SyncToDatabase();
        }

        void SyncToDatabase()
        {
            var listOfAddedEmployees = new List<string>();
            foreach (var employee in Employees)
            {
                //Костыльная проверка на совпадение полного имени (ФИО), потому что ФИО это Primary Key
                if (!listOfAddedEmployees.Contains(employee.ToString()))
                {
                    listOfAddedEmployees.Add(employee.ToString());
                    Add(employee);
                }
            }
        }

        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"INSERT INTO Employees (FirstName, LastName, MiddleName, Comment, OfficeCategory)
                                     VALUES ('{employee.FirstName}', '{employee.LastName}', '{employee.MiddleName}', '{employee.Comment}', {(int)employee.OfficeCategory} )";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
                //if (res > 0)
                //{
                //    Employees.Add(employee);
                //}
                return res;
            }
        }

        private void GenerateContacts(int employeesCount)
        {
            Random random = new Random();
            Employees.Clear();

            string firstname = string.Empty;
            string lastname = string.Empty;
            string middlename = string.Empty;

            while (Employees.Count < employeesCount)
            {
                var male = random.Next(2) == 0 ? true : false;
                if (male)
                {
                    firstname = maleFirstnames[random.Next(maleFirstnames.Length)];
                    lastname = maleLastnames[random.Next(maleLastnames.Length)];
                    middlename = maleMiddlenames[random.Next(maleMiddlenames.Length)];
                }
                else
                {
                    firstname = femaleFirstnames[random.Next(femaleFirstnames.Length)];
                    lastname = femaleLastnames[random.Next(femaleLastnames.Length)];
                    middlename = femaleMiddlenames[random.Next(femaleMiddlenames.Length)];
                }

                var officeCategory = (Department)random.Next(0, 4);

                Employees.Add(new Employee(firstname, lastname, middlename, officeCategory));
            }
        }
    }
}
