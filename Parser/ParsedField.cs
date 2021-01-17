using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Parser
{
    public class ParsedField
    {
        public String NumerPola { get; set; }
        public String Uprawa { get; set; }
        public IList<String> NumeryDzialek { get; set; } = new List<String>();
        public Double CalkowitaPowierzchnia { get; set; }
        public override string ToString()
        {
            return NumerPola + "-" + Uprawa + "-" + String.Join(",", NumeryDzialek) + "-" + CalkowitaPowierzchnia/100.0 + "\n";
        }

        public static String FetchParcelNumber(String number)
        {
            //return Regex.Match(number, @"").ToString();
            return number.Remove(0, 14);
        }
    }
}
