using MauiAppCalculator.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppCalculator.MVVM.ViewModels
{
    public class CalculatorViewModel
    {
        private CalculatorModel model;

        public double Resul { get; set; }

        public CalculatorViewModel()
        {
            model = new CalculatorModel();
        }

        public double Tot
        {
            get { return model.Tot; }
            set { model.Tot = value; }
        }

        public double Num
        {
            get { return model.Num; }
            set { model.Num = value; }
        }

        public void CalculateCommand ()
        {
            model.DoCalculate();
            Resul = model.Tot;
        }
    }
}
