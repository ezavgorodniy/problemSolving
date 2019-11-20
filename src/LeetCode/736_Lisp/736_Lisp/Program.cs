using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _736_Lisp
{
    public class Solution
    {
        public int Evaluate(string expression)
        {
            var locks = new HashSet<string>();
            locks.Con

            int i = 0;
            return EvaluateInternal(ref i, expression, new Dictionary<string, int>());
        }

        public int EvaluateInternal(ref int i, string str, Dictionary<string, int> scopedvalues)
        {
            if (string.IsNullOrEmpty(str) || i >= str.Length) return 0;
            if (str[i] == '(') i++;
            string operation = ""; //Find out what operation it is, this remains constant for this frame of recursion.
            while (i < str.Length && str[i] != ' ')
            {
                operation += str[i];
                i++;
            }
            i++;
            var current_scopedvalues = new Dictionary<string, int>(scopedvalues);//using parents first

            while (i < str.Length && str[i] != ')') // Until you reeached the end of expression
            {
                var args = new object[2]; //There  are always 2 entites involved , only except for let statements when you have to return it
                for (int count = 0; count < 2; count++)
                {
                    if (str[i] == '(') //It is an expression evaluate it
                        args[count] = EvaluateInternal(ref i, str, current_scopedvalues);
                    else //Either it is a variable like x or a number
                    {
                        var temp = string.Empty;
                        while (i < str.Length && str[i] != ' ' && str[i] != ')')
                        {
                            temp += str[i];
                            i++;
                        }
                        args[count] = temp;
                    }

                    if (str[i] == ')') break; // If you have reached end, only applicable for let
                    i++;
                }
                switch (operation)
                {
                    case "let":
                        if (str[i] == ')')
                        {
                            i++;
                            return GetValue(args[0], current_scopedvalues);
                        }
                        var variable = args[0].ToString();//For let the first is always a variable
                        var value = GetValue(args[1], current_scopedvalues);
                        if (current_scopedvalues.ContainsKey(variable))
                            current_scopedvalues[variable] = value;
                        else
                            current_scopedvalues.Add(variable, value);
                        break;
                    case "add":
                    case "mult":
                        var first = GetValue(args[0], current_scopedvalues);
                        var second = GetValue(args[1], current_scopedvalues);
                        i++;
                        if (operation.Equals("add")) return first + second;
                        return first * second;
                    default:
                        break;
                }
            }
            return 0;
        }

        private int GetValue(object o, Dictionary<string, int> values)
        {
            //object o must be a number or a variable present in values
            int res = 0;
            if (int.TryParse(o.ToString(), out res))
            {
                return res;
            }

            return values[o.ToString()];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.Evaluate("(let x 2 (mult x (let x 3 y 4 (add x y))))"));
        }
    }
}
