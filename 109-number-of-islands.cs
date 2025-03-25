public class Solution {
    public int NumIslands(char[][] grid) {
        int rows = grid.Count(), 
            cols = grid[0].Count();
        bool[,] visited = new bool[rows,cols];
        (int i,int j)[] directions = [(-1,0),(1,0),(0,1),(0,-1)];
        void Explore(int i, int j) 
        {
            if(i < 0 || i >= rows || j < 0 || j >= cols ||
                visited[i, j] || grid[i][j] != '1')
                return;
            visited[i,j] = true;
            foreach(var dir in directions)
                Explore(i + dir.i, j + dir.j);
        }
        int res = 0;
        for(int i = 0 ; i < rows; i++) 
        for(int j = 0; j < cols ; j++){
            if(!visited[i,j] && grid[i][j] == '1')
            {
                res += 1;
                Explore(i,j);
            }
        }
        return res;
    }
}
