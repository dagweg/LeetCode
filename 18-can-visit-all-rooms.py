class Solution:
    def canVisitAllRooms(self, rooms: List[List[int]]) -> bool:
        visited = set([0]+rooms[0])
        q = deque(rooms[0])

        while q:
            ind = q.popleft()
            for elem in rooms[ind]:
                if elem not in visited:
                    visited.add(elem)
                    q.append(elem)
                
        return len(visited) == len(rooms)

