using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Calc : ICalc
    {
        public double num1 { get; set; }

        public void Clear()
        {
            this.num1 = 0;
        }

        public double Divided(double num2)
        {
            return this.num1 / num2;

        }

        public double FindARooot()
        {
            return Math.Sqrt(num1);
        }

        public double Multiply(double num2)
        {
            return this.num1 * num2;
        }

        public double Percent()
        {
            return this.num1 / 100;
        }

        public void Save(double num)
        {
            this.num1 = num;
        }

        public double Subtract(double num2)
        {
            return this.num1 - num2;

        }

        public double Sum(double num2)
        {
            return this.num1 + num2;

        }
    }
}
