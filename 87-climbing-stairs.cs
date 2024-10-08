public class Solution {
    int[] memo;
    
    public int ClimbStairs(int n) {
      memo = new int[n+1];
      return Enumerate(n);
    }

    public int Enumerate(int n){
      if(n == 0) return 1;
      else if(n < 0) return 0;

      if(memo[n] == 0)
        memo[n] = Enumerate(n - 1) + Enumerate(n - 2);
      
      return memo[n];
    }
}
