using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _855_ExamRoom
{
    public class ExamRoom
    {
        private readonly LinkedList<int> _occupiedSeats = new LinkedList<int>();
        private readonly int _seatsAmount = 0;
        private readonly Dictionary<int, LinkedListNode<int>> _seatsMap = new Dictionary<int, LinkedListNode<int>>();

        public ExamRoom(int N)
        {
            _seatsAmount = N;

        }

        public int Seat()
        {
            LinkedListNode<int> resultNode = null;
            if (_occupiedSeats.Count == 0)
            {
                resultNode = new LinkedListNode<int>(0);
                _occupiedSeats.AddFirst(resultNode);
            }
            else
            {
                int candidatePosition = -1;
                int currentClosestResult = int.MinValue;
                LinkedListNode<int> nodeToInsertAfter = null;
                var curNode = _occupiedSeats.First;
                while (curNode != _occupiedSeats.Last)
                {
                    var nextNode = curNode.Next;
                    if (curNode.Value != nextNode.Value + 1)
                    {
                        var newPosition = (curNode.Value + nextNode.Value) / 2;
                        var currentResult = newPosition - curNode.Value;
                        if (currentResult > currentClosestResult)
                        {
                            nodeToInsertAfter = curNode;
                            candidatePosition = newPosition;
                            currentClosestResult = currentResult;
                        }
                    }

                    curNode = nextNode;
                }

                if (_occupiedSeats.Last.Value != _seatsAmount - 1)
                {
                    var currentResult = _seatsAmount - 1 - _occupiedSeats.Last.Value;
                    if (currentResult > currentClosestResult)
                    {
                        nodeToInsertAfter = _occupiedSeats.Last;
                        candidatePosition = _seatsAmount - 1;
                        currentClosestResult = currentResult;
                    }
                }

                var insertToStart = false;
                if (_occupiedSeats.First.Value != 0)
                {
                    var currentResult = _occupiedSeats.First.Value;
                    if (currentResult > currentClosestResult)
                    {
                        insertToStart = true;
                    }
                }

                if (insertToStart)
                {
                    resultNode = new LinkedListNode<int>(0);
                    _occupiedSeats.AddFirst(resultNode);
                }
                else
                {
                    resultNode = new LinkedListNode<int>(candidatePosition);
                    _occupiedSeats.AddAfter(nodeToInsertAfter, resultNode);
                }
            }

            _seatsMap.Add(resultNode.Value, resultNode);
            return resultNode.Value;
        }

        public void Leave(int p)
        {
            _occupiedSeats.Remove(_seatsMap[p]);
            _seatsMap.Remove(p);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             Input: ["ExamRoom","seat","seat","seat","seat","leave","seat"], [[10],[],[],[],[],[4],[]]
Output: [null,0,9,4,2,null,5]
             
             */
            //var examRoom = new ExamRoom(10);
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //examRoom.Leave(4); Console.WriteLine("Leave 4");
            //Console.WriteLine(examRoom.Seat());

            /*
             * ["ExamRoom","seat","seat","seat","leave","leave","seat","seat","seat","seat","seat","seat","seat","seat","seat","leave"]
[[10],[],[],[],[0],[4],[],[],[],[],[],[],[],[],[],[0]]*/

            //var examRoom = new ExamRoom(10);
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //examRoom.Leave(0); Console.WriteLine("Leave 0");
            //examRoom.Leave(4); Console.WriteLine("Leave 4");
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //Console.WriteLine(examRoom.Seat());
            //examRoom.Leave(0); Console.WriteLine("Leave 0");

            /*
["ExamRoom","seat","seat","seat","leave","leave","seat","seat","seat","seat","seat","seat","seat","seat","seat","leave","leave","seat","seat","leave","seat","leave","seat","leave","seat","leave","seat","leave","leave","seat","seat","leave","leave","seat","seat","leave"]
[[10],[],[],[],[0],[4],[],[],[],[],[],[],[],[],[],[0],[4],[],[],[7],[],[3],[],[3],[],[9],[],[0],[8],[],[],[0],[8],[],[],[2]]
             
             */

            var examRoom = new ExamRoom(10);
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            examRoom.Leave(0); Console.WriteLine("Leave 0");
            examRoom.Leave(4); Console.WriteLine("Leave 4");
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
            examRoom.Leave(0); Console.WriteLine("Leave 0");
            examRoom.Leave(4); Console.WriteLine("Leave 4");
            Console.WriteLine(examRoom.Seat());
            Console.WriteLine(examRoom.Seat());
        }
    }
}
