public class Solution {

    public IList<IList<int>> PermuteUnique(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Backtrack([], nums.ToList(), result);
        return result;
    }

    private void Backtrack(List<int> acc, List<int> rem, IList<IList<int>> result){
        if(rem.Count == 0) // backtrack
        {
            result.Add(new List<int>(acc));
            return;
        }

        var set = new HashSet<int>();

        for(int i = 0 ; i < rem.Count(); i++){
            var elem = rem[i];

            if(set.Contains(elem)) continue;
            set.Add(elem);

            acc.Add(elem);
            rem.RemoveAt(i);
            
            Backtrack(acc, rem, result);

            // Revert 
            acc.RemoveAt(acc.Count - 1);
            rem.Insert(i, elem);
        }
    }
}
