public class Solution {
    
    static int[] Dp;

    public int Rob(int[] nums) {
      int N = nums.Length;
      
      if(N == 1) return nums[0];
      if(N == 2) return Math.Max(nums[0],nums[1]);

      Dp = new int[N + 1];
      
      Dp[N] = 0;
      Dp[N-1] = nums[N-1];

      for(int i = N - 2; i >= 0; --i)
        Dp[i] = Math.Max(Dp[i+1], nums[i] + Dp[i+2]);
      
      return Dp[0];
    }
}
