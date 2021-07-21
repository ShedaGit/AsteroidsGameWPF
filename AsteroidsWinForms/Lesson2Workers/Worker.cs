using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2Workers
{
    /// <summary>
    /// Рабочий (фулл-тайм)
    /// </summary>
    public class Worker : Employee
    {
        public Worker(string name, string surname, decimal salary) : base(name, surname, salary) { }

        public override decimal СalculateSalary()
        {
            return Salary;
        }

        public override string ToString()
        {
            return $"{Surname} {Name}; Рабочий; Среднемесячная заработная плата (фиксированная месячная оплата): {СalculateSalary()} (руб.)";
        }
    }
}
