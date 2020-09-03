using System;
using System.Collections.Generic;

namespace BasicPaySlip
{
    public class TaxTable
    {
        public int Year { get; private set; }
        public List<TaxBracket> TaxRate;

        public TaxTable(int year, List<Dictionary<string,double>> taxRate)
        {
            Year = year;
            taxRate.ForEach(threshold =>
            {
                var taxBracket = createTaxBracket(threshold);
                TaxRate.Add(taxBracket);
            });
        }

        private TaxBracket createTaxBracket(Dictionary<string,double> threshold)
        {
            var minIncome = (decimal)threshold["minIncome"];
            var maxIncome = (decimal)threshold["maxIncome"];
            var baseAmount = (decimal)threshold["baseAmount"];
            var taxRate = threshold["taxRate"] / 100;

            return new TaxBracket(minIncome, maxIncome, baseAmount, taxRate);
        }
    }
    
}