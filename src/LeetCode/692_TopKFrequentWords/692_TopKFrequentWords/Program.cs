using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _692_TopKFrequentWords
{
    public class Solution
    {
        public abstract class BaseIntHeap
        {
            protected int Capacity;
            protected int Size = 0;
            protected KeyValuePair<string, int>[] Items;

            protected BaseIntHeap(int capacity)
            {
                Capacity = capacity;
                Items = new KeyValuePair<string, int>[capacity];
            }

            protected int GetLeftChildIndex(int parentIndex)
            {
                return 2 * parentIndex + 1;
            }
            protected int GetRightChildIndex(int parentIndex)
            {
                return 2 * parentIndex + 2;
            }

            protected int GetParentIndex(int childIndex)
            {
                return (childIndex - 1) / 2;
            }

            protected bool HasLeftChild(int index)
            {
                return GetLeftChildIndex(index) < Size;
            }

            protected bool HasRightChild(int index)
            {
                return GetRightChildIndex(index) < Size;
            }

            protected bool HasParent(int index)
            {
                return GetParentIndex(index) >= 0;
            }

            protected KeyValuePair<string, int> LeftChild(int index)
            {
                return Items[GetLeftChildIndex(index)];
            }

            protected KeyValuePair<string, int> RightChild(int index)
            {
                return Items[GetRightChildIndex(index)];
            }

            protected KeyValuePair<string, int> Parent(int index)
            {
                return Items[GetParentIndex(index)];
            }

            protected abstract void HeapifyDown();

            protected abstract void HeapifyUp();

            protected void Swap(int indexOne, int indexTwo)
            {
                var tmp = Items[indexOne];
                Items[indexOne] = Items[indexTwo];
                Items[indexTwo] = tmp;
            }

            protected void EnsureExtraCapacity()
            {
                if (Size != Capacity)
                {
                    return;
                }

                Array.Resize(ref Items, Capacity * 2);
                Capacity *= 2;
            }

            public KeyValuePair<string, int> Peek()
            {
                if (Size == 0)
                {
                    throw new Exception("Empty heap");
                }

                return Items[0];
            }

            public KeyValuePair<string, int> Pop()
            {
                if (Size == 0)
                {
                    throw new Exception("Empty heap");
                }

                KeyValuePair<string, int> item = Items[0];
                Items[0] = Items[Size - 1];
                Size--;

                HeapifyDown();

                return item;
            }

            public void Push(KeyValuePair<string, int> item)
            {
                EnsureExtraCapacity();
                Items[Size] = item;
                Size++;
                HeapifyUp();
            }
        }

        public class MaxIntHeap : BaseIntHeap
        {
            protected override void HeapifyDown()
            {
                int index = 0;
                while (HasLeftChild(index))
                {
                    int largerChildIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && RightChild(index).Value > LeftChild(index).Value ||
                        (RightChild(index).Value == LeftChild(index).Value &&
                         RightChild(index).Key.CompareTo(LeftChild(index).Key) < 0))
                    {
                        largerChildIndex = GetRightChildIndex(index);
                    }

                    if (Items[index].Value > Items[largerChildIndex].Value)
                    {
                        break;
                    }

                    Swap(index, largerChildIndex);
                    index = largerChildIndex;
                }
            }

            protected override void HeapifyUp()
            {
                int index = Size - 1;
                while (HasParent(index) && (Parent(index).Value < Items[index].Value) ||
                       (Parent(index).Value == Items[index].Value &&
                        Parent(index).Key.CompareTo(Items[index].Key) > 0))
                {
                    Swap(GetParentIndex(index), index);
                    index = GetParentIndex(index);
                }
            }

            public MaxIntHeap(int capacity) : base(capacity)
            {
            }
        }

        private Dictionary<string, int> BuildFrequencyDictionary(string[] words)
        {
            var result = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
                else
                {
                    result.Add(word, 1);
                }
            }
            return result;
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {
            var result = new List<string>();
            var heap = new MaxIntHeap(words.Length);

            var dictionary = BuildFrequencyDictionary(words);
            foreach (var pair in dictionary)
            {
                heap.Push(pair);
            }


            while (k > 0)
            {
                var nextResult = heap.Pop();
                result.Add(nextResult.Key + " " + nextResult.Value);
                k--;
            }
            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var result = sln.TopKFrequent(
                new[]
                {
                    "usy", "smxtodq", "qkgp", "rpedqk", "ckrugded", "gwmpk", "fkeaxawwjn", "dovsz", "dwahcjslgm",
                    "adgn", "mnuntjkpe", "cuos", "wphnandvi", "dwahcjslgm", "ujjyakxs", "qxuyuk", "lafdwvoiya",
                    "qxuyuk", "smxtodq", "mnuntjkpe", "qxuyuk", "lhwzxjirq", "gynnslkise", "lafdwvoiya", "ujjyakxs",
                    "magaxdvevb", "mnuntjkpe", "emtwd", "veali", "veali", "mmgrbtc", "xwsklj", "dovsz", "magaxdvevb",
                    "ckrugded", "cte", "fjv", "vyitfu", "mnuntjkpe", "vyitfu", "lhwzxjirq", "funvhz", "cte",
                    "lafdwvoiya", "dovsz", "funvhz", "mnuntjkpe", "wphnandvi", "ujjyakxs", "xamo", "rpedqk", "qkgp",
                    "ujjyakxs", "rpedqk", "lafdwvoiya", "cuos", "ouhzdjl", "wphnandvi", "emtwd", "dovsz", "ckrugded",
                    "xamo", "mnf", "dovsz", "mul", "mul", "bmyazxfu", "xwsklj", "cuos", "nbbilfc", "mnuntjkpe",
                    "ujjyakxs", "vyitfu", "cte", "fjv", "mul", "funvhz", "mmgrbtc", "ckrugded", "vyitfu", "xamo", "mul",
                    "gwmpk", "gxditf", "gwmpk", "ckrugded", "fjv", "nbbilfc", "ckrugded", "bmyazxfu", "xwsklj",
                    "veyeuz", "uacpj", "smxtodq", "eiitg", "emtwd", "ujjyakxs", "mnf", "veyeuz", "cte", "lafdwvoiya",
                    "ujjyakxs", "lhwzxjirq", "lafdwvoiya", "dwahcjslgm", "gwmpk", "veali", "wphnandvi", "nbbilfc",
                    "dwahcjslgm", "mnf", "mmgrbtc", "emtwd", "funvhz", "ckrugded", "fjv", "emtwd", "cuos", "dovsz",
                    "ujjyakxs", "xamo", "fjv", "nbbilfc", "qxuyuk", "qxuyuk", "xamo", "cte", "mnf", "xamo", "usy",
                    "wphnandvi", "lafdwvoiya", "emtwd", "lhwzxjirq", "cte", "mnuntjkpe", "veali", "xwsklj", "vyitfu",
                    "lhwzxjirq", "nbbilfc", "qxuyuk", "smxtodq", "ckrugded", "lafdwvoiya", "eiitg", "mnf", "vyitfu",
                    "dovsz", "qkgp", "xamo", "qxuyuk", "fkeaxawwjn", "dovsz", "emtwd", "nbbilfc", "gwmpk", "dovsz",
                    "fjv", "cte", "dovsz", "wphnandvi", "utjgg", "smxtodq", "lhwzxjirq", "funvhz", "hlqjzn", "fjv",
                    "eiitg", "mnf", "veyeuz", "utjgg", "cte", "smxtodq", "dwahcjslgm", "gynnslkise", "vyitfu", "cuos",
                    "veali", "mmgrbtc", "smxtodq", "usy", "fjv", "bbxab", "qxuyuk", "mmgrbtc", "dwahcjslgm",
                    "rcaixiptwx", "cte", "utjgg", "xamo", "funvhz", "xwsklj", "veyeuz", "lhwzxjirq", "lafdwvoiya",
                    "hlqjzn", "nbbilfc", "bmyazxfu", "smxtodq", "mmgrbtc", "eiitg", "qkgp", "xwsklj", "qkgp",
                    "lafdwvoiya", "emtwd", "hlqjzn", "rcrvhr", "qxuyuk", "veali", "vyitfu", "ouhzdjl", "uacpj",
                    "dnjdfc", "ckrugded", "funvhz", "wphnandvi", "cuos", "veyeuz"
                }, 40);

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }

            // ["dovsz","lafdwvoiya","ckrugded","cte","qxuyuk","emtwd","fjv","smxtodq","ujjyakxs","vyitfu","xamo","funvhz","lhwzxjirq","mnuntjkpe","nbbilfc","wphnandvi","cuos","dwahcjslgm","mmgrbtc","mnf","veali","xwsklj","gwmpk","qkgp","veyeuz","eiitg","mul","bmyazxfu","hlqjzn","rpedqk","usy","utjgg","fkeaxawwjn","gynnslkise","magaxdvevb","ouhzdjl","uacpj","adgn","bbxab","dnjdfc"]
        }
    }
}
