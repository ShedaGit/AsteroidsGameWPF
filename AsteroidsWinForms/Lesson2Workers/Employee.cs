using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lesson2Workers
{
    abstract class Employee : IComparable<Employee>
    {
        protected string _name;
        protected int _salary;

        abstract public string Name { get; }

        public Employee(string name, int salary)
        {
            _name = name;
            _salary = salary;
        }

        abstract public double GetSalaryPerMonth();
        abstract public int CompareTo(Employee other);
    }
}
