public class Solution {
    public int MinimumPushes(string word) {
        var charCount = word.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        var charSorted = charCount.OrderByDescending(kvp => kvp.Value).ToList();
        int ans = 0, mul = 1;
        for(var i = 0; i < charSorted.Count; i++){
            if(i == 8 * mul) mul++;
            ans += charSorted[i].Value * mul;
        }
        return ans;
    }
}
