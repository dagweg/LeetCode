public class Solution {
    
    private int Target;
    private IList<IList<int>> Result = new List<IList<int>>();
    
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
      Array.Sort(candidates);
      Target = target;
      Backtrack([], candidates, 0, 0);
      return Result;
    }

    private void Backtrack(IList<int> partial, int[] candidates, int sum, int start){
      for(int i = start; i < candidates.Length; i++){
        if(i > start && candidates[i-1] == candidates[i]) continue; // handle duplicates
        
        int curSum = sum + candidates[i];
        partial.Add(candidates[i]);

        if(curSum == Target)
          Result.Add(new List<int>(partial));
        if(curSum < Target)
          Backtrack(partial, candidates, curSum, i + 1);

        partial.RemoveAt(partial.Count - 1);
        if(curSum == Target || curSum > Target) break;
      }
    }
}
