public class Solution {
    public int CountSeniors(string[] details) {
        return details.Aggregate(0, (acc, cur) => int.Parse(cur.Substring(11,2)) > 60 ? acc + 1 : acc);
    }
}
