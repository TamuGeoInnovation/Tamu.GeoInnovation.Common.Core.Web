using System;
using System.Text;

namespace USC.GISResearchLab.Common.Core.Web.Payments.CreditCards
{
    public class CreditCardValidator
    {

        //--------------------------------
        // Filter out non-digit characters
        // -- this is from http://www.merriampark.com/anatomycc.htm
        //--------------------------------
        public static String GetDigitsOnly(String s)
        {
            StringBuilder digitsOnly = new StringBuilder();
            char c;
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                if (Char.IsDigit(c))
                {
                    digitsOnly.Append(c);
                }
            }
            return digitsOnly.ToString();
        }

        //-------------------
        // Perform Luhn check
        // -- this is from http://www.merriampark.com/anatomycc.htm
        //-------------------
        public static bool IsValid(String cardNumber)
        {
            String digitsOnly = GetDigitsOnly(cardNumber);
            int sum = 0;
            int digit = 0;
            int addend = 0;
            bool timesTwo = false;

            for (int i = digitsOnly.Length - 1; i >= 0; i--)
            {
                string s = digitsOnly.Substring(i, 1);
                digit = Convert.ToInt32(s);
                if (timesTwo)
                {
                    addend = digit * 2;
                    if (addend > 9)
                    {
                        addend -= 9;
                    }
                }
                else
                {
                    addend = digit;
                }
                sum += addend;
                timesTwo = !timesTwo;
            }

            int modulus = sum % 10;
            return modulus == 0;
        }
    }
}
