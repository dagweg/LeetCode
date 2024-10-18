public class Solution {
    private int Target;
    private IList<IList<int>> Result = new List<IList<int>>();

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Target = target;
        Array.Sort(candidates); // Helps in pruning later on
        Backtrack(new List<int>(), candidates, 0, 0);
        return Result;
    }

    public void Backtrack(IList<int> partial, int[] candidates, int sum, int start) {
      for(int i = start; i < candidates.Length; i++){
        int newSum = sum + candidates[i];

        partial.Add(candidates[i]);
        if(newSum == Target){
          Result.Add(new List<int>(partial));
        }
        else if(newSum < Target){
          Backtrack(partial, candidates, newSum, i);
        }

        partial.RemoveAt(partial.Count - 1);
        if(newSum == Target || newSum > Target) break;
      }
    }
}
