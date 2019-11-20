using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _528_RandomPickWithWeight
{
    public class Solution
    {

        private readonly int[] _ranges;
        private readonly Random _random;

        public Solution(int[] w)
        {
            _ranges = new int[w.Length + 1];
            _ranges[0] = 0;
            for (int i = 1; i <= w.Length; i++)
            {
                _ranges[i] = _ranges[i - 1] + w[i - 1];
            }

            _random = new Random();
        }

        public int PickIndex()
        {
            int maxValue = _ranges[_ranges.Length - 1];
            int random = _random.Next(maxValue);

            for (int i = 0; i <= maxValue; i++)
            {
                Search(i);
            }
            return Search(random);
        }

        private int Search(int val)
        {
            int l = 0;
            int r = _ranges.Length - 1;
            if (_ranges[0] <= val && val < _ranges[1])
            {
                return 0;
            }

            while (l <= r)
            {
                int m = (l + r) / 2;
                if (_ranges[m - 1] <= val && val < _ranges[m])
                {
                    return m - 1;
                }
                if (_ranges[m] <= val)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }
            return l;
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(w);
     * int param_1 = obj.PickIndex();
     */

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution(new int[] {1, 3, 4, 12});
            sln.PickIndex();
        }
    }
}
