class Solution:
    def findDiagonalOrder(self, mat: List[List[int]]) -> List[int]:
        turn = 0 # 0 - upward 1 - downward
        answer = []
        ROWS = len(mat)
        COLS = len(mat[0])
        i = 0
        j = 0

        checkBoundary = lambda i, j: 0 <= i < ROWS and 0 <= j < COLS

        while i != ROWS - 1 or j != COLS - 1:
            # Handle upward traversal
            if turn == 0:
                """
                    Keep moving diagonally upward until you pass the valid boundary
                    Then decide where to start the diagonally downward traversal (right or bottom) from the current entry
                    Change the turn to 1
                """
                if checkBoundary(i,j):
                    answer.append(mat[i][j])
                else:
                    if checkBoundary(i+1,j):
                        i += 1
                    else:
                        i += 2
                        j -= 1
                    turn = 1
                    continue
                i -= 1
                j += 1
            # Handle Downward traversal
            else:
                """
                    The same as the above but inverted
                """
                if checkBoundary(i,j):
                    answer.append(mat[i][j])
                else:
                    if checkBoundary(i,j+1):
                        j += 1
                    else:
                        i -= 1
                        j += 2
                    turn = 0
                    continue
                i += 1
                j -= 1
        return answer + [mat[i][j]]

