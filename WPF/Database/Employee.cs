using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Полное имя
        /// </summary>
        public string FullName { get => $"{FirstName} {MiddleName} {LastName}"; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Направление департамента, в котором состоит сотрудник
        /// </summary>
        public Department OfficeCategory { get; set; }

        public Employee() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstname">Имя</param>
        /// <param name="lastname">Фамилия</param>
        /// <param name="middlename">Отчество</param>
        /// <param name="officeCategory">Направление департамента</param>
        public Employee(string firstname, string lastname, string middlename, Department officeCategory)
        {
            FirstName = firstname;
            LastName = lastname;
            MiddleName = middlename;

            OfficeCategory = officeCategory;
        }

        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName.First()}.";
        }

    }
}
