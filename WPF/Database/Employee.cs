using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : INotifyPropertyChanged, ICloneable
    {
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _comment;
        private Department _officeCategory = Department.General;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Полное имя
        /// </summary>
        public string FullName { get => $"{FirstName} {MiddleName} {LastName}"; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Направление департамента, в котором состоит сотрудник
        /// </summary>
        public Department OfficeCategory
        {
            get { return _officeCategory; }
            set
            {
                _officeCategory = value;
                NotifyPropertyChanged();
            }
        }

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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
