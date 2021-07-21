using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2Workers
{
    abstract class BaseWorker
    {
        protected string _name;
        protected int _salary;

        abstract public string Name { get; }

        public BaseWorker(string name, int salary)
        {
            _name = name;
            _salary = salary;
        }

        abstract public double GetSalaryPerMonth();
    }
}
