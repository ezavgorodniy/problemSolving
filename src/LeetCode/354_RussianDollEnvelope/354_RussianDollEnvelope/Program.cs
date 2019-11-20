using System;
using System.Collections;

namespace _354_RussianDollEnvelope
{
    public class Solution
    {
        private class CompareTwoEnvelop : IComparer
        {
            private readonly int _valueIndex;
            public CompareTwoEnvelop(int valueIndex)
            {
                _valueIndex = valueIndex;
            }

            public int Compare(object x, object y)
            {
                var xArr = x as int[];
                var yArr = y as int[];
                return xArr == null || yArr == null
                    ? (xArr == null && yArr == null ? 0 : (xArr == null ? -1 : 1))
                    : xArr[_valueIndex] - yArr[_valueIndex];
            }
        }

        private int GetLongestSubsequence<T>(T[] arr, IComparer comparer)
        {
            var dp = new int[arr.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparer.Compare(arr[i], arr[j]) >= 0)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            var result = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (dp[i] > result)
                {
                    result = dp[i];
                }
            }

            return result;
        }

        public int MaxEnvelopes(int[][] envelopes)
        {
            Array.Sort(envelopes, new CompareTwoEnvelop(1));
            return GetLongestSubsequence(envelopes, new CompareTwoEnvelop(0)); 

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var envelopes = new int[4][]
            {
                new[] {5, 4},
                new[] {6, 4},
                new[] {6, 7},
                new[] {2, 3}
            };

            var sln = new Solution();
            Console.WriteLine(sln.MaxEnvelopes(envelopes));

            /* [[5,4],[6,4],[6,7],[2,3]]*/
        }
    }
}
