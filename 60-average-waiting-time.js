/**
 * @param {number[][]} customers
 * @return {number}
 */
var averageWaitingTime = function(customers) {
    let N = customers.length, curTime = customers[0][0]
    return customers.reduce((acc, cur) => {
        if(curTime < cur[0]) curTime = cur[0]
        curTime += cur[1]
        return acc + curTime - cur[0]
    },0)/N
};
