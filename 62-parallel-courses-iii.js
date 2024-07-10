/**
 * @param {number} n
 * @param {number[][]} relations
 * @param {number[]} time
 * @return {number}
 */
var minimumTime = function(n, relations, time) {
    const graph = Array(n+1).fill().map(() => [])
    const memo = {}
    let ans = 0

    for(const [prev,next] of relations){
        graph[prev].push(next)
    }
    const dfs = (node) => {
        if(memo[node]) return memo[node]
        let max_month = 0
        for(const adj of graph[node]){
            max_month = Math.max(max_month, dfs(adj))
        }
        memo[node] = max_month + time[node-1]
        return memo[node]
    }

    for(let node = 1; node <= n; node++){
        ans = Math.max(ans, dfs(node))
    }
    return ans
};
