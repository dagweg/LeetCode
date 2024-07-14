/**
 * @param {string} formula
 * @return {string}
 */
var countOfAtoms = function(formula) {
    let stack = [];
    let N = formula.length;
    
    for (let i = 0; i < N; i++) {
        let char = formula[i];
        
        if (!isNaN(char)) {
            let multiplicity = Number(char);
            let j = i + 1;
            while (j < N && !isNaN(formula[j])) {
                multiplicity = multiplicity * 10 + Number(formula[j]);
                j++;
            }
            i = j - 1;
            
            const popped = stack.pop();
            if (popped[0] === ")") {
                let temp = [];
                let elem = stack.pop();
                while (elem && elem[0] !== "(") {
                    temp.unshift([elem[0], elem[1] * multiplicity]);
                    elem = stack.pop();
                }
                temp.forEach(t => stack.push(t));
            } else {
                stack.push([popped[0], popped[1] * multiplicity]);
            }
        } else if (char >= 'a' && char <= 'z') {
            stack.push([stack.pop()[0] + char, 1]);
        } else {
            stack.push([char, 1]);
        }
    }
    
    let map = {};
    stack.forEach(elem => {
        if (elem[0] !== ")" && elem[0] !== "(") {
            map[elem[0]] = (map[elem[0]] || 0) + elem[1];
        }
    });
    
    return Object.entries(map)
        .sort()
        .map(elem => elem[1] === 1 ? elem[0] : elem[0] + elem[1])
        .join("");
};
