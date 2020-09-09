using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BasicPaySlip
{
    public class PaySlipGenerator
    {
        private int _supportedFinancialYear;
        private DateTime _defaultStartDateOfFinancialYear;
        private Validation _validation;

        public PaySlipGenerator(int financialYear, DateTime fyStartDate)
        {
            _validation = new Validation();
            _supportedFinancialYear = financialYear;
            _defaultStartDateOfFinancialYear = fyStartDate;
        }

        public void Run()
        {
            var employee = recordEmployeeDetails();
            var paymentStartDate = getStartDate();
            Helper.DisplayOutput("Your payslip has been generated:\n");
            Helper.DisplayOutput(new PaySlip(paymentStartDate, employee).Display());
            Helper.DisplayOutput("\nThank you for using MYOB!");

        }

        private Employee recordEmployeeDetails()
        {

            var firstName = getInput("first name");
            var lastName = getInput("last name");
            var annualSalary = decimal.Parse(getInput("annual salary"));
            var superRate = double.Parse(getInput("superannuation rate"));

            return new Employee(firstName, lastName, annualSalary, superRate);

        }

        private string getInput(string fieldName)
        {
            try
            {
                Helper.DisplayOutput($"Please enter your {fieldName}");

                return _validation.CheckFieldInput(Console.ReadLine(), fieldName);
            }
            catch (InputIsNotValidException e)
            {
                Helper.DisplayOutput(e.Message);

                return getInput(fieldName);
            }
        }

        private DateTime getStartDate()
        {
            try
            {
                Helper.DisplayOutput("Please enter payment start date in mm/dd/yyyy");
                var input = Console.ReadLine();
                return _validation.CheckPaymentStartDate(input,_supportedFinancialYear,_defaultStartDateOfFinancialYear);
            }
            catch (InputIsNotValidException e)
            {
                Helper.DisplayOutput(e.Message);
                return getStartDate();
            }
        }

    }
}
