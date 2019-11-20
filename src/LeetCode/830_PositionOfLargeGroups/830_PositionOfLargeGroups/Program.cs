using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _830_PositionOfLargeGroups
{
    public class Solution
    {
        public IList<IList<int>> LargeGroupPositions(string S)
        {
            var result = new List<IList<int>>();
            if (S.Length > 0)
            {
                int index = 0;
                int lastIndex = index;
                while (index < S.Length)
                {
                    while (index < S.Length && S[index] == S[lastIndex])
                    {
                        index++;
                    }

                    if (lastIndex - index >= 3)
                    {
                        result.Add(new List<int> { lastIndex, index - 1 });
                    }

                    lastIndex = index;
                }
            }
            return result;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            sln.LargeGroupPositions("abbxxxxzzy");
        }
    }
}
