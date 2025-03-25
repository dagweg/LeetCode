public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        List<int> cur = new List<int>();
        int count = nums.Count();
        Array.Sort(nums);

        void backtrack(int ptr){
            res.Add(cur.ToList());
            for(int i = ptr; i < count; i++){
                if(i > ptr && nums[i] == nums[i-1])  // duplicate skipping
                    continue;
                cur.Add(nums[i]);
                backtrack(i+1);
                cur.RemoveAt(cur.Count-1);
            }
        }
        backtrack(0);
        return res;
    }
}
