using System;

namespace CircularArrayLoop
{
    public class Solution
    {
        public bool CircularArrayLoop(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != int.MaxValue)
                {
                    var currentLoopLength = 0;
                    var currentStep = i;
                    while (nums[currentStep] != int.MaxValue)
                    {
                        var newStep = currentStep + nums[currentStep];
                        if (newStep < 0)
                        {
                            newStep += nums.Length;
                        }
                        else
                        {
                            newStep %= nums.Length;
                        }

                        nums[currentStep] = int.MaxValue;
                        currentStep = newStep;
                        currentLoopLength++;
                    }

                    if (currentLoopLength > 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.CircularArrayLoop(new [] {-1, 2}));
        }
    }
}
