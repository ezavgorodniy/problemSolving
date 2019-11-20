using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _407_TrappingWater
{
    public class Solution
    {
        public int TrapRainWater(int[][] heightMap) 
        {
            /*FIRST STEP*/
            if (heightMap.Length == 0)
            {
                return 0;
            }

            var wetMap = new int[heightMap.Length][];
            for (int i = 0; i < heightMap.Length; i++)
            {
                wetMap[i] = new int[heightMap[0].Length];
            }

            int sum = 0;
            /*row by row*/
            for (int i = 1; i < wetMap.Length - 1; i++)
            {
                wetMap[i] = Calculate(heightMap[i]);
            }

            /*column by column*/
            for (int i = 1; i < heightMap[0].Length - 1; i++)
            {
                int[] col = new int[heightMap.Length];
                for (int j = 0; j < heightMap.Length; j++)
                {
                    col[j] = heightMap[j][i];
                }
                int[] colResult = Calculate(col);
                /*update the wetMap to be the bigger value between row and col, later we can spill, don't worry*/
                for (int j = 0; j < heightMap.Length; j++)
                {
                    wetMap[j][i] = Math.Max(colResult[j], wetMap[j][i]);
                    sum += wetMap[j][i];
                }
            }

            /*SECOND STEP*/
            var spillWater = true;
            int[] rowOffset = { -1, 1, 0, 0 };
            int[] colOffset = { 0, 0, 1, -1 };
            while (spillWater)
            {
                spillWater = false;
                for (int i = 1; i < heightMap.Length - 1; i++)
                {
                    for (int j = 1; j < heightMap[0].Length - 1; j++)
                    {
                        /*If this slot has ever gotten wet, exammine its 4 neightbors*/
                        if (wetMap[i][j] != 0)
                        {
                            for (int m = 0; m < 4; m++)
                            {
                                int neighborRow = i + rowOffset[m];
                                int neighborCol = j + colOffset[m];
                                int currentHeight = wetMap[i][j] + heightMap[i][j];
                                int neighborHeight = wetMap[neighborRow][neighborCol] +
                                                                  heightMap[neighborRow][neighborCol];
                                if (currentHeight > neighborHeight)
                                {
                                    int spilledWater = currentHeight - Math.Max(neighborHeight, heightMap[i][j]);
                                    wetMap[i][j] = Math.Max(0, wetMap[i][j] - spilledWater);
                                    sum -= spilledWater;
                                    spillWater = true;
                                }
                            }
                        }
                    }
                }
            }
            return sum;
        }

        /*Nothing interesting here, the same function for trapping water 1*/
        private int[] Calculate(int[] height)
        {
            var result = new int[height.Length];
            var s = new Stack<int>();
            int index = 0;
            while (index < height.Length)
            {
                if (s.Count == 0 || height[index] <= height[s.Peek()])
                {
                    s.Push(index++);
                }
                else
                {
                    int bottom = s.Pop();
                    if (s.Count != 0)
                    {
                        for (int i = s.Peek() + 1; i < index; i++)
                        {
                            result[i] += Math.Min(height[s.Peek()], height[index]) - height[bottom];
                        }
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
        }
    }
}
