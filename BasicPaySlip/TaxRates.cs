using System;
using System.Collections.Generic;

namespace BasicPaySlip
{
    public class TaxRates
    {
        
        public List<Dictionary<string, double>> TaxRate2018 => _taxRate2018;

        public TaxRates()
        {
        }

        private List<Dictionary<string, double>> _taxRate2018 = new List<Dictionary<string, double>>()
        {
            new Dictionary<string, double>()
                {
                    { "minIncome", 0},
                    { "maxIncome", 18200},
                    { "baseAmount", 0},
                    { "taxRate", 0}
                },
            new Dictionary<string, double>()
                {
                    { "minIncome", 18201},
                    { "maxIncome", 37000},
                    { "baseAmount", 0},
                    { "taxRate", 19}
                },
            new Dictionary<string, double>()
                {
                    { "minIncome", 37001},
                    { "maxIncome", 87000},
                    { "baseAmount", 0},
                    { "taxRate", 32.5}
                },
            new Dictionary<string, double>()
                {
                    { "minIncome", 87001},
                    { "maxIncome", 18000},
                    { "baseAmount", 0},
                    { "taxRate", 37}
                },
            new Dictionary<string, double>()
                {
                    { "minIncome", 18001},
                    { "maxIncome", 0},
                    { "baseAmount", 54232},
                    { "taxRate", 45}
                }
            };
    }
}
