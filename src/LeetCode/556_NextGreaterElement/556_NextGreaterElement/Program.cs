using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _556_NextGreaterElement
{
    public class Solution
    {
        private List<int> GetListPresentation(int n)
        {
            var lst = new List<int>();
            while (n != 0)
            {
                lst.Add(n % 10);
                n /= 10;
            }
            return lst;
        }

        private bool AllAsscending(List<int> results)
        {
            for (int i = results.Count - 1; i >= 1; i--)
            {
                if (results[i] > results[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private long ToLong(List<int> results)
        {
            long result = 0;
            for (int i = results.Count - 1; i >= 0; i--)
            {
                result = result * 10 + results[i];
            }
            return result;
        }

        private void Swap(List<int> lst, int i, int j)
        {
            var tmp = lst[i];
            lst[i] = lst[j];
            lst[j] = tmp;
        }

        private bool SecondElementExist(List<int> lst)
        {
            int firstElement = lst[0];
            foreach (var elem in lst)
            {
                if (elem != firstElement)
                {
                    return true;
                }
            }
            return false;
        }

        private void Sort(List<int> lst, int start)
        {
            int[] occurences = new int[10];
            for (int i = 0; i <= start; i++)
            {
                occurences[lst[i]]++;
            }

            for (int i = 0; i <= 9; i++)
            {
                while (occurences[i] > 0)
                {
                    lst[start] = i;
                    start--;
                    occurences[i]--;
                }
            }

        }

        public int NextGreaterElement(int n)
        {
            var lst = GetListPresentation(n);
            if (!SecondElementExist(lst))
            {
                return -1;
            }
            if (AllAsscending(lst))
            {
                Swap(lst, 0, 1);
            }
            else
            {
                int firstDigit = 1;
                while (firstDigit < lst.Count && lst[firstDigit] >= lst[firstDigit - 1])
                {
                    firstDigit++;
                }

                if (firstDigit == lst.Count)
                {
                    return -1;
                }

                int secondDigit = 0;
                for (int j = 0; j < firstDigit; j++)
                {
                    if (lst[j] < lst[secondDigit])
                    {
                        secondDigit = j;
                    }
                }

                Swap(lst, firstDigit, secondDigit);
                Sort(lst, firstDigit - 1);

            }

            long result = ToLong(lst);
            return result > int.MaxValue ? -1 : (int)result;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var number = "536749".ToString().ToCharArray();
            Array.Sort(number, 3,number.Length - 3);
            var sln = new Solution();
            Console.WriteLine(sln.NextGreaterElement(534976));
        }
    }
}
