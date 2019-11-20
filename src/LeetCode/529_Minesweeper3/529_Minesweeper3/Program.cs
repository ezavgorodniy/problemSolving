using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _529_Minesweeper3._529_Minesweeper;

namespace _529_Minesweeper3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace _529_Minesweeper
    {
        public class Solution
        {
            private char GetValue(char[][] c, int i, int j)
            {
                if (i < 0 || i >= c.Length || j < 0 || j >= c[0].Length)
                {
                    return ' ';
                }

                Guid.NewGuid().ToString()
                return c[i][j];
            }

            public char[][] UpdateBoard(char[][] board, int[] click)
            {
                if (board[click[0]][click[1]] == 'M')
                {
                    board[click[0]][click[1]] = 'X';
                    return board;
                }

                var moves = new[]
                {
                new[] { -1, -1},
                new[] { -1, 0},
                new[] { -1, 1},
                new[] { 0, -1},
                new[] { 0, 1},
                new[] { 1, -1},
                new[] { 1, 0},
                new[] { 1, 1},
            };

                Queue<int[]> points = new Queue<int[]>();
                points.Enqueue(click);
                while (points.Count != 0)
                {
                    var lastPoint = points.Dequeue();
                    if (board[lastPoint[0]][lastPoint[1]] != 'E')
                    {
                        continue;

                    }

                    var minesCount = 0;
                    foreach (var move in moves)
                    {
                        var nextValue = GetValue(board, lastPoint[0] + move[0], lastPoint[1] + move[1]);
                        if (nextValue == 'M')
                        {
                            minesCount++;
                        }
                    }

                    if (minesCount == 0)
                    {
                        board[lastPoint[0]][lastPoint[1]] = 'B';

                        foreach (var move in moves)
                        {
                            var nextValue = GetValue(board, lastPoint[0] + move[0], lastPoint[1] + move[1]);
                            if (nextValue == 'E')
                            {
                                points.Enqueue(new[] { lastPoint[0] + move[0], lastPoint[1] + move[1] });
                            }
                        }
                    }
                    else
                    {
                        board[lastPoint[0]][lastPoint[1]] = (char)('0' + minesCount);
                    }
                }

                return board;

            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var minesSweeper = new[]
            {
                "EEEEE".ToCharArray(),
                "EEMEE".ToCharArray(),
                "EEEEE".ToCharArray(),
                "EEEEE".ToCharArray(),
            };

            var sln = new Solution();
            var board = sln.UpdateBoard(minesSweeper, new[] {3, 0});

            foreach (var row in board)
            {
                Console.WriteLine(new string(row));
            }
        }
    }
}
