/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {number[]}
 */
var findMinHeightTrees = function(n, edges) {
    if(edges.length === 0) return [0]
    const graph = Array(n).fill().map(() => []);
    const indegree = Array(n).fill(0)

    for(const [u,v] of edges){
        graph[u].push(v)
        graph[v].push(u)
        indegree[v]++
        indegree[u]++
    }

    let queue = []
    for(let node = 0; node < n; node++){
        if(indegree[node] === 1) queue.push(node)
    }

    
    let processed = 0
    let qLength = 0

    while (n - processed > 2){
        qLength = queue.length
        processed += qLength
        for(let i = 0; i < qLength; i++){
            const node = queue.shift()
            for(const adj of graph[node]){
                if(--indegree[adj] === 1) queue.push(adj)
            }
        }
    }

    return queue
};
