using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _130_SurroundedRegion
{
    public class Solution
    {
        private void FillBoard(char[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length ||
                j < 0 || j >= board[i].Length ||
                board[i][j] != 'O')
            {
                return;
            }

            board[i][j] = 'o';

            FillBoard(board, i - 1, j);
            FillBoard(board, i + 1, j);
            FillBoard(board, i, j - 1);
            FillBoard(board, i, j + 1);
        }

        public void Solve(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                FillBoard(board, i, 0);
                FillBoard(board, i, board[0].Length - 1);
            }
            for (int j = 0; j < board.Length; j++)
            {
                FillBoard(board, 0, j);
                FillBoard(board, board.Length - 1, j);
            }

            foreach (var row in board)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (row[j] == 'o')
                    {
                        row[j] = 'O';
                    }
                    else if (row[j] == 'O')
                    {
                        row[j] = 'X';
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var board = new[]
            {
                new[] {'O', 'O', 'O', 'O', 'X', 'X'},
                new[] {'O', 'O', 'O', 'O', 'O', 'O'},
                new[] {'O', 'X', 'O', 'X', 'O', 'O'},
                new[] {'O', 'X', 'O', 'O', 'X', 'O'},
                new[] {'O', 'X', 'O', 'X', 'O', 'O'},
                new[] {'O', 'X', 'O', 'O', 'O', 'O'}
            };

            var sln = new Solution();
            sln.Solve(board);

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Console.Write(board[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
