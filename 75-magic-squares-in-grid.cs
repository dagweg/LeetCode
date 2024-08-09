public class Solution {
    int[][] Grid { get; set; }
    int Count { get; set; }

    public int NumMagicSquaresInside(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        Count = 0;
        Grid = grid;

        for (int i = 0; i <= rows - 3; i++) {
            for (int j = 0; j <= cols - 3; j++) {
                if (IsMagicSquare(i, j)) Count++;
            }
        }
        return Count;
    }

    private bool IsMagicSquare(int sx, int sy) {
        int[] nums = new int[9];
        int index = 0;

        // Check if the grid contains numbers from 1 to 9 exactly once
        HashSet<int> set = new HashSet<int>();
        for (int i = sx; i < sx + 3; i++) {
            for (int j = sy; j < sy + 3; j++) {
                int num = Grid[i][j];
                if (num < 1 || num > 9 || !set.Add(num)) {
                    return false;
                }
                nums[index++] = num;
            }
        }

        // Check sums of rows, columns, and diagonals
        int magicSum = 15;  // The magic constant for 3x3 magic square

        // Check rows
        for (int i = 0; i < 3; i++) {
            int rowSum = 0;
            for (int j = 0; j < 3; j++) {
                rowSum += Grid[sx + i][sy + j];
            }
            if (rowSum != magicSum) return false;
        }

        // Check columns
        for (int j = 0; j < 3; j++) {
            int colSum = 0;
            for (int i = 0; i < 3; i++) {
                colSum += Grid[sx + i][sy + j];
            }
            if (colSum != magicSum) return false;
        }

        // Check diagonals
        int diag1Sum = 0, diag2Sum = 0;
        for (int i = 0; i < 3; i++) {
            diag1Sum += Grid[sx + i][sy + i];  // top-left to bottom-right
            diag2Sum += Grid[sx + 2 - i][sy + i];  // top-right to bottom-left
        }

        if (diag1Sum != magicSum || diag2Sum != magicSum) return false;

        return true;
    }
}
