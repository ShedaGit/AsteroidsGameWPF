using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2Workers
{
    class OutsourceWorker : BaseWorker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of a Worker</param>
        /// <param name="salary">Fixed rate salary</param>
        public OutsourceWorker(string name, int salary) : base(name, salary) { }

        public override string Name { get => _name; }
        public override int CompareTo(BaseWorker other)
        {
            return (int)this.GetSalaryPerMonth() - (int)other.GetSalaryPerMonth();
        }

        public override double GetSalaryPerMonth()
        {
            return _salary;
        }
    }
}
