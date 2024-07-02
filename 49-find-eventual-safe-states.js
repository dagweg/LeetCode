/**
 * @param {number[][]} graph
 * @return {number[]}
 */
var eventualSafeNodes = function(graph) {
    const N = graph.length
    const color = Array(N).fill("WHITE")
    const safe = new Set()

    var dfs = function(node) {
        if(color[node] === 'BLACK') return true
        if(color[node] === 'GRAY') return false

        color[node] = 'GRAY'
        
        for(const neighbor of graph[node]){
            if(!dfs(neighbor)) return false 
        }  

        color[node]= 'BLACK'      
        safe.add(node)
        return true
    }

    for(let i = 0; i < N; i++){
        if(color[i] === 'WHITE') dfs(i)
    }

    return Array.from(safe).sort((a,b) => a-b)
};
