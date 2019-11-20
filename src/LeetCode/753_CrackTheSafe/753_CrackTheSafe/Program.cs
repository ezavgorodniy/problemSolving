using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _753_CrackTheSafe
{
    public class Solution
    {
        /*class Solution {
public:
    string crackSafe(int n, int k) {
        int len = (int) pow(k, n - 1);
        vector<vector<bool>> visited(len, vector<bool>(k, false));
        
        string res = "";
        dfs(visited, res, len, k, 0);
        
        return res + string(n - 1, '0');
    }
    
    void dfs(vector<vector<bool>>& visited, string& res, int len, int k, int node) {
        for (int i = 0; i < k; i++) {
            if (!visited[node][i]) {
                visited[node][i] = true;
                dfs(visited, res, len, k, (node * k + i) % len);
                res += '0' + i;
            }
        }
    }
};*/

        public string CrackSafe(int n, int k)
        {
            int len = (int) Math.Pow(k, n - 1);
            bool[][] visited = new bool[len][];
            for (int i = 0; i < len; i++)
            {
                visited[i] = new bool[k];
            }

            string res = "";
            Dfs(visited, ref res, len, k, 0);
            return res;
        }

        private void Dfs(bool[][] visited, ref string res, int len, int k, int node)
        {
            for (int i = 0; i < k; i++)
            {
                if (!visited[node][i])
                {
                    visited[node][i] = true;
                    Dfs(visited, ref res, len, k, (node * k + i) % len);
                    res += '0' + i.ToString();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.CrackSafe(2, 2));
        }
    }
}
