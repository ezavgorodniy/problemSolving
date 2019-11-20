using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _904_FruitInBaskets
{
    public class Solution
    {
        public int TotalFruit(int[] tree)
        {
            int l = 0;
            int leftestFirstFruit = l;
            int rightestFirstFruit = l;

            int r = 1;
            while (r < tree.Length && tree[r] == tree[l])
            {
                rightestFirstFruit = r;
                r++;
            }
            if (r == tree.Length)
            {
                return tree.Length;
            }

            int leftestSecondFruit = r;
            int rightestSecondFruit = r;
            while (r < tree.Length && (tree[r] == tree[l] || tree[r] == tree[leftestSecondFruit]))
            {
                if (tree[r] == tree[leftestSecondFruit])
                {
                    rightestSecondFruit = r;
                }
                else
                {
                    rightestFirstFruit = r;
                }

                r++;
            }

            int result = r - l;
            while (r < tree.Length)
            {
                if (rightestSecondFruit > rightestFirstFruit)
                {
                    l = rightestFirstFruit + 1;
                    leftestFirstFruit = l;
                    rightestFirstFruit = rightestSecondFruit;
                }
                else
                {
                    l = rightestSecondFruit + 1;
                    leftestFirstFruit = rightestSecondFruit;
                    rightestFirstFruit = rightestSecondFruit;
                }

                leftestSecondFruit = r;
                rightestSecondFruit = r;


                while (r < tree.Length && (tree[r] == tree[l] || tree[r] == tree[leftestSecondFruit]))
                {
                    if (tree[r] == tree[leftestSecondFruit])
                    {
                        rightestSecondFruit = r;
                    }
                    else
                    {
                        rightestFirstFruit = r;
                    }

                    r++;
                }

                if (r - l > result)
                {
                    result = r - l;
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
            Console.WriteLine(sln.TotalFruit(new[] {6, 2, 1, 1, 3, 6, 6}));
        }
    }
}
