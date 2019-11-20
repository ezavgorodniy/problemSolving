using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hired
{

    public class ChallengeTreeSize
    {
        private const string LeftAnswer = "Left";
        private const string RightAnswer = "Right";
        private const string EqualAnswer = "";

        public static string Solution(long[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length <= 1)
            {
                return EqualAnswer;
            }

            long leftTreeSum = 0;
            long rightTreeSum = 0;

            int level = 1;
            while (1 << level - 1 < arr.Length)
            {
                int startLevel = (1 << level) - 1;
                int endLevel = Math.Min(startLevel + (1 << level) - 1, arr.Length - 1);

                int leftTreeEndLevel = Math.Min(startLevel + (1 << (level - 1)) - 1, arr.Length - 1);
                for (int i = startLevel; i <= leftTreeEndLevel; i++)
                {
                    if (arr[i] != -1)
                    {
                        leftTreeSum += arr[i];
                    }
                }

                for (int i = leftTreeEndLevel + 1; i <= endLevel; i++)
                {
                    if (arr[i] != -1)
                    {
                        rightTreeSum += arr[i];
                    }
                }

                level++;
            }

            if (leftTreeSum > rightTreeSum)
            {
                return LeftAnswer;
            }
            else if (leftTreeSum == rightTreeSum)
            {
                return EqualAnswer;
            }
            else
            {
                return RightAnswer;
            }
        }
    }


    public class ChallengeLongestSubstring
    {
        public static long Solution(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (s.Length == 0)
            {
                return 0;
            }

            int currentLength = 1;
            int result = 1;

            int i;
            var visited = new int[256];
            for (i = 0; i < 256; i++)
            {
                visited[i] = -1;
            }

            visited[s[0]] = 0;

            for (i = 1; i < s.Length; i++)
            {
                var prevIndex = visited[s[i]];

                if (prevIndex == -1 || i - currentLength > prevIndex)
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > result)
                    {
                        result = currentLength;
                    }

                    currentLength = i - prevIndex;
                }

                visited[s[i]] = i;
            }

            if (currentLength > result)
            {
                result = currentLength;
            }

            return result;
        }

    }

    public class Challenge
    {
        public static long Solution(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (s.Length == 0)
            {
                return 0;
            }

            var appearance = new bool[256];
            int leftIndex = 0;
            int rightIndex = 1;
            int result = 1;
            appearance[(int)s[0]] = true;
            while (rightIndex < s.Length)
            {
                if (appearance[(int)s[rightIndex]])
                {
                    int potentialResult = rightIndex - leftIndex;
                    if (potentialResult > result)
                    {
                        result = potentialResult;
                    }


                    do
                    {
                        appearance[(int)s[leftIndex]] = false;
                        leftIndex++;
                    }
                    while (s[leftIndex] != s[rightIndex]);
                }

                appearance[(int)s[rightIndex]] = true;
                rightIndex++;
            }

            if (rightIndex - leftIndex > result)
            {
                return rightIndex - leftIndex;
            }
            else
            {
                return result;
            }
            // Type your solution here
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(ChallengeTreeSize.Solution(new long []{1,4,100,5}));
            Console.WriteLine(ChallengeLongestSubstring.Solution("nndfddf"));
        }
    }
}
