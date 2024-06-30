class Solution:
    def orangesRotting(self, grid: List[List[int]]) -> int:
        q = collections.deque()
        fresh = 0
        n,m=len(grid),len(grid[0])
        for i in range(n):
            for j in range(m):
                if grid[i][j] == 1:
                    fresh+=1
                if grid[i][j] == 2:
                    q.append((i,j))
        minute = 0
        while q and fresh > 0:
            for _ in range(len(q)):
                i,j = q.popleft()
                for di, dj in [(0,1),(1,0),(0,-1),(-1,0)]:
                    ni,nj = i + di, j + dj
                    valid_bound = 0 <= ni < n and 0 <= nj < m 

                    if valid_bound and grid[ni][nj] == 1:
                        grid[ni][nj] = 2
                        fresh -= 1
                        q.append((ni,nj))
            minute += 1
        return minute if fresh == 0 else -1
