using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackWithQueue
{
    public class MyStack
    {
        private Queue<int> q1 = new Queue<int>();
        private Queue<int> q2 = new Queue<int>();
        private int top;

        /** Initialize your data structure here. */
        public MyStack()
        {

        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            q1.Enqueue(x);
            top = x;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            while (q1.Count != 1)
            {
                top = q1.Dequeue();
                q2.Enqueue(top);
            }
            top = q1.Dequeue();

            var tmp = q1;
            q1 = q2;
            q2 = tmp;
            return top;
        }

        /** Get the top element. */
        public int Top()
        {
            return top;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return q1.Count == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Top());
            Console.WriteLine(stack.Empty());
        }
    }
}
