/**
 * @param {string} s
 * @return {string}
 */
var reverseParentheses = function(s) {
    let stack = []
    for(const char of s){
        stack.push(char)
        if(char === ")"){
            let substr = []
            let chr
            do{
                chr = stack.pop()
                if(chr!==")" && chr !=="(") substr.push(chr)
            }while(chr !== "(")
            stack.push(...substr)
        }
    }
    return stack.join("")
};
