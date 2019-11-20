using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _240_Search2dMatrix
{

    public class Solution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            List<int> remove;

            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);

            int left = 0, right = m - 1;
            int top = 0, bottom = n - 1;

            while (left <= right && top <= bottom)
            {
                bool changed = false;
                int verticalM = (left + right) / 2;
                if (matrix[top, verticalM] == target)
                {
                    return true;
                }
                if (matrix[top, verticalM] > target)
                {
                    right = verticalM;
                    changed = true;
                }

                if (left > right)
                {
                    break;
                }

                int horizontalM = (top + bottom) / 2;
                if (matrix[horizontalM, left] == target)
                {
                    return true;
                }
                if (matrix[horizontalM, left] > target)
                {
                    top = horizontalM;
                    changed = true;
                }

                if (!changed)
                {
                    
                }

                if (left == right && top == bottom)
                {
                    return matrix[left, top] == target;
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[5, 5];
            matrix[0, 0] = 1;
            matrix[0, 1] = 4;
            matrix[0, 2] = 7;
            matrix[0, 3] = 11;
            matrix[0, 4] = 15;

            matrix[1, 0] = 2;
            matrix[1, 1] = 5;
            matrix[1, 2] = 8;
            matrix[1, 3] = 12;
            matrix[1, 4] = 19;

            matrix[2, 0] = 3;
            matrix[2, 1] = 6;
            matrix[2, 2] = 9;
            matrix[2, 3] = 16;
            matrix[2, 4] = 22;

            matrix[3, 0] = 10;
            matrix[3, 1] = 13;
            matrix[3, 2] = 14;
            matrix[3, 3] = 17;
            matrix[3, 4] = 24;

            matrix[4, 0] = 18;
            matrix[4, 1] = 21;
            matrix[4, 2] = 23;
            matrix[4, 3] = 26;
            matrix[4, 4] = 30;

            var sln = new Solution();
            Console.WriteLine(sln.SearchMatrix(matrix, 20));
        }
    }
}
