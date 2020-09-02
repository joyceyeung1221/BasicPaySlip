using System;
namespace BasicPaySlip
{
    public class TaxBracket
    {
        public decimal MinIncome { get; private set; }
        public decimal MaxIncome { get; private set; }
        public decimal BaseAmount { get; private set; }
        public double TaxRate { get; private set; }

        public TaxBracket(decimal minIncome, decimal maxIncome, decimal baseAmount, double taxRate)
        {
            MinIncome = minIncome;
            MaxIncome = maxIncome;
            BaseAmount = baseAmount;
            TaxRate = taxRate;
        }
    }
}
