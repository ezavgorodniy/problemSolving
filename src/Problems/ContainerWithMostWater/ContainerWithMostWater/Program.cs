using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerWithMostWater
{
    class Program
    {

        private static int GetCurrentResult(int[] height, int left, int right)
        {
            if (left < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (right > height.Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (left >= right)
            {
                throw new Exception("Invalid boundaries");
            }

            return (right - left) * Math.Min(height[left], height[right]);


        }


        private static bool GetNextResult(int[] height, ref int left, ref int right)
        {
            var curLeftValue = height[left];
            while (left < height.Length && height[left] <= curLeftValue)
            {
                left++;
            }


            var curRightValue = height[right];
            while (right >= 0 && height[right] <= curRightValue)
            {
                right--;
            }

            return left > right && left < height.Length && right >= 0;
        }

        public static int MaxArea(int[] height)
        {
            var curLeft = 0;
            var curRight = height.Length - 1;
            var result = GetCurrentResult(height, curLeft, curRight);
            while (curLeft < curRight && GetNextResult(height, ref curLeft, ref curRight))
            {
                var newResult = GetCurrentResult(height, curLeft, curRight);
                if (newResult > result)
                {
                    result = newResult;
                }
            }

            return result;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(MaxArea(new int[] {1, 3, 1, 1, 1, 3, 1}));
        }
    }
}
