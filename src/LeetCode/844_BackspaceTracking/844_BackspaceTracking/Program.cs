using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _844_BackspaceTracking
{
    public class Solution
    {
        private class StringIterator
        {
            private readonly string _s;
            private int _curIndex;
            private int _countBackspaces;

            public StringIterator(string s)
            {
                _s = s;
                _countBackspaces = 0;
                _curIndex = s.Length - 1;
            }

            public char Next()
            {
                while (_curIndex >= 0 && _s[_curIndex] == '#')
                {
                    while (_curIndex >= 0 && _s[_curIndex] == '#')
                    {
                        _curIndex--;
                        _countBackspaces++;
                    }

                    while (_curIndex >= 0 && _s[_curIndex] != '#' && _countBackspaces > 0)
                    {
                        _curIndex--;
                        _countBackspaces--;
                    }
                }

                if (_curIndex >= 0)
                {
                    var next = _s[_curIndex];
                    _curIndex--;
                    return next;
                }
                else
                {
                    return '*';
                }
            }

            public bool IsStringFinished()
            {
                return _curIndex < 0;
            }
        }

        public bool BackspaceCompare(string S, string T)
        {
            var sIterator = new StringIterator(S);
            var tIterator = new StringIterator(T);
            while (!sIterator.IsStringFinished() || !tIterator.IsStringFinished())
            {
                if (sIterator.Next() != tIterator.Next())
                {
                    return false;
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.BackspaceCompare("bxj##tw", "bxo#j##tw"));
        }
    }
}
