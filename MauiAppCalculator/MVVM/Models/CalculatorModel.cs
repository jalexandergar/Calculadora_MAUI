using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppCalculator.MVVM.Models
{
    public class CalculatorModel
    {
        public string operatorMath { get; set;}

        public double Num { get; set;}

        public double Tot { get; set;}

        public void DoCalculate()
        {
            switch (operatorMath)
            {
                case "/":
                    Tot = Tot / Num;
                    break;
                case "-":
                    Tot = Tot - Num;
                    break;
                case "*":
                    Tot = Tot * Num;
                    break;
                case "+":
                    Tot = Tot + Num;
                    break;
                default:
                    break;
            }
        }

    }

    
}
