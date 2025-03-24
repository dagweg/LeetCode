public class Solution {
    public bool Exist(char[][] board, string word) {
        (int, int)[] directions = new (int, int)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

        int wordLength = word.Length;
        int m = board.Length;
        int n = board[0].Length;

        bool _Exists((int i, int j) entry, int wordIndex) {
            if (wordIndex >= wordLength)
                return true;
            if (entry.i < 0 || entry.i >= m || entry.j < 0 || entry.j >= n ||
               board[entry.i][entry.j] != word[wordIndex] ||
               board[entry.i][entry.j] == '#')
                return false;

            char originalChar = board[entry.i][entry.j];
            board[entry.i][entry.j] = '#';

            foreach (var (x, y) in directions) {
                int ni = entry.i + x, nj = entry.j + y;
                if (_Exists((ni, nj), wordIndex + 1)) {
                     board[entry.i][entry.j] = originalChar;
                    return true;
                }
            }

            board[entry.i][entry.j] = originalChar;
            return false;
        }

        for (int i = 0; i < m; i++) for (int j = 0; j < n; j++) // N * N * 4 ^ wordLength
            if (board[i][j] == word[0])
                if (_Exists((i, j), 0)) return true;
        return false;
    }
}
