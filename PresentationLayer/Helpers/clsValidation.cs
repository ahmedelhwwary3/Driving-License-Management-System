using BusinessLayer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PresentationLayer.Global
{
    public class clsValidation
    {
        public static bool IsValidEmail(string email)
        {
            // Regular expression for validating an email
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Use Regex.IsMatch to check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }
        public static bool IsValidEgyptianNumber(string PhoneNumber)
        {
            string Pattern = "^(010|011|012|015)\\d{8}$";
            return Regex.IsMatch(PhoneNumber, Pattern);
        }
        public static bool IsNumber(string NumberText)
        {
            int count = 0;
            foreach (char c in NumberText)
            {
                if (c == '.')
                    count++;
                if (!char.IsDigit(c)&&c!='.')
                    return false;
                if (count > 1)
                    return false;
            }
            return true;
        }


        internal static Boolean ValidateDateToAge<T>(T Object)
        {
            Type type = typeof(Object);

            foreach (var property in type.GetProperties())
            {
                // Check for RangeAttribute on properties
                if (Attribute.IsDefined(property, typeof(DateToAgeBetweenAttribute)))
                {

                    DateToAgeBetweenAttribute rangeAttribute = (DateToAgeBetweenAttribute)Attribute.GetCustomAttribute(property, typeof(RangeAttribute));
                    DateTime value = (DateTime)property?.GetValue(Object);
                    byte Age = (byte)(DateTime.Now.Year - value.Year);
                    if (Age < rangeAttribute.Min || Age > rangeAttribute.Max)
                    {
                        MessageBox.Show($"{rangeAttribute.ErrorMessage}!",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            }
            return true;
        }


    }
}
