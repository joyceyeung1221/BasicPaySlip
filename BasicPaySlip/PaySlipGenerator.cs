using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BasicPaySlip
{
    public class PaySlipGenerator
    {
        public PaySlipGenerator()
        {
        }

        public void Run()
        {
            var employee = recordEmployeeDetails();
            var paymentStartDate = getStartDate();
            write("Your payslip has been generated:\n");
            write(new PaySlip(paymentStartDate, employee).Display());
            write("\nThank you for using MYOB!");

        }

        private Employee recordEmployeeDetails()
        {

                var firstName = getInput("first name");
                var lastName = getInput("last name");
                var annualSalary = decimal.Parse(getInput("annual salary"));
                var superRate = double.Parse(getInput("superannuation rate"));

                return createEmployee(firstName, lastName, annualSalary, superRate);

        }

        private string getInput(string fieldName)
        {
            try
            {
                write($"Please enter your {fieldName}");
                return validateFieldInput(Console.ReadLine(),fieldName);
            }
            catch(InputIsNotValidException e)
            {
                write(e.Message);
                return getInput(fieldName);
            }
        }

        private DateTime getStartDate()
        {
            try
            {
            write("Please enter payment start date in mm/dd/yyyy");
            DateTime input;
            var date = DateTime.TryParse(Console.ReadLine(), out input);
            if (date == false)
                {
                    throw (new InputIsNotValidException("Please check date format"));
                }
                return input;
            } catch (InputIsNotValidException e)
                {
                    write(e.Message);
                    return getStartDate();
                }
        }

        private string validateFieldInput(string input, string fieldName)
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
                throw(new InputIsNotValidException("Invalid Input"));
            }
            else
            {
                return input;
            }
        }

        private Employee createEmployee(string firstName, string lastName, decimal annualSalary, double superRate)
        {
            return new Employee(firstName, lastName, annualSalary, superRate);
        }

        private void write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
