using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2Workers
{
    class Worker : BaseWorker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of a Worker</param>
        /// <param name="salary">Salary per hour</param>
        public Worker(string name, int salary) : base(name, salary) { }

        public override string Name { get => _name; }

        public override double GetSalaryPerMonth()
        {
            return 20.8 * 8 * _salary;
        }
    }
}
