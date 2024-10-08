public class Solution {
    
    static int[] Memo;

    public int Rob(int[] nums) {
      Memo = new int[nums.Length + 1];
      for(int i = 0; i < nums.Length + 1; i++) Memo[i] = -1;
      return Helper(nums, 0);
    }
    
    public int Helper(int[] nums, int start){
      if(start >= nums.Length) return 0;

      if(Memo[start] != -1) return Memo[start];

      int robHouse = nums[start] + Helper(nums, start + 2);
      int robNext = Helper(nums, start + 1);

      Memo[start] = Math.Max(robHouse, robNext);
      return Memo[start];
    }
}
