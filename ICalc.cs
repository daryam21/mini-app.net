using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    interface ICalc
    {
        double num1 { get; set; }

        void Save(double num);

        void Clear();

        double Sum(double num2);

        double Subtract(double num2);

        double Multiply(double num2);

        double Divided(double num2);

        double FindARooot();

        double Percent();
        
    }
}
