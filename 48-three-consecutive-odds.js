/**
 * @param {number[]} arr
 * @return {boolean}
 */
var threeConsecutiveOdds = function(arr) {
    let oddCounter = 0
    for(const val of arr){
        if(val % 2 != 0){
            oddCounter++
        }else{
            oddCounter = 0
        }
        if(oddCounter === 3) return true
    }
    return false

};
