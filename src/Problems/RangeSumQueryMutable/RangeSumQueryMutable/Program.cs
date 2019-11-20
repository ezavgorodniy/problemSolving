using System;

namespace RangeSumQueryMutable
{
    public class NumArray
    {
        private readonly int[][] _sumTree;

        public NumArray(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException("nums");
            }

            if (nums.Length == 1)
            {
                _sumTree = new int[1][];
                _sumTree[0] = new [] {nums[0]};
                return;
            }

            var treeVerticalSize = 1;
            while (1 << treeVerticalSize < nums.Length)
            {
                treeVerticalSize++;
            }
             
            _sumTree = new int[treeVerticalSize + 1][];
            _sumTree[0] = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                _sumTree[0][i] = nums[i];
            }

            var currentLevelIndex = 1;
            while (_sumTree[currentLevelIndex - 1].Length > 1)
            {
                var prevArraySize = _sumTree[currentLevelIndex - 1].Length;
                var currentArraySize = prevArraySize / 2 + prevArraySize % 2;
                _sumTree[currentLevelIndex] = new int[currentArraySize];
                for (int i = 0; i < prevArraySize / 2; i++)
                {
                    _sumTree[currentLevelIndex][i] =
                        _sumTree[currentLevelIndex - 1][i * 2] + _sumTree[currentLevelIndex - 1][i * 2 + 1];
                }
                if (prevArraySize % 2 == 1)
                {
                    _sumTree[currentLevelIndex][prevArraySize / 2] =
                        _sumTree[currentLevelIndex - 1][prevArraySize - 1];
                }
                currentLevelIndex++;
            }

        }

        public void Update(int i, int val)
        {
            var delta = _sumTree[0][i] - val;
            for (int level = 0; level < _sumTree.Length; level++)
            {
                var currentLevelStep = 1 << level;
                _sumTree[level][i / currentLevelStep] -= delta;
            }
        }

        private Tuple<int, int> GetInterval(int index, int currentLevel)
        {
            var currentLevelStep = 1 << currentLevel;
            var left = index * currentLevelStep;
            var right = Math.Min((index + 1) * currentLevelStep - 1, _sumTree[0].Length - 1);

            return new Tuple<int, int>(left, right);
        }

        public int SumRange(int left, int right, int currentLevel)
        {
            if (left > right)
            {
                return 0;
            }

            var currentLevelStep = 1 << currentLevel;
            var leftOnTheLevel = left / currentLevelStep;
            var rightOnTheLevel = right / currentLevelStep;
            if (leftOnTheLevel == rightOnTheLevel)
            {
                var interval = GetInterval(leftOnTheLevel, currentLevel);
                if (interval.Item1 == left && interval.Item2 == right)
                {
                    return _sumTree[currentLevel][leftOnTheLevel];
                }

                return SumRange(left, right, currentLevel - 1);
            }

            var leftInterval = GetInterval(leftOnTheLevel, currentLevel);
            var rightInterval = GetInterval(rightOnTheLevel, currentLevel);
            return SumRange(left, leftInterval.Item2, currentLevel) + SumRange(rightInterval.Item1, right, currentLevel);
        }

        public int SumRange(int i, int j)
        {
            return SumRange(i, j, _sumTree.Length - 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var numArray = new NumArray(new [] {-1});
            Console.WriteLine(numArray.SumRange(0, 0));
            numArray.Update(0, 1);
            Console.WriteLine(numArray.SumRange(0, 0));
        }
    }
}
