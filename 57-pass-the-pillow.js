var passThePillow = function(n, time) {
    let i = 0, dir = 1
    while(time) {
        i += dir
        time--
        dir = i == 0 ? 1 : i == n-1 ? -1 : dir
    }
    return i+1
};
