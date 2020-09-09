using System;
namespace BasicPaySlip
{
    public class InputIsNotValidException:Exception
    {
        public InputIsNotValidException(string message) : base(message)
        {
        }
    }
}
