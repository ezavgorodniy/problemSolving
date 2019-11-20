using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _406_ReconstructQueue
{
    class Solution
    {
        //public int[][] reconstructQueue(int[][] people)
        //{
        //    Arrays.sort(people, (a, b)->a[0] == b[0] ? a[1] - b[1] : b[0] - a[0]);
        //    List<int[]> list = new LinkedList<>();
        //    for (int i = 0; i < people.length; i++)
        //    {
        //        list.add(people[i][1], people[i]);
        //    }
        //    int[][] res = new int[people.length][2];
        //    for (int i = 0; i < res.length; i++)
        //    {
        //        res[i] = list.get(i);
        //    }
        //    return res;
        //}

        private class QueuePosition
        {
            public int Height { get; set; }
            public int Position { get; set; }

        }

        public int[][] ReconstructQueue(int[][] people)
        {
            var pairs = from i in Enumerable.Range(0, people.Length)
                orderby people[i][0] descending, people[i][1]
                select new QueuePosition
                {
                    Height = people[i][0],
                    Position = people[i][1]
                };

            var resultList = new List<QueuePosition>();
            foreach (var p in pairs)
            {
                resultList.Insert(p.Position, p);
            }

            for (var i = 0; i < people.GetLength(0); i++)
            {
                people[i][0] = resultList[i].Height;
                people[i][1] = resultList[i].Position;
            }

            return people;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
