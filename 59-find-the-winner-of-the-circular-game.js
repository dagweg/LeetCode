/**
 * @param {number} n
 * @param {number} k
 * @return {number}
 */
var findTheWinner = function(n, k) {
    let players = Array(n).fill().map((_,i) => i+1)
    let i = 0, counter = 0, lost = 0
    while(lost < n - 1){
        let player = players[i % n]
        if(player === -1){
            // he has already lost
            i++
            continue
        }
        if(++counter === k){
            players[i % n] = -1 // make the player lose
            counter = 0
            lost++
        }
        i++
    }   
    return players.filter(player => player !== -1)[0]
};
