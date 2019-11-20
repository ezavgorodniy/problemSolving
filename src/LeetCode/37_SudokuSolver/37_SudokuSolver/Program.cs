using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _37_SudokuSolver
{
    public class Solution2
    {
        private class NumberStatus
        {
            public bool[] UsedInColumns = new bool[9];
            public bool[] UsedInRows = new bool[9];
            public bool[] UsedInSquares = new bool[9];

            public static int GetSquareNumber(int i, int j)
            {
                if (0 <= i && i <= 2)
                {
                    if (0 <= j && j <= 2)
                    {
                        return 0;
                    }
                    if (3 <= j && j <= 5)
                    {
                        return 1;
                    }
                    if (6 <= j && j <= 8)
                    {
                        return 2;
                    }
                }
                if (3 <= i && i <= 5)
                {
                    if (0 <= j && j <= 2)
                    {
                        return 3;
                    }
                    if (3 <= j && j <= 5)
                    {
                        return 4;
                    }
                    if (6 <= j && j <= 8)
                    {
                        return 5;
                    }
                }
                if (6 <= i && i <= 8)
                {
                    if (0 <= j && j <= 2)
                    {
                        return 6;
                    }
                    if (3 <= j && j <= 5)
                    {
                        return 7;
                    }
                    if (6 <= j && j <= 8)
                    {
                        return 8;
                    }
                }
                throw new ArgumentException(nameof(i));

            }

        }

        private const int AllChecked = (1 << 9) - 1;

        private bool CheckSquares(char[][] board)
        {
            for (int startIPoint = 0; startIPoint < 9; startIPoint += 3)
            {
                for (int startJPoint = 0; startJPoint < 9; startJPoint += 3)
                {
                    var currentChecks = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int val = board[startIPoint + i][startJPoint + j] - '1';
                            currentChecks |= (1 << val);
                        }
                    }

                    if (currentChecks != AllChecked)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckColumns(char[][] board)
        {
            for (int j = 0; j < 9; j++)
            {
                var currentChecks = 0;
                for (int i = 0; i < 9; i++)
                {
                    int val = board[i][j] - '1';
                    currentChecks |= (1 << val);
                }


                if (currentChecks != AllChecked)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckRows(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var currentChecks = 0;
                for (int j = 0; j < 9; j++)
                {
                    int val = board[i][j] - '1';
                    currentChecks |= (1 << val);
                }


                if (currentChecks != AllChecked)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckSudokuSolved(char[][] board)
        {
            return CheckSquares(board) && CheckColumns(board) && CheckRows(board);
        }

        private bool SolveSudokuImpl(char[][] board, bool[][] placeHolders, NumberStatus[] numberStatus, int numbersLeft)
        {
            if (numbersLeft == 0)
            {
                return CheckSudokuSolved(board);
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!placeHolders[i][j] || board[i][j] != '.')
                    {
                        continue;
                    }

                    for (char c = '1'; c <= '9'; c++)
                    {
                        var val = c - '1';
                        if (numberStatus[val].UsedInRows[i] ||
                            numberStatus[val].UsedInColumns[j] ||
                            numberStatus[val].UsedInSquares[NumberStatus.GetSquareNumber(i, j)])
                        {
                            continue;
                        }

                        var prevUsedInRows = numberStatus[val].UsedInRows[i];
                        var prevUsedInColumns = numberStatus[val].UsedInColumns[j];
                        var prevUsedInSquares = numberStatus[val].UsedInSquares[NumberStatus.GetSquareNumber(i, j)];
                        board[i][j] = c;

                        if (SolveSudokuImpl(board, placeHolders, numberStatus, numbersLeft - 1))
                        {
                            return true;
                        }

                        board[i][j] = '.';
                        numberStatus[val].UsedInRows[i] = prevUsedInRows;
                        numberStatus[val].UsedInColumns[j] = prevUsedInColumns;
                        numberStatus[val].UsedInSquares[NumberStatus.GetSquareNumber(i, j)] = prevUsedInSquares;
                    }
                }
            }

            return false;
        }

        public void SolveSudoku(char[][] board)
        {
            var placeHoldersCount = 0;
            var placeHolders = new bool[9][];
            var numberStatuses = new NumberStatus[9];
            for (int i = 0; i < 9; i++)
            {
                numberStatuses[i] = new NumberStatus();
            }
            for (int i = 0; i < 9; i++)
            {
                placeHolders[i] = new bool[9];
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        placeHoldersCount++;
                        placeHolders[i][j] = true;
                    }
                    else
                    {
                        int val = board[i][j] - '1';
                        numberStatuses[val].UsedInColumns[j] = true;
                        numberStatuses[val].UsedInRows[i] = true;
                        numberStatuses[val].UsedInSquares[NumberStatus.GetSquareNumber(i, j)] = true;

                    }
                }
            }

            SolveSudokuImpl(board, placeHolders, numberStatuses, placeHoldersCount);

        }
    }

    public class Solution3
    {

        private class SudokuChecker
        {
            private const int AllChecked = (1 << 9) - 1;
            private int _currentState = 0;

            public bool AddChar(char c)
            {
                if (c == '.')
                {
                    return true;
                }

                int val = c - '1';

                int mask = 1 << val;
                if ((_currentState & mask) != 0)
                {
                    return false;
                }

                _currentState |= (1 << val);
                return true;
            }

            public bool IsFull(char c)
            {
                return _currentState == AllChecked;
            }
        }

        private bool CheckSquares(char[][] board)
        {
            for (int startIPoint = 0; startIPoint < 9; startIPoint += 3)
            {
                for (int startJPoint = 0; startJPoint < 9; startJPoint += 3)
                {
                    var sudokuChecker = new SudokuChecker();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!sudokuChecker.AddChar(board[startIPoint + i][startJPoint + j]))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private bool CheckColumns(char[][] board)
        {
            for (int j = 0; j < 9; j++)
            {
                var sudokuChecker = new SudokuChecker();
                for (int i = 0; i < 9; i++)
                {
                    if (!sudokuChecker.AddChar(board[i][j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckRows(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var sudokuChecker = new SudokuChecker();
                for (int j = 0; j < 9; j++)
                {
                    if (!sudokuChecker.AddChar(board[i][j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckSudokuCorrect(char[][] board)
        {
            return CheckSquares(board) && CheckColumns(board) && CheckRows(board);
        }

        private bool SolveSudokuImpl(char[][] board, int numbersLeft)
        {
            var isCurrentSudokuCorrect = CheckSudokuCorrect(board);
            if (!isCurrentSudokuCorrect)
            {
                return false;
            }
            if (numbersLeft == 0)
            {
                return true;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        continue;
                    }

                    for (char c = '0'; c <= '9'; c++)
                    {
                        board[i][j] = c;

                        if (SolveSudokuImpl(board, numbersLeft - 1))
                        {
                            return true;
                        }

                        board[i][j] = '.';
                    }
                }
            }

            return false;
        }

        public void SolveSudoku(char[][] board)
        {
            var placeHoldersCount = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        placeHoldersCount++;
                    }
                }
            }

            SolveSudokuImpl(board, placeHoldersCount);

        }
    }

    public class Solution
    {
        public void SolveSudoku(char[][] board)
        {
            DoSolve(board, 0, 0);
        }

        private bool DoSolve(char[][] board, int row, int col)
        {
            for (int i = row; i < 9; i++, col = 0)
            { // note: must reset col here!
                for (int j = col; j < 9; j++)
                {
                    if (board[i][j] != '.') continue;
                    for (char num = '1'; num <= '9'; num++)
                    {
                        if (IsValid(board, i, j, num))
                        {
                            board[i][j] = num;
                            if (DoSolve(board, i, j + 1))
                            {
                                return true;
                            }
                            board[i][j] = '.';
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        private bool IsValid(char[][] board, int row, int col, char num)
        {
            int blkrow = (row / 3) * 3, blkcol = (col / 3) * 3; // Block no. is i/3, first element is i/3*3
            for (int i = 0; i < 9; i++)
            {
                if (board[i][col] == num || board[row][i] == num ||
                    board[blkrow + i / 3][blkcol + i % 3] == num)
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
            //var board = new[]
            //{
            //    new[] {'5', '3', '4', '6', '7', '8', '9', '1', '2'},
            //    new[] {'6', '7', '2', '1', '9', '5', '3', '4', '8'},
            //    new[] {'1', '9', '8', '3', '4', '2', '5', '6', '7'},
            //    new[] {'8', '5', '9', '7', '6', '1', '4', '2', '3'},
            //    new[] {'4', '2', '6', '8', '5', '3', '7', '9', '1'},
            //    new[] {'7', '1', '3', '9', '2', '4', '8', '5', '6'},
            //    new[] {'9', '6', '1', '5', '3', '7', '2', '8', '4'},
            //    new[] {'2', '8', '7', '4', '1', '9', '6', '.', '5'},
            //    new[] {'3', '4', '5', '2', '8', '6', '.', '7', '9'},
            //};
            var board = new[]
            {
                new[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'},
            };

            var sln = new Solution();
            sln.SolveSudoku(board);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
