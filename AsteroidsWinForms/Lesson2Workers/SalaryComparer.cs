using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2Workers
{
    /// <summary>
    /// Класс для сравнения заработных плат работников
    /// </summary>
    public class SalaryComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.СalculateSalary() > y.СalculateSalary() ? 1 : -1;
        }
    }
}
