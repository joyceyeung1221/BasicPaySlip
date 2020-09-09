using System;
namespace BasicPaySlip
{
    public class Superannuation
    {
        private double _rate;
        public Superannuation(double rate)
        {
            _rate = rate;
        }

        public decimal Calculate(decimal grossIncome)
        {
            return grossIncome * (decimal)_rate;
        }
    }
}
