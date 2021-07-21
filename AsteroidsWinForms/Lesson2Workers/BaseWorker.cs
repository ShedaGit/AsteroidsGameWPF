using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lesson2Workers
{
    abstract class BaseWorker : IComparable<BaseWorker>
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
        abstract public int CompareTo(BaseWorker other);
    }
}
