/**
 * @param {string} s
 * @param {number} x
 * @param {number} y
 * @return {number}
 */
var maximumGain = function(s, x, y) {
    let maxStr = x > y ? "ab" : "ba";
    let minStr = x < y ? "ab" : "ba";

    let gain = Math.max(x, y);
    let ans = 0;

    let stack = [];
    let stackIndex = 0;

    for (let i = 0; i < s.length; i++) {
        let currentChar = s[i];

        if (stackIndex > 0 && stack[stackIndex - 1] === maxStr[0] && currentChar === maxStr[1]) {
            stackIndex--;
            ans += gain;
        } else {
            stack[stackIndex++] = currentChar;
        }
    }

    s = stack.slice(0, stackIndex).join('');

    if (x !== y) {
        stack = [];
        stackIndex = 0;
        gain = Math.min(x, y);

        for (let i = 0; i < s.length; i++) {
            let currentChar = s[i];

            if (stackIndex > 0 && stack[stackIndex - 1] === minStr[0] && currentChar === minStr[1]) {
                stackIndex--;
                ans += gain;
            } else {
                stack[stackIndex++] = currentChar;
            }
        }
    }

    return ans;
};
