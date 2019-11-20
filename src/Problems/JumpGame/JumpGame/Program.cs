using System;

namespace JumpGame
{
    public class Solution
    {

        public void FillJumping(int currentStep, int[] nums, bool[] visited)
        {
            if (currentStep >= visited.Length)
            {
                return;
            }
            if (visited[visited.Length - 1])
            {
                return;
            }
            visited[currentStep] = true;

            for (int i = nums[currentStep]; i >= 0; i--)
            {
                FillJumping(currentStep + i, nums, visited);
                if (visited[visited.Length - 1])
                {
                    return;
                }
            }
        }

        public bool CanJump(int[] nums)
        {
            var resultJumping = new bool[nums.Length];
            FillJumping(0, nums, resultJumping);
            return resultJumping[nums.Length - 1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            sln.CanJump(new[] {3, 2, 1, 0, 4});
        }
    }
}
