using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _929_UniqueEmails
{
    public class Solution
    {
        private string Normalize(string email)
        {
            var sb = new StringBuilder();
            int i = 0;
            bool firstSignMeet = false;
            bool atMeet = false;
            while (i < email.Length)
            {
                if (email[i] == '.' && atMeet)
                {
                    sb.Append(email[i]);
                }
                else if (email[i] == '@')
                {
                    sb.Append(email[i]);
                    atMeet = true;
                }
                else if (email[i] == '+' && !atMeet)
                {
                    while (email[i] != '@')
                    {
                        i++;
                    }

                    sb.Append(email[i]);
                    atMeet = true;
                }
                i++;
            }

            return sb.ToString();
        }

        public int NumUniqueEmails(string[] emails)
        {
            return emails
                .Select(Normalize)
                .Distinct()
                .Count();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.NumUniqueEmails(new[]
                {"fxggfzk.fo.q+e@uxbeyetxc.com", "fxggfzk.fo.q+h@uxbeyetxc.com", "uv+mw.lkw+ybe@yppz.com"}));
        }
    }
}
