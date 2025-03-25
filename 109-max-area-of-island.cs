public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        bool[,] visited = new bool[rows,cols];

        int maxArea = 0;

        int IslandArea(int i, int j){
            if(i < 0 || i >= rows || j < 0 || j >= cols || 
                visited[i,j] || grid[i][j] == 0)
                return 0;
            
            visited[i,j]=true;

            return 1 + IslandArea(i+1,j) + IslandArea(i,j+1) +
                       IslandArea(i-1,j) + IslandArea(i,j-1);
        }

        for(int i = 0; i < rows; ++i)
        for(int j = 0 ; j < cols; ++j)
        if(!visited[i,j] && grid[i][j] == 1)
        maxArea = Math.Max(maxArea, IslandArea(i,j));

        return maxArea;
    }
}
