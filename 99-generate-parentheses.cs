public class Solution {
    private IList<string> Result = new List<string>();

    public IList<string> GenerateParenthesis(int n) {
      Backtrack(new StringBuilder(), n, n);
      return Result;
    }

    public void Backtrack(StringBuilder sb, int open, int close){
      if(open == 0 && close == 0){
        Result.Add(sb.ToString());
        return;
      }
      
      if(open > 0){
        sb.Append("(");
        Backtrack(sb, open - 1, close);
        sb.Remove(sb.Length - 1, 1);
      }
      
      if(close > open){
        sb.Append(")");
        Backtrack(sb, open, close - 1);
        sb.Remove(sb.Length - 1, 1);
      }
    }
}
