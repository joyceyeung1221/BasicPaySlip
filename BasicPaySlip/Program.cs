using System;
using System.Collections.Generic;

namespace BasicPaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            var financialYear = 2018;
            var startDateOfFinancialYear = new DateTime(1900,07,01);
            
            Helper.DisplayOutput("Welcome to the payslip generator!\n");
            Helper.DisplayOutput("Application currently only support Financial Year 2017/18 with Australian default setting\n");


            new PaySlipGenerator(financialYear, startDateOfFinancialYear).Run();

        }
    }
}
