public class Solution {

    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        BacktrackSubset(new List<int>(), nums.ToList(), result, 0);
        return result;
    }

    private void BacktrackSubset(List<int> current, List<int> nums, IList<IList<int>> result, int start) {
        result.Add(new List<int>(current));

        for (int i = start; i < nums.Count; i++) {
            current.Add(nums[i]); 
            BacktrackSubset(current, nums, result, i + 1); 
            current.RemoveAt(current.Count - 1); 
        }
    }
}
