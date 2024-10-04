public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Backtrack([], nums.ToList(), result);
        return result;
    }

    private static void Backtrack(List<int> acc, List<int> rem, IList<IList<int>> result){
        if(rem.Count == 0){ // Backtrack criterion
            result.Add(new List<int>(acc));
            return;
        }

        for(int i = 0; i < rem.Count; i++){
            var toRemove = rem[i];
            acc.Add(toRemove);
            rem.RemoveAt(i);

            Backtrack(acc, rem, result);
            
            //Revert
            rem.Insert(i, toRemove);
            acc.RemoveAt(acc.Count - 1);
        }
    }
}
