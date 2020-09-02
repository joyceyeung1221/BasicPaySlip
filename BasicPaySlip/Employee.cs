using System;
namespace BasicPaySlip
{
    public class Employee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public decimal AnnualSalary { get; private set; }
        private double superRate;
        public double SuperRate
        {
            get { return superRate; }
            set
            {
                superRate = value / 100;
            }
        }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public Employee(string firstName, string lastName, decimal annualSalary, double superRate)
        {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperRate = superRate;

        }
    }
}
