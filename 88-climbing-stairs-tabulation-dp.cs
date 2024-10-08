public class Solution {
    public static int[] Dp;
    
    public int ClimbStairs(int n) {
      Dp = new int[n+1];
      Dp[0] = 1; Dp[1] = 1;

      for(int i = 2; i <= n; i++){
        Dp[i] = Dp[i-1] + Dp[i-2];
      }

      return Dp[n];
    }
}
