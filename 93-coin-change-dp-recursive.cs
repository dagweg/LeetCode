public class Solution {
    private static int[] Memo;
    public int CoinChange(int[] coins, int amount) {
      Memo = new int[amount + 1];
      Array.Fill(Memo, -2);
      return Helper(coins, amount);
    }

    private static int Helper(int[] coins, int rem){      
      if(rem == 0) return 0;
      else if(rem < 0) return -1;
      
      if(Memo[rem] != -2) return Memo[rem];

      var min = int.MaxValue;
      foreach(var coin in coins){
        var result = Helper(coins, rem - coin);
        if (result >= 0 && result < min) {  
            min = result + 1;  
        }
      }
      
      Memo[rem] = min == int.MaxValue ? -1 : min;
      return Memo[rem];
    }
}
