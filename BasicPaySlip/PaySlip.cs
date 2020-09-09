using System;
namespace BasicPaySlip
{
    public class PaySlip
    {
        private Employee _employee;
        private DateTime _paymentStartDate;
        private decimal _grossIncome;
        private decimal _apportionedIncomeTaxAmount;
        private DateTime[] _payPeriod;
        private decimal _superAmount;
        private decimal _netIncome;
        private const int grossIncomeUnitMeasurement = 12;

        public PaySlip(DateTime paymentStartDate, Employee employee)
        {
            _employee = employee;
            _paymentStartDate = paymentStartDate;

        }

        public string Display()
        {
            GeneratePaymentData();
            var displayText = FormatDisplayData();
            return displayText;

        }

        private void GeneratePaymentData()
        {
            _payPeriod = GetPayPeriod(_paymentStartDate);
            _grossIncome = CalculateGrossIncome();
            var incomeTax = InstantiseIncomeTaxTable();
            var annualIncomeTaxAmount = incomeTax.Calculate(_paymentStartDate.Year, _employee.AnnualSalary);
            _apportionedIncomeTaxAmount = CalculateApportionedIncomeTax(annualIncomeTaxAmount);
            var superannuation = new Superannuation(_employee.SuperRate);
            _superAmount = superannuation.Calculate(_grossIncome);
            _netIncome = CalculateNetIncome();

        }

        private string FormatDisplayData()
        {
            var text = $"Name: {_employee.Name}\n" +
                $"Pay Period: {_payPeriod[0].ToString("MMMM dd")} - {_payPeriod[1].ToString("MMMM dd")}\n" +
                $"Gross Income: {RoundToWholeDollar(_grossIncome)}\n" +
                $"Income Tax: {RoundToWholeDollar(_apportionedIncomeTaxAmount)}\n" +
                $"Net Income: {RoundToWholeDollar(_netIncome)}\n" +
                $" Super: {RoundToWholeDollar(_superAmount)}";
            return text;
        }

        private int RoundToWholeDollar(decimal amount)
        {
            var roundedAmount = Math.Round(amount, MidpointRounding.AwayFromZero);
            return (int)roundedAmount;
 
        }

        private IncomeTax InstantiseIncomeTaxTable()
        {
            var taxTable = new TaxTable(2018);
            var taxRates = new TaxRates();
            taxTable.AddTaxRate(taxRates.TaxRate2018);
            var incomeTax = new IncomeTax();
            incomeTax.TaxTables.Add(taxTable);
            return incomeTax;
        }

        private decimal CalculateGrossIncome()
        {
            var grossIncome = _employee.AnnualSalary / grossIncomeUnitMeasurement;
            return grossIncome;
        }

        private decimal CalculateApportionedIncomeTax(decimal incomeTaxAmount)
        {
            var apportionedIncomeTaxAmount = incomeTaxAmount / grossIncomeUnitMeasurement;
            return apportionedIncomeTaxAmount;
        }

        private decimal CalculateNetIncome()
        {
            return _grossIncome - _superAmount;
        }

        private DateTime[] GetPayPeriod(DateTime paymentStartDate)
        {
            var payPeriod = new DateTime[2];
            payPeriod[0] = paymentStartDate.Day != 1 ? AdjustStartDate(paymentStartDate) : paymentStartDate;
            payPeriod[1] = payPeriod[0].AddMonths(1).AddDays(-1);

            return payPeriod;
        }

        private DateTime AdjustStartDate(DateTime paymentStartDate)
        {
            var firstDayOfMonth = new DateTime(paymentStartDate.Year, paymentStartDate.Month, 1);
            Console.WriteLine($"Payment start date on the payslip will be adjusted to {firstDayOfMonth}");
            return firstDayOfMonth;
        }
    }
}
