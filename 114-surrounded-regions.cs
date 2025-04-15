public class Solution {
    (int, int)[] dirs = [(0, 1), (1, 0), (-1, 0), (0, -1)];
    int ROWS;
    int COLS;

    public void Solve(char[][] board) {
        ROWS = board.Length;
        COLS = board[0].Length;

        if (ROWS < 3 || COLS < 3) return; // No need to contin
        var visited = new bool[ROWS, COLS];

        for (int i = 1; i < ROWS - 1; i++) {
            for (int j = 1; j < COLS - 1; j++) {
                if (board[i][j] == 'O' && !visited[i, j]) {
                    bool isSurrounded = true;
                    // Confirm its surrounded
                    Dfs(i, j, board, visited, ref isSurrounded);

                    // Fill the region
                    if (isSurrounded) { 
                        MarkRegion(i, j, board);
                    }
                }
            }
        }
    }

    bool Dfs(int i, int j, char[][] board, bool[,] visited, ref bool isSurrounded) {
        if (i < 0 || j < 0 || i >= ROWS || j >= COLS) {
            isSurrounded = false; 
            return false;
        }

        if (board[i][j] == 'X' || visited[i, j]) return true; 
        visited[i, j] = true;

        foreach (var (dx, dy) in dirs) {
            int ni = i + dx, nj = j + dy;
            Dfs(ni, nj, board, visited, ref isSurrounded);
        }

        return isSurrounded;
    }

    void MarkRegion(int i, int j, char[][] board) {
        if (i < 0 || j < 0 || i >= ROWS || j >= COLS || board[i][j] != 'O') return;

        board[i][j] = 'X';

        foreach (var (dx, dy) in dirs) {
            MarkRegion(i + dx, j + dy, board);
        }
    }
}
