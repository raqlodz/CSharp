using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringOperations
{
    class Program
    {
        static decimal value1, value2, result;
        static string oper;
        Expression expr;

        


        static void Main(string[] args)
        {
            char[] delimiters = new char[] { '*', '/' , '+', '-' };

            string input = "-2.5*-35.";

            String pattern = @"([-+]?\d+.?\d*)\s*([-+*/])\s*([-+]?\d+.?\d*)";

            Console.WriteLine(input);

            foreach (Match m in Regex.Matches(input, pattern))
            {
                value1 = Decimal.Parse(m.Groups[1].Value);
                oper = m.Groups[2].Value;
                value2 = Decimal.Parse(m.Groups[3].Value);
            }
            Console.WriteLine("Arg1: {0}, Operator: {1}, Arg2: {2}", value1, oper, value2);

            switch (oper)
            {
                case "+":
                    result = value1 + value2;
                    break;

                case "-":
                    result = value1 - value2;
                    break;

                case "*":
                    result = value1 * value2;
                    break;

                case "/":
                    result = value1 / value2;
                    break;
            }

            Console.WriteLine("Result: {0}", result.ToString());

            Console.ReadKey();
        }
    }
}
