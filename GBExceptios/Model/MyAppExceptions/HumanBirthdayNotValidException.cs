using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Model.MyAppExceptions
{
    internal class HumanBirthdayNotValidException : Exception
    {
        public HumanBirthdayNotValidException(string message) : base(message)  { }
    }
}
