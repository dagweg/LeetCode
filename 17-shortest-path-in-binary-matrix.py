class Solution:
    def shortestPathBinaryMatrix(self, grid: List[List[int]]) -> int:
        N = len(grid)
        if grid[0][0] != 0 or grid[N-1][N-1] != 0: return -1
        
        q = deque([(0,0,0)]) # 3rd is distance
        visited = set((0,0))
        directions = [[1,1],[-1,-1],[0,1],[1,0],
                      [-1,1],[1,-1],[0,-1],[-1,0]]
        while q: 
            r, c, dist = q.popleft()
            if r == c == N-1: return dist + 1
            for dr, dc in directions:
                nr, nc = r + dr, c + dc
                if 0 <= nr < N and 0 <= nc < N and (nr, nc) not in visited and grid[nr][nc] == 0:
                    visited.add((nr, nc))
                    q.append((nr, nc, dist+1))
        return -1
        
        







