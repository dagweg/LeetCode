public class Solution {
    int ROWS;
    int COLS;
    
    (int,int)[] dirs = [(0,1),(0,-1),(-1,0),(1,0)];

    bool WithinBounds(int i, int j) {
        return i < ROWS && i >= 0 && j < COLS && j >= 0;
    }
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        ROWS = heights.Length;
        COLS = heights[0].Length;

        if(ROWS == COLS && COLS == 1) return [[0,0]];

        var result = new List<IList<int>>();

        // reachable trackers
        var pr = new HashSet<(int,int)>();
        var ar = new HashSet<(int,int)>();

        // bfs queues
        var pq = new Queue<(int,int)>();
        var aq = new Queue<(int,int)>();

        for(int i = 0; i < ROWS; i++){
            pq.Enqueue((i,0));
            aq.Enqueue((i,COLS-1));
            pr.Add((i,0));
            ar.Add((i,COLS-1));
        }       

        for(int j = 0; j < COLS ; j++){
            pq.Enqueue((0,j));
            aq.Enqueue((ROWS-1,j));
            pr.Add((0,j));
            ar.Add((ROWS-1,j));
        }

        // do pacific side reverse traversal
        Bfs(pq,pr,heights);
    
        // do atlantic side reverse traversal
        Bfs(aq,ar,heights);

        return pr.Where(e => ar.Contains(e))
         .Select(e => (IList<int>)new List<int> { e.Item1, e.Item2 })
         .ToList<IList<int>>();

    }

    void Bfs(Queue<(int,int)> q, HashSet<(int,int)> r, int[][] h){
         while(q.Count > 0){
            (int i, int j) e = q.Dequeue();
            foreach(var dir in dirs){
                (int x, int y) n = dir;
                (int x, int y) ne = (e.i + n.x, e.j + n.y);
                if(!r.Contains(ne) && WithinBounds(ne.x, ne.y) && h[e.i][e.j] <= h[ne.x][ne.y]){
                    q.Enqueue(ne);
                    r.Add(ne);
                }
            }
        }
    }
}
