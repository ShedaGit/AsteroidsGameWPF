using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Communication.WpfService
{
    public partial class Employee : ICloneable
    {
        //Если необходимо можно реализовать различные конструкторы
        public Employee() { }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
