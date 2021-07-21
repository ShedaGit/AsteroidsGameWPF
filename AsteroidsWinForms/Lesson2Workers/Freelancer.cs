using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2Workers
{
    /// <summary>
    /// Фрилансер (работник с почасовой оплатой)
    /// </summary>
    public class Freelancer : Employee
    {
        public Freelancer(string name, string surname, decimal salary) : base(name, surname, salary) { }

        public override decimal СalculateSalary()
        {
            return (decimal)20.8 * 8 * Salary;
        }

        public override string ToString()
        {
            return $"{Surname} {Name}; Фрилансер; Среднемесячная заработная плата: {СalculateSalary()} (руб.); Почасовая ставка: {Salary} (руб.)";
        }
    }
}
