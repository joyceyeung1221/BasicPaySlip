using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BasicPaySlip
{
    public class Validation
    {
        private readonly double[] _superRange = new double[] { 0, 50 };

        public Validation()
        {
        }

        public DateTime CheckPaymentStartDate(string input, int financialYear, DateTime startDateOfFinancialYear)
        {
            var isADate = DateTime.TryParse(input, out DateTime dateInput);
            var supportedYearsStartDate = new DateTime(financialYear - 1, startDateOfFinancialYear.Month, startDateOfFinancialYear.Day);
            var supportedYearsEndDate = new DateTime(financialYear, startDateOfFinancialYear.Month, startDateOfFinancialYear.Day).AddDays(-1);

            if (!isADate)
            {
                throw (new InputIsNotValidException("Date is not in correct format"));

            }
            else if (dateInput < supportedYearsStartDate || dateInput > supportedYearsEndDate)
            {
                throw (new InputIsNotValidException("Date is not within the supported range"));

            }
            else
            {
                if (dateInput.Day != 1)
                {
                    Helper.DisplayOutput($"Start date will be recorded, however payment start date on the payslip will be adjusted to the 1st of {dateInput.ToString("MMMM")}");
                }
                return dateInput;

            }


        }

        public string CheckFieldInput(string input, string fieldName)
        {
            var numbericInput = new string[] { "annual salary", "superannuation rate" };
            if (input == null)
            {
                throw (new InputIsNotValidException("Invalid Input - value is null"));
            }
            else if (!numbericInput.Contains(fieldName) && !Regex.IsMatch(input, @"^[a-zA-Z.]+$"))
            {
                throw (new InputIsNotValidException("Invalid Input - Please use characters only"));
            }
            else if (numbericInput.Contains(fieldName) && !decimal.TryParse(input, out decimal result))
            {
                throw (new InputIsNotValidException("Invalid Input"));
            }
            else if(fieldName=="superannuation rate" && (double.Parse(input)>_superRange[1] || double.Parse(input)<_superRange[0]))
            {
                throw (new InputIsNotValidException("Input rate is not within the allowed range"));
            }
            else
            {
                return input;
            }
        }
    }
}
