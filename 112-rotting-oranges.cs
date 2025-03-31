public class Solution {
    public int OrangesRotting(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length; 
        var queue = new Queue<(int row, int col)>();
        int freshCount = 0;

        // Step 1: Enqueue rotten oranges and count fresh ones
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == 2) {
                    queue.Enqueue((i, j));
                } else if (grid[i][j] == 1) {
                    freshCount++;
                }
            }
        }

        if (freshCount == 0) return 0; // No fresh oranges, no time needed

        // Step 2: BFS to rot adjacent fresh oranges
        int minutes = 0;
        (int row, int col)[] directions = { (1, 0), (-1, 0), (0, 1), (0, -1) };

        while (queue.Count > 0) {
            int levelSize = queue.Count;
            bool rotted = false;

            for (int i = 0; i < levelSize; i++) {
                var (row, col) = queue.Dequeue();
                foreach (var (dr, dc) in directions) {
                    int newRow = row + dr;
                    int newCol = col + dc;
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && 
                        grid[newRow][newCol] == 1) {
                        grid[newRow][newCol] = 2; // Rot the orange
                        queue.Enqueue((newRow, newCol));
                        freshCount--;
                        rotted = true;
                    }
                }
            }
            if (rotted) minutes++;
        }

        // Step 3: Check for remaining fresh oranges
        return freshCount == 0 ? minutes : -1;
    }
}
