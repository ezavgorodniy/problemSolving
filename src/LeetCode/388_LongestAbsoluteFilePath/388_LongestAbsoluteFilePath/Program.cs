using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _388_LongestAbsoluteFilePath
{

    public class Solution
    {
        public int LengthLongestPath(string input)
        {
            var folders = input.Split('\n');
            if (folders.Length == 0)
            {
                return 0;
            }

            int result = 0;
            string currentPath = folders[0];
            int lastTabsCount = 0;
            foreach (var folder in folders)
            {
                var curTabsCount = 0;
                for (int i = 0; i < folder.Length && folder[i] == '\t'; i++)
                {
                    curTabsCount++;
                }

                var trimmedFolder = folder.TrimStart('\t');
                if (curTabsCount > lastTabsCount)
                {
                    currentPath += "\\" + trimmedFolder;
                    lastTabsCount++;
                }
                else if (curTabsCount == lastTabsCount)
                {
                    if (lastTabsCount == 0)
                    {
                        currentPath = trimmedFolder;
                    }
                    else
                    {
                        currentPath = currentPath.Remove(currentPath.LastIndexOf("\\")) + "\\" + trimmedFolder;
                    }
                }
                else
                {
                    while (curTabsCount != lastTabsCount && lastTabsCount != 0)
                    {
                        currentPath = currentPath.Remove(currentPath.LastIndexOf("\\"));
                        lastTabsCount--;
                    }
                    if (lastTabsCount == 0)
                    {
                        currentPath = trimmedFolder;
                    }
                    else
                    {
                        
                        currentPath = currentPath.Remove(currentPath.LastIndexOf("\\")) + "\\" + trimmedFolder;
                    }
                }

                if (currentPath.Contains('.') && currentPath.Length > result)
                {
                    result = currentPath.Length;
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            Console.WriteLine(sln.LengthLongestPath("a\n\taa\n\t\taaa\n\t\t\tfile1.txt\naaaaaaaaaaaaaaaaaaaaa\n\tsth.png"));
        }
    }
}
