/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {number[]}
 */
var findOrder = function(numCourses, prerequisites) {
    const graph = Array.from({length: numCourses}, () => [])
    const indegree = Array(numCourses).fill(0)

    for(const [to,from] of prerequisites){
        indegree[to]++
        graph[from].push(to)
    }

    const queue = []
    for(const [index, degree] of indegree.entries()){
        if(degree === 0) queue.push(index)
    }

    const order = []
    while(queue.length > 0){
        const node = queue.shift()
        order.push(node)
        for(const n of graph[node]){
            indegree[n]--
            if(indegree[n] === 0) queue.push(n)
        }
    }

    return numCourses === order.length ? order : []
};
