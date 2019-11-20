using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _341_FlattenNestedListIterator
{
    // This is the interface that allows for creating nested lists.
    // You should not implement it, or speculate about its implementation
    public interface NestedInteger
    {

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }

    public class NestedIntegerImpl : NestedInteger
    {
        public int Integer { get; set; }
        public bool IsInteger { get; set; }
        public List<NestedInteger> List { get; set; }

        bool NestedInteger.IsInteger()
        {
            return IsInteger;
        }

        public int GetInteger()
        {
            return Integer;
        }

        public IList<NestedInteger> GetList()
        {
            return List;
        }
    }



    public class NestedIterator
    {

        private NestedIterator _subNestedIterator;
        private int _curIndex;
        private IList<NestedInteger> _nestedList;

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            _curIndex = 0;
            _nestedList = nestedList;
        }

        public bool HasNext()
        {
            if (_curIndex >= _nestedList.Count)
            {
                return false;
            }

            if (_nestedList[_curIndex].IsInteger())
            {
                return true;
            }
            else
            {
                EnsureSubnestedIterator();
                if (!_subNestedIterator.HasNext())
                {
                    _curIndex++;
                    _subNestedIterator = null;
                }
                else
                {
                    return true;
                }

                return HasNext();
            }
        }

        public int Next()
        {
            if (_nestedList[_curIndex].IsInteger())
            {
                var result = _nestedList[_curIndex].GetInteger();
                _curIndex++;
                return result;
            }
            EnsureSubnestedIterator();

            if (_subNestedIterator.HasNext())
            {
                return _subNestedIterator.Next();
            }
            else
            {
                _curIndex++;
                _subNestedIterator = null;
                return Next();
            }
        }

        private void EnsureSubnestedIterator()
        {
            if (_subNestedIterator == null)
            {
                _subNestedIterator = new NestedIterator(_nestedList[_curIndex].GetList());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // [[1,1],2,[1,1]]
            var nestedIntegerList = new List<NestedInteger>
            {
                new NestedIntegerImpl
                {
                    IsInteger = false,
                    List = new List<NestedInteger>
                    {
                        new NestedIntegerImpl
                        {
                            IsInteger = true,
                            Integer = 1
                        },
                        new NestedIntegerImpl
                        {
                            IsInteger = true,
                            Integer = 1
                        }
                    }
                },
                new NestedIntegerImpl
                {
                    IsInteger = true,
                    Integer = 2
                },
                new NestedIntegerImpl
                {
                    IsInteger = false,
                    List = new List<NestedInteger>
                    {
                        new NestedIntegerImpl
                        {
                            IsInteger = true,
                            Integer = 1
                        },
                        new NestedIntegerImpl
                        {
                            IsInteger = true,
                            Integer = 1
                        }
                    }
                }
            };

            var iterator = new NestedIterator(nestedIntegerList);
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
