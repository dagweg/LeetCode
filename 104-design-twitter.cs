public class Twitter {
    public Dictionary<int, HashSet<int>> Following = [];
    public Dictionary<int, List<(int,int)>> Posts =[];
    public int Time = 0;

    public Twitter(){}
    
    public void PostTweet(int userId, int tweetId) {
        if(Posts.ContainsKey(userId)) 
            Posts[userId].Add((Time,tweetId));
        else
            Posts[userId] = [(Time,tweetId)];
        Time += 1;
    }
    
    public IList<int> GetNewsFeed(int userId) {
        List<int> result = [];
        var maxHeap = new PriorityQueue<(int,int,int), int>(
            Comparer<int>.Create((x,y) => y.CompareTo(x))
        );
        
        if(!Following.ContainsKey(userId))
            Following[userId] = [userId];
        else
            Following[userId].Add(userId);
        
        foreach(var followeeId in Following[userId])
        {
            if (!Posts.TryGetValue(followeeId, out var followeePosts) || followeePosts.Count == 0) continue;
            int index = followeePosts.Count - 1;
            var (time, tweetId) = followeePosts[index];
            maxHeap.Enqueue((tweetId, followeeId, index-1), time);
        }
        while(maxHeap.Count > 0 && result.Count < 10){
            if(maxHeap.TryDequeue(out var res, out int time)){
                var (tweetId, followeeId, index) = res;
                result.Add(tweetId);
                if(index>=0 && Posts.TryGetValue(followeeId, out var followeePosts)){
                    var (t, twId) = followeePosts[index];
                    maxHeap.Enqueue((twId, followeeId, index-1), t);
                }
            }
        }
        return result;
    }   
    
    public void Follow(int followerId, int followeeId) {
        if(!Following.ContainsKey(followerId))  
            Following[followerId] = [followeeId];
        else 
            Following[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(Following.ContainsKey(followerId))
            Following[followerId].Remove(followeeId);
    }
}
