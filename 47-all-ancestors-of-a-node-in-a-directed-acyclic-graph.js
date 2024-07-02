/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {number[][]}
 */
var getAncestors = function(n, edges) {
    const indegree = Array(n).fill(0)
    const graph = Array(n).fill().map(() => [])
    const ancestors = Array.from({length:n}, () => new Set())
    
    // calc indegrees and adj list repr
    for(const [u,v] of edges){
        indegree[v]++
        graph[u].push(v)
    }
    
    // kahn top sort
    const queue = []
    for(const [index,degree] of indegree.entries()){
        if(degree === 0){
            queue.push(index)
        }
    }

    while(queue.length>0){
        const node = queue.shift()
        for(const neighbor of graph[node]){
            // decrement the indegree 
            indegree[neighbor]--;
            if(indegree[neighbor] === 0){
                queue.push(neighbor)
            }

            // update the ancestor table of the neighbor
            // with the ancestors of the current node
            ancestors[neighbor].add(node)
            for(const ancest of ancestors[node]){
                ancestors[neighbor].add(ancest)
            }
        }
    }
    
    return ancestors.map(ancestorSet => Array.from(ancestorSet).sort((a,b) => a-b)
    )

};
