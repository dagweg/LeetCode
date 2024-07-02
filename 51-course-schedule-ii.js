/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {number[]}
 */
var findOrder = function(numCourses, prerequisites) {
    const graph = Array.from({length: numCourses}, () => [])
    const color = Array(numCourses).fill(0)
    // 0 - unvisited, 1 - current, 2 - visited

    for(const [to,from] of prerequisites){
        graph[from].push(to)
    }

    const order=  []
    var dfs = (n) => {
        if(color[n] === 2) return true // dead-end
        if(color[n] === 1) return false // cycle
    
        color[n] = 1
        for(const neigh of graph[n]){
            if(!dfs(neigh)) return false
        }

        color[n] =2
        order.push(n)
        return true
    }   

    for(let i = 0; i < numCourses; i++){
        if(color[i] === 0 && !dfs(i)) return []
    }

    return order.reverse()
};
