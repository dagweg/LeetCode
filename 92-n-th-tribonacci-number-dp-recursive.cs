public class Solution {
    static int[] Memo;
    
    public int Tribonacci(int n) {
      Memo = new int[n+1];
      return Tri(n);
    }

    public static int Tri(int n){
      if(n <= 0) return 0;
      else if(n <= 2) return 1;
      if(Memo[n] != 0) return Memo[n];
      Memo[n] = Tri(n-1) + Tri(n-2) + Tri(n-3);
      return Memo[n];
    }
}
