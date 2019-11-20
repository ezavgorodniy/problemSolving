using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _752_OpenTheLock
{
    public class Solution
    {
        private string WheelUp(char[] state, int index)
        {
            var prevState = state[index];

            if (prevState == '9')
            {
                state[index] = '0';
            }
            else
            {
                state[index]++;
            }

            var result = new string(state);
            state[index] = prevState;
            return result;
        }

        private string WheelDown(char[] state, int index)
        {
            var prevState = state[index];

            if (prevState == '0')
            {
                state[index] = '9';
            }
            else
            {
                state[index]--;
            }

            var result = new string(state);
            state[index] = prevState;
            return result;
        }

        private string[] NextStates(string curState)
        {
            var curStateArray = curState.ToCharArray();

            var result = new string[curStateArray.Length * 2];
            for (int i = 0; i < curStateArray.Length; i++)
            {
                result[i * 2] = WheelUp(curStateArray, i);
                result[i * 2 + 1] = WheelDown(curStateArray, i);
            }

            return result;

        }

        public int OpenLock(string[] deadends, string target)
        {
            var locks = new HashSet<string>(deadends);

            var result = new Dictionary<string, int>();
            result.Add("0000", 0);
            var queue = new Queue<string>();
            queue.Enqueue("0000");
            while (queue.Count != 0)
            {
                var currentState = queue.Dequeue();
                var newCount = result[currentState] + 1;

                if (locks.Contains(currentState))
                {
                    continue;
                }

                foreach (var nextState in NextStates(currentState))
                {
                    if (result.ContainsKey(nextState))
                    {
                        if (newCount < result[nextState])
                        {
                            result[nextState] = newCount;
                            queue.Enqueue(nextState);
                        }
                    }
                    else
                    {
                        result.Add(nextState, newCount);
                        queue.Enqueue(nextState);
                    }
                }
            }


            if (result.ContainsKey(target))
            {
                return result[target];
            }
            else
            {
                return -1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
