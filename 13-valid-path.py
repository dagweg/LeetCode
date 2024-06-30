class Solution:
    def validPath(self, n: int, edges: List[List[int]], source: int, destination: int) -> bool:
        if n == 1:
            return True
        
        graph = collections.defaultdict(list)

        for u,v in edges:
            graph[u].append(v)
            graph[v].append(u)
        
        visited = set()
        q = collections.deque()

        q.append(source)

        while q:
            node = q.pop()
            for elem in graph[node]:
                if elem in visited:
                    continue
                if elem == destination:
                    return True
                q.append(elem)
                visited.add(elem)
        return False
