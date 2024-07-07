/**
 * @param {number} numBottles
 * @param {number} numExchange
 * @return {number}
 */
var numWaterBottles = function(numBottles, numExchange) {
    let full = numBottles, empty = 0
    let ans = full
    while(full + empty >= numExchange){
        let sum = full + empty
        full = (sum - sum % numExchange) / numExchange
        empty = sum % numExchange
        ans += full
    }
    return ans
};
