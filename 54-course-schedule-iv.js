/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @param {number[][]} queries
 * @return {boolean[]}
 */
var checkIfPrerequisite = function(numCourses, prerequisites, queries) {
    const graph = Array(numCourses).fill().map(() => [])
    const indegree = Array(numCourses).fill(0)
    const ancestor = Array(numCourses).fill().map(() => new Set())

    for(const [from,to] of prerequisites){
        graph[from].push(to)
        indegree[to]++
    }
    
    const queue = []
    for(const [course, degree] of indegree.entries()){
        if(degree === 0) queue.push(course)
    }
    
    while(queue.length > 0){
        const course = queue.shift()
        for(const neigh of graph[course]){
            
            indegree[neigh]--
            if(indegree[neigh] === 0) queue.push(neigh)
            
            ancestor[neigh].add(course)
            for(const ancest of ancestor[course]){
                ancestor[neigh].add(ancest)
            }
        }
    }

    return queries.map(query => ancestor[query[1]].has(query[0]))

};
