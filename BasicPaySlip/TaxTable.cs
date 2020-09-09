using System;
using System.Collections.Generic;

namespace BasicPaySlip
{
    public class TaxTable
    {
        public int Year { get; private set; }
        public List<TaxBracket> TaxRate;

        public TaxTable(int year )
        {
            TaxRate = new List<TaxBracket>();
            Year = year;
        }

        public void AddTaxRate(List<Dictionary<string, double?>> taxRate)
        {
            taxRate.ForEach(threshold =>
            {
                var taxBracket = CreateTaxBracket(threshold);
                TaxRate.Add(taxBracket);
            });

        }
        private TaxBracket CreateTaxBracket(Dictionary<string,double?> threshold)
        {
            var minIncome = (decimal)threshold["minIncome"];
            var maxIncome = (decimal?)threshold["maxIncome"];
            var baseAmount = (decimal)threshold["baseAmount"];
            var taxRate = (decimal)threshold["taxRate"] / 100;

            return new TaxBracket(minIncome, maxIncome, baseAmount, taxRate);
        }
    }
    
}