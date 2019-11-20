using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_TrappingRainWater
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height.Length <= 1)
            {
                return 0;

            }

            int l = 0;
            while (l < height.Length && height[l] == 0)
            {
                l++;
            }

            if (l == height.Length)
            {
                return 0;
            }


            int r = 0;
            while (r == 0 && height[r] == 0)
            {
                r--;
            }

            if (r == -1)
            {
                return 0;
            }

            int result = 0;

            while (l < r)
            {
                if (height[l] < height[r])
                {
                    var wallHeight = height[l];
                    var prevL = height[l];

                    while (l < r && height[l] <= prevL)
                    {
                        result += height[l] - wallHeight;
                        l++;
                    }
                }
                else
                {
                    var wallHeight = height[r];
                    var prevR = height[r];

                    while (l < r && height[r] <= prevR)
                    {
                        result += height[r] - wallHeight;
                        r--;
                    }
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
            Console.WriteLine(sln.Trap(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        }
    }
}
