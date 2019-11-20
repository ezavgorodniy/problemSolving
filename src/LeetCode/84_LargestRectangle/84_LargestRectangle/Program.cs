using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _84_LargestRectangle
{
    public class Solution
    {
        /*
        int largestRectangleArea(vector<int>& height) {
            height.insert(height.begin(),0); // dummy "0" added to make sure stack s will never be empty
            height.push_back(0); // dummy "0" added to clear the stack at the end
            int len = height.size();
            int i, res = 0, idx;
            stack<int> s; // stack to save "height" index
            s.push(0); // index to the first dummy "0"
            for(i=1;i<len;i++)
            {
                while(height[i]<height[idx = s.top()]) // if the current entry is out of order
                {
                    s.pop();
                    res = max(res, height[idx] * (i-s.top()-1) ); // note how the width is calculated, use the previous index entry
                }
                s.push(i);
            }
            height.erase(height.begin()); // remove two dummy "0"
            height.pop_back();
            return res;
        }*/


        public int LargestRectangleArea(int[] heights)
        {
            var lst = new List<int>();
            lst.Add(0);
            lst.AddRange(heights);
            lst.Add(0);

            int res = 0, idx;
            Stack<int> s = new Stack<int>();
            s.Push(0);
            for (int i = 1; i < lst.Count; i++)
            {
                while (s.Count != 0 && i < lst.Count && heights[i] < heights[idx = s.Peek()])
                {
                    s.Pop();
                    if (s.Count != 0)
                    {
                        res = Math.Max(res, heights[idx] * (i - s.Peek() - 1));
                    }
                }
                s.Push(i);
            }

            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine( sln.LargestRectangleArea(new [] {2, 1, 5, 6, 2, 3}));
        }
    }
}
