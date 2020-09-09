using System;
using System.Collections.Generic;

namespace BasicPaySlip
{
    public class IncomeTax
    {
        public List<TaxTable> TaxTables { get; set; }

        public IncomeTax()
        {
            TaxTables = new List<TaxTable>();
        }

        public decimal Calculate(int year, decimal income)
        {
            var taxBracket = findTaxBracket(income, findTaxTableByYear(year));
            var taxAmount = taxBracket.BaseAmount + (income - taxBracket.MinIncome) * taxBracket.TaxRate;

            return taxAmount;
        }

        private TaxTable findTaxTableByYear(int year)
        {
            return TaxTables.Find(taxTable => taxTable.Year == year);
        }

        private TaxBracket findTaxBracket(decimal income, TaxTable taxTable)
        {
            return taxTable.TaxRate.Find(taxBracket =>

                income > taxBracket.MinIncome && (taxBracket.MaxIncome == null ? true : income < taxBracket.MaxIncome)

            );
        }
    }
}
