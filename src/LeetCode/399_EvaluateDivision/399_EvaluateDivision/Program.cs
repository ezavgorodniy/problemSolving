using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _399_EvaluateDivision
{

    public class Solution
    {
        private class Equation
        {
            public string Dividend { get; set; }

            public string Divisor { get; set; }

            public double Result { get; set; }
        }

        private class EquationGraph
        {
            private readonly Dictionary<string, IList<Equation>> _equations = new Dictionary<string, IList<Equation>>();

            public void AddEquation(Equation equation)
            {
                AddEquation(equation.Dividend, equation);
                AddEquation(equation.Divisor, equation);

            }

            public double Query(string dividend, string divisor)
            {
                if (!_equations.ContainsKey(dividend) || !_equations.ContainsKey(divisor))
                {
                    return -1.0;
                }
                if (dividend == divisor)
                {
                    return 1.0;
                }

                var chainEquations = BFS(dividend, divisor);
                if (chainEquations == null || chainEquations.Count == 0)
                {
                    return -1.0;
                }

                var curEquation = chainEquations[0];
                for (int i = 1; i < chainEquations.Count; i++)
                {
                    curEquation = MergeEquations(curEquation, chainEquations[i]);
                }

                return curEquation.Dividend == dividend ? curEquation.Result : 1 / curEquation.Result;
            }

            private void AddEquation(string variable, Equation equation)
            {
                IList<Equation> equationsList;
                if (_equations.ContainsKey(variable))
                {
                    equationsList = _equations[variable];
                }
                else
                {
                    equationsList = new List<Equation>();
                    _equations.Add(variable, equationsList);
                }

                equationsList.Add(equation);
            }

            private IList<Equation> BFS(string start, string end)
            {
                var queue = new Queue<IList<Equation>>();
                var visited = new HashSet<Equation>();
                foreach (var equation in _equations[start])
                {
                    visited.Add(equation);
                    queue.Enqueue(new List<Equation> {equation});
                }

                while (queue.Count != 0)
                {
                    var latestPath = queue.Dequeue();
                    var lastEquation = latestPath.Last();
                    if (lastEquation.Dividend == end || lastEquation.Divisor == end)
                    {
                        return latestPath;
                    }

                    ProcessEquationInBfs(visited, queue, latestPath, lastEquation.Dividend);
                    ProcessEquationInBfs(visited, queue, latestPath, lastEquation.Divisor);
                }

                return null;
            }

            private void ProcessEquationInBfs(HashSet<Equation> visited, Queue<IList<Equation>> queue,
                IList<Equation> curPath, string variable)
            {
                foreach (var equation in _equations[variable])
                {
                    if (visited.Contains(equation))
                    {
                        continue;
                    }

                    var newPath = new List<Equation>(curPath)
                    {
                        equation
                    };
                    queue.Enqueue(newPath);
                    visited.Add(equation);
                }
            }

            private Equation MergeEquations(Equation eq1, Equation eq2)
            {
                if (eq1.Divisor== eq2.Divisor)
                {
                    return new Equation
                    {
                        Dividend = eq2.Divisor,
                        Divisor = eq1.Divisor,
                        Result = eq2.Result / eq1.Result
                    };
                }
                if (eq1.Dividend == eq2.Dividend)
                {
                    return new Equation
                    {
                        Dividend = eq1.Divisor,
                        Divisor = eq2.Divisor,
                        Result = eq2.Result / eq1.Result
                    };
                }
                if (eq1.Dividend == eq2.Divisor)
                {
                    return new Equation
                    {
                        Dividend = eq2.Dividend,
                        Divisor = eq1.Divisor,
                        Result = eq1.Result * eq2.Result
                    };
                }
                if (eq1.Divisor == eq2.Dividend)
                {
                    return new Equation
                    {
                        Dividend = eq1.Dividend,
                        Divisor = eq2.Divisor,
                        Result = eq1.Result * eq2.Result
                    };
                }

                throw new ArgumentException("Unable to merge");
            }
        }

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var equationGraph = new EquationGraph();
            for (int i = 0; i < equations.Count; i++)
            {
                equationGraph.AddEquation(new Equation
                {
                    Dividend = equations[i][0],
                    Divisor = equations[i][1],
                    Result = values[i]
                });
            }

            return queries.Select(query => equationGraph.Query(query[0], query[1])).ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var equations = new List<IList<string>>
            {
                new List<string> {"a", "e"},
                new List<string> {"b", "e"}
            };
            var values = new[] { 4.0, 3.0 };
            var queries = new List<IList<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"e", "e"}
            };
            /*var equations = new List<IList<string>>
            {
                new List<string> {"x1", "x2"},
                new List<string> {"x2", "x3"},
                new List<string> {"x1", "x4"},
                new List<string> { "x2", "x5"}
            };
            var values = new[] { 3.0, 0.5, 3.4, 5.6 };
            var queries = new List<IList<string>>
            {
                // new List<string> {"x2", "x4"},
                new List<string> {"x1", "x5"},
                new List<string> {"x1", "x3"},
                new List<string> {"x5", "x5"},
                new List<string> {"x5", "x1"},
                new List<string> {"x3", "x4"},
                new List<string> {"x4", "x3"},
                new List<string> {"x6", "x6"},
                new List<string> {"x0", "x0"}
            };*/

            /*var equations = new List<IList<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"b", "c"},
                new List<string> {"c", "d"},
                new List<string> { "y", "z"}
            };

            var values = new[] {2.0, 3.0, 4.0, 42.0};
            var queries = new List<IList<string>>
            {
                new List<string> {"a", "c"},
                new List<string> {"c", "a"},
                new List<string> {"b", "a"},
                new List<string> {"a", "d"},
                new List<string> {"a", "e"},
                new List<string> {"a", "a"},
                new List<string> {"x", "x"},
                new List<string> {"y", "z"},
                new List<string> {"y", "a"}
            };*/
            foreach (var result in solution.CalcEquation(equations, values, queries))
            {
                Console.WriteLine(result);
            }
        }
    }
}
