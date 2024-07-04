/**
 * @param {number[][]} richer
 * @param {number[]} quiet
 * @return {number[]}
 */
var loudAndRich = function(richer, quiet) {
    const N = quiet.length
    const indegree = Array(N).fill(0)
    const graph = Array(N).fill().map(() => [])
    const answer = Array(N).fill().map((_,i) => i)

    for(const [from,to] of richer){
        graph[from].push(to)
        indegree[to]++
    }

    const queue = []
    for(const [node,deg] of indegree.entries()){
        if(deg === 0) queue.push(node)
    }

    while(queue.length > 0){
        const node = queue.shift()
        for(const neigh of graph[node]){
            indegree[neigh]--
            if(indegree[neigh] === 0) queue.push(neigh)

            if(quiet[answer[node]] < quiet[answer[neigh]]){
                answer[neigh] = answer[node]
            }
        }
    }

    return answer
};
