public class Solution {
  public int NumMatchingSubseq(string s, string[] words) {
    // Bucketing + Binary Search solution
    Dictionary<char,List<int>> bucket = [];
    
    // Populate the bucket
    for(int i = 0; i < s.Length; i++){
      if(!bucket.ContainsKey(s[i])) 
        bucket.Add(s[i], new List<int>());
      bucket[s[i]].Add(i);
    }
    
    int count = 0;
    for(int i = 0; i < words.Length; i++){
      if(HasMatchingSubsequence(bucket,words[i])) count++;
    }

    return count;
  }

  public bool HasMatchingSubsequence(Dictionary<char, List<int>> bucket, string word){
    int prevIndex = -1;
    for(int i = 0; i < word.Length; i++){
      var ch = word[i];
      if(!bucket.TryGetValue(ch, out var indices)) return false;
      
      prevIndex = BinarySearch(indices, prevIndex);
      if(prevIndex == -1) return false;
    }
    return true;
  }

  public int BinarySearch(List<int> indices, int prevIndex){
    int l = 0, r = indices.Count - 1;
    int m = 0;
    while(l <= r){
      m = l + (r - l) / 2;
      if(indices[m] > prevIndex) r = m - 1;
      else l = m + 1;
    }
    return l < indices.Count ? indices[l] : -1;
  }
}
