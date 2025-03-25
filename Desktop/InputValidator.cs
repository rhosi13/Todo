using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Desktop
{
    public class InputValidator
    {
        public bool IsValidEmail(string mail)
        {
            return Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public bool IsValidPassword(string password)
        {
            return password.Length >= 6;
        }
        public bool IsValidName(string name)
        {
            return name.Length >= 3;
        }
    }
}
