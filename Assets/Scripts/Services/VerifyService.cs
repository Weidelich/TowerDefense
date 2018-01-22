using System;
using System.Text.RegularExpressions;

namespace Assets.Scripts.Services
{
    public class VerifyService
    {
        public static void VerifyString(string valStr)
        {
            if (String.IsNullOrEmpty(valStr) == true)
                throw new Exception("Логін не може бути порожній");
            if (Regex.IsMatch(valStr, @"^\w+$") == false)
                throw new Exception("Недопустиме ім'я");
        }
    }
}
