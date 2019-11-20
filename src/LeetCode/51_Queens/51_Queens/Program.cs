using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_Queens
{
    public class Solution
    {
        private bool CheckBoard(char[] board, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i*n+j] == '.')
                    {
                        continue;
                    }

                    for (int k = 0; k < n; k++)
                    {
                        if (board[i*n+k] == 'Q' && k != j)
                        {
                            return false;
                        }
                    }

                    for (int k = 0; k < n; k++)
                    {
                        if (board[k*n+j] == 'Q' && k != i)
                        {
                            return false;
                        }
                    }

                    for (int k = 1; i + k < n && j + k < n; k++)
                    {
                        if (board[(i + k)*n + j + k] == 'Q')
                        {
                            return false;
                        }
                    }

                    for (int k = 1; i + k < n && j - k >= 0; k++)
                    {
                        if (board[(i + k)*n + j - k] == 'Q')
                        {
                            return false;
                        }
                    }

                    for (int k = 1; i - k >= 0 && j + k < n; k++)
                    {
                        if (board[(i - k) * n + j + k] == 'Q')
                        {
                            return false;
                        }
                    }

                    for (int k = 1; i - k >= 0 && j - k >= 0; k++)
                    {
                        if (board[(i - k)*n + j - k] == 'Q')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void SolveNQueensImpl(char[] flatBoard, int i, int n, int queensLeft, bool[] usedRows,
            bool[] usedColumns,
            HashSet<string> results)
        {
            if (queensLeft == 0)
            {
                var boardStr = new string(flatBoard);
                if (!results.Contains(boardStr))
                {
                    if (CheckBoard(flatBoard, n))
                    {
                        results.Add(boardStr);
                    }
                }
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (flatBoard[i * n + j] != '.' || usedRows[i] || usedColumns[j])
                {
                    continue;
                }

                usedRows[i] = true;
                usedColumns[j] = true;
                flatBoard[i * n + j] = 'Q';

                SolveNQueensImpl(flatBoard, i + 1, n, queensLeft - 1, usedRows, usedColumns, results);

                usedRows[i] = false;
                usedColumns[j] = false;
                flatBoard[i * n + j] = '.';
            }
        }

        public int TotalNQueens(int n)
        {
            var flatBoard = new char[n * n];
            for (int i = 0; i < n * n; i++)
            {
                flatBoard[i] = '.';
            }

            var usedColumns = new bool[n];
            var usedRows = new bool[n];

            var result = new HashSet<string>();
            SolveNQueensImpl(flatBoard, 0, n, n, usedRows, usedColumns, result);
            return result.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
                    Console.WriteLine(sln.TotalNQueens(4));
        }
    }
}
