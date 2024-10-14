public class Solution {
    private int GridX = 0;
    private int GridY = 0;
    private Dictionary<(int,int), int> Memo = new();
  
    public int MinPathSum(int[][] grid) {
      GridX = grid.Length;
      GridY = grid[0].Length;
      return FindPath(grid, (0,0));
    }

    private int FindPath(int[][] grid, (int i, int j) pos){
      int i = pos.i, j = pos.j;
      if(i < 0 || i >= GridX || j < 0 || j >= GridY) return -1;

      if(Memo.TryGetValue(pos, out var mem)) return mem;

      if(i == GridX - 1 && j == GridY - 1) {
        return grid[i][j];
      }

      var bottom  = FindPath(grid, (i+1, j));
      var right = FindPath(grid, (i, j+1));

      Memo[pos] = grid[i][j] + 
      (bottom == -1 ? right : right == -1 ? bottom : Math.Min(bottom, right));

      return Memo[pos];
    }
}
