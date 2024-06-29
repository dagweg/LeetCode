/**
 * @param {number} n
 * @param {number[][]} roads
 * @return {number}
 */
var maximumImportance = function(n, roads) {
    let arr = Array.from({length:n},  (_,i) => [i,0])

    for(const [u,v] of roads){
        arr[u][1] ++;
        arr[v][1] ++;
    }
    
    arr.sort((a,b) => b[1] - a[1])
    const mp = arr.reduce((acc,[u,v]) => (acc[u] = n--, acc), {})
    return roads.reduce((acc,[u,v]) => acc + mp[u] + mp[v], 0)
};
