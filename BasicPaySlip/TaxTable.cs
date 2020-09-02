using System;
using System.Collections.Generic;

namespace BasicPaySlip
{
    public class TaxTable
    {
        public int Year { get; private set; }
        public List<TaxBracket> TaxRate;

        public TaxTable(int year, List<TaxBracket> taxRate)
        {
            Year = year;
        }
    }
    private List<Dictionary<string, double?>> taxRate2018 = new List<Dictionary<string, double?>>()
    {   new Dictionary<string, double?>()
            {
                { "minAmount", 0},
                { "maxAmount", 18200},
                { "baseAmount", 0},
                { "taxRate", 0}
            },
        new Dictionary<string, double?>()
            {
                { "minAmount", 18201},
                { "maxAmount", 37000},
                { "baseAmount", 0},
                { "taxRate", 19}
            },
        new Dictionary<string, double?>()
            {
                { "minAmount", 0},
                { "maxAmount", 18200},
                { "baseAmount", 0},
                { "taxRate", 32.5}
            },
        new Dictionary<string, double?>()
            {
                { "minAmount", 0},
                { "maxAmount", 18200},
                { "baseAmount", 0},
                { "taxRate", 37}
            },
        new Dictionary<string, double?>()
            {
                { "minAmount", 0},
                { "maxAmount", null},
                { "baseAmount", 54232},
                { "taxRate", 45}
            }
    };
}