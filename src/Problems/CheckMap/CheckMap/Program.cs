using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMap
{

    public class Solution
    {
        private bool CheckMap(Dictionary<char, char> isoMap, char oneChar, char anotherChar)
        {

            if (isoMap.ContainsKey(oneChar))
            {
                if (isoMap[oneChar] != anotherChar)
                {
                    return false;
                }
            }
            else
            {
                isoMap.Add(oneChar, anotherChar);
            }
            return false;
        }


        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var toMap = new Dictionary<char, char>();
            var fromMap = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!CheckMap(toMap, s[i], t[i]) ||
                    !CheckMap(fromMap, t[i], s[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.IsIsomorphic("add", "eff"));
        }
    }
}
