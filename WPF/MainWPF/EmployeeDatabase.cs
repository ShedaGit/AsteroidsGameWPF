using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWPF
{
    class EmployeeDatabase
    {
        private string[] maleFirstnames = { "Андрей", "Алексей", "Валентин", "Павел", "Михаил", "Константин", "Владислав" };
        private string[] femaleFirstnames = { "Юлия", "Дарья", "Наталья", "Зиноида", "Серафима", "Анастасия", "Елена" };

        private string[] maleLastnames = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Михайлов" };
        private string[] femaleLastnames = { "Иванова", "Смирнова", "Кузнецова", "Попова", "Васильева", "Петрова", "Михайлова" };

        private string[] maleMiddlenames = { "Андреевич", "Алексеевич", "Валентинович", "Павлович", "Михайлович", "Константинович", "Владиславович" };
        private string[] femaleMiddlenames = { "Андреевна", "Алексеевна", "Валентиновна", "Павловна", "Михайловна", "Константиновна", "Владиславовна" };

        public List<Employee> Employees { get; set; }

        public EmployeeDatabase()
        {
            Employees = new List<Employee>();
            GenerateContacts(50);
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
