using System.Collections.Generic;
using System.Linq;

namespace Tweeter
{
    public class Twitter
    {
        private Dictionary<int, List<TweetDescription>> _tweets = new Dictionary<int, List<TweetDescription>>();
        private Dictionary<int, List<int>> _followers = new Dictionary<int, List<int>>();

        private class TweetDescription
        {
            private static int CurrentTweetDescriptionNumber = 0;

            public int TimestampNumber { get; private set; }

            public int TweetId { get; private set; }

            public TweetDescription(int tweetId)
            {
                TweetId = tweetId;

                // TODO: add some locks            
                TimestampNumber = CurrentTweetDescriptionNumber;
                CurrentTweetDescriptionNumber++;
            }
        }

        /** Initialize your data structure here. */
        public Twitter()
        {

        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {

            List<TweetDescription> userTweetsList;

            if (!_tweets.ContainsKey(userId))
            {
                userTweetsList = new List<TweetDescription>();
                _tweets.Add(userId, userTweetsList);
            }
            else
            {
                userTweetsList = _tweets[userId];
            }

            userTweetsList.Add(new TweetDescription(tweetId));
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            var followersList = GetFollowersList(userId).Distinct().ToList();
            followersList.Add();
            var followersListLength = followersList.Count();

            var currentIndexes = new int[followersListLength + 1];
            var tweetsList = new List<TweetDescription>[followersListLength + 1];
            for (int i = 0; i < followersListLength; i++)
            {
                tweetsList[i] = _tweets[followersList[i]];
                currentIndexes[i] = tweetsList[i].Count() - 1;
            }
            tweetsList[followersListLength] = _tweets[userId];
            currentIndexes[followersListLength] = tweetsList[followersListLength].Count - 1;

            var result = new List<int>();
            bool tweetAdded;
            do
            {
                tweetAdded = false;
                int latestTweetTimestamp = -1;
                int indexOfAddedTweet = -1;
                int tweetId = -1;

                for (int i = 0; i < followersListLength + 1; i++)
                {
                    if (currentIndexes[i] >= 0)
                    {
                        var tweetCandidate = tweetsList[i][currentIndexes[i]];
                        if (tweetCandidate.TimestampNumber > latestTweetTimestamp)
                        {
                            latestTweetTimestamp = tweetCandidate.TimestampNumber;
                            indexOfAddedTweet = i;
                            tweetId = tweetCandidate.TweetId;
                        }
                    }
                }

                if (indexOfAddedTweet >= 0)
                {
                    tweetAdded = true;
                    result.Add(tweetId);
                    currentIndexes[indexOfAddedTweet]--;
                }

            }
            while (tweetAdded && result.Count() < 10);

            return result;
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            var followersList = GetFollowersList(followerId);
            followersList.Add(followeeId);
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            var followersList = GetFollowersList(followerId);
            followersList.Remove(followeeId);
        }

        private List<int> GetFollowersList(int userId)
        {
            List<int> followersList;
            if (!_followers.ContainsKey(userId))
            {
                followersList = new List<int>();
                _followers.Add(userId, followersList);
            }
            else
            {
                followersList = _followers[userId];
            }

            return followersList;
        }
    }

    /**
     * Your Twitter object will be instantiated and called as such:
     * Twitter obj = new Twitter();
     * obj.PostTweet(userId,tweetId);
     * IList<int> param_2 = obj.GetNewsFeed(userId);
     * obj.Follow(followerId,followeeId);
     * obj.Unfollow(followerId,followeeId);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Twitter twitter = new Twitter();

            // User 1 posts a new tweet (id = 5).
            twitter.PostTweet(1, 1);

            // User 1's news feed should return a list with 1 tweet id -> [5].
            var newsFeed = twitter.GetNewsFeed(1);

            // User 1 follows user 2.
            twitter.Follow(2, 1);

            // User 1's news feed should return a list with 2 tweet ids -> [6, 5].
            // Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
            newsFeed = twitter.GetNewsFeed(1);

            // User 1 unfollows user 2.
            twitter.Unfollow(2, 1);

            // User 1's news feed should return a list with 1 tweet id -> [5],
            // since user 1 is no longer following user 2.
            newsFeed = twitter.GetNewsFeed(2);
        }
    }
}
