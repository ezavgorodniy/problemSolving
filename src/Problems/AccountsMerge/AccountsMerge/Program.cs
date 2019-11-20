using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsMerge
{
    public class Solution
    {
        private class JavaLikeComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.CompareOrdinal(x, y);
            }
        }

        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var normalizedSet = new HashSet<string>();
            foreach (var account in accounts)
            {
                for (int i = 1; i < account.Count; i++)
                {
                    normalizedSet.Add($"{account[0]}:{account[i]}");
                }
            }

            var dict = new Dictionary<string, List<string>>();
            foreach (var emails in normalizedSet)
            {
                var parsedEmails = emails.Split(':');
                var accountName = parsedEmails[0];
                var email = parsedEmails[1];
                if (dict.ContainsKey(accountName))
                {
                    dict[accountName].Add(email);
                }
                else
                {
                    dict.Add(accountName, new List<string> {email});
                }
            }

            var result = new List<IList<string>>();
            foreach (var kvp in dict)
            {
                var mergedAccount = new List<string> {kvp.Key};

                var sortedEmails = kvp.Value.ToArray();
                Array.Sort(sortedEmails, new JavaLikeComparer());
                mergedAccount.AddRange(sortedEmails);
                result.Add(mergedAccount);
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var sln = new Solution();
            var mergedAccounts = sln.AccountsMerge(new List<IList<string>>
            {
                new List<string> {"John", "johnsmith@mail.com", "john00@mail.com"},
                new List<string> {"John", "johnnybravo@mail.com"},
                new List<string> {"John", "johnsmith@mail.com", "john_newyork@mail.com"},
                new List<string> { "Mary", "mary@mail.com" }
            });

            foreach (var account in mergedAccounts)
            {
                foreach (var email in account)
                {
                    Console.Write($"{email} ");
                }
                Console.WriteLine();
            }
        }
    }
}
