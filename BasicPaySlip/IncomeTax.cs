using System;
using System.Collections.Generic;

namespace BasicPaySlip
{
    public class IncomeTax
    {
        public List<TaxTable> TaxTables { get; set; }
        private DateTime _defaultStartDate;

        public IncomeTax(DateTime defaultStartDate)
        {
            _defaultStartDate = defaultStartDate;
            TaxTables = new List<TaxTable>();
        }

        public decimal Calculate(DateTime paymentStartDate, decimal income)
        {
            var taxBracket = FindTaxBracket(income, FindTaxTableByYear(paymentStartDate));
            var taxAmount = taxBracket.BaseAmount + (income - taxBracket.MinIncome) * taxBracket.TaxRate;

            return taxAmount;
        }

        private TaxTable FindTaxTableByYear(DateTime paymentStartDate)
        {
            var financialYear = paymentStartDate.Month < _defaultStartDate.Month ? paymentStartDate.Year : paymentStartDate.Year + 1;
            return TaxTables.Find(taxTable => taxTable.Year == financialYear);
        }

        private TaxBracket FindTaxBracket(decimal income, TaxTable taxTable)
        {
            return taxTable.TaxRate.Find(taxBracket =>

                income > taxBracket.MinIncome && (taxBracket.MaxIncome == null || income < taxBracket.MaxIncome)

            );
        }
    }
}
