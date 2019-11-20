using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _911_OnlineElection
{
    public class TopVotedCandidate
    {

        private readonly Dictionary<int, List<int>> _votesDictionary = new Dictionary<int, List<int>>();

        public TopVotedCandidate(int[] persons, int[] times)
        {
            for (int i = 0; i < persons.Length; i++)
            {
                List<int> candidateList;
                if (_votesDictionary.ContainsKey(persons[i]))
                {
                    candidateList = _votesDictionary[persons[i]];
                }
                else
                {
                    candidateList = new List<int>();
                    _votesDictionary.Add(persons[i], candidateList);
                }

                candidateList.Add(times[i]);
            }
        }

        public int Q(int t)
        {
            int resultVotes = int.MinValue;
            List<int> candidates = new List<int>();
            foreach (var votesPerson in _votesDictionary)
            {
                var currentVotes = CountVotes(votesPerson.Value, t);
                if (currentVotes >= resultVotes)
                {
                    if (candidates.Count != 0 && currentVotes != resultVotes)
                    {
                        candidates.Clear();
                    }

                    resultVotes = currentVotes;
                    candidates.Add(votesPerson.Key);
                }
            }

            var result = 0;
            var latest = _votesDictionary[candidates[0]][resultVotes - 1];
            for (int i = 1; i < candidates.Count; i++)
            {
                var curLatestTime = _votesDictionary[candidates[i]][resultVotes - 1];
                if (curLatestTime > latest)
                {
                    result = i;
                    latest = curLatestTime;
                }

            }

            return candidates[result];
        }

        private static int CountVotes(List<int> votesTimes, int curT)
        {
            if (votesTimes[0] > curT)
            {
                return 0;
            }

            int l = 0;
            int r = votesTimes.Count - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (votesTimes[m] > curT)
                {
                    r = m - 1;
                }
                else if (votesTimes[m] < curT)
                {
                    l = m + 1;
                }
                else
                {
                    return m + 1;
                }
            }

            if (votesTimes[r] < curT)
            {
                return r + 1;
            }
            return l + 1;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Input: ["TopVotedCandidate","q","q","q","q","q","q"], [[[],[]],[3],[12],[25],[15],[24],[8]]*/

            var topVotedCandidate =
                new TopVotedCandidate(new[] {0, 1, 1, 0, 0, 1, 0}, new[] {0, 5, 10, 15, 20, 25, 30});
            Console.WriteLine(topVotedCandidate.Q(3));
            Console.WriteLine(topVotedCandidate.Q(12));
            Console.WriteLine(topVotedCandidate.Q(25));
            Console.WriteLine(topVotedCandidate.Q(15));
            Console.WriteLine(topVotedCandidate.Q(24));
            Console.WriteLine(topVotedCandidate.Q(8));
        }
    }
}
