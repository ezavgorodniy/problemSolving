using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _393_IsValidUTF
{

    public class Solution
    {
        public bool ValidateByte(int data)
        {
            // valid byte is 1000 0000
            if ((data & 128) == 0)
            {
                // first bit is 0
                return false;
            }

            var maskForZero = ~(128 >> 1); // 1011 1111
            return (maskForZero | data) == maskForZero; // check second bit
        }

        public bool ValidUtf8(int[] data)
        {

            var curIndex = 0;
            while (curIndex < data.Length)
            {
                var cntFirstBits = 0;
                var curIterator = 128; // 1000 0000
                while ((data[curIndex] & curIterator) != 0)
                {
                    cntFirstBits++;
                    curIterator >>= 1;
                }

                if (cntFirstBits == 0)
                {
                    curIndex++;
                    continue;
                }
                if (cntFirstBits > 4 || cntFirstBits == 1)
                {
                    return false;
                }
                if (curIndex + cntFirstBits >= data.Length)
                {
                    return false;
                }
                for (int i = 1; i < cntFirstBits; i++)
                {
                    if (!ValidateByte(data[curIndex + i]))
                    {
                        return false;
                    }
                }
                curIndex += cntFirstBits;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            sln.ValidUtf8(new[] {236, 136, 145});
        }
    }
}
