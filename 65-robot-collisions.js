/**
 * @param {number[]} positions
 * @param {number[]} healths
 * @param {string} directions
 * @return {number[]}
 */
var survivedRobotsHealths = function (positions, healths, directions) {
  const n = positions.length;
  const indices = Array.from({ length: n }, (_, i) => i);
  const stack = [];

  indices.sort((a, b) => positions[a] - positions[b]);

  for (const ind of indices) {
    if (directions[ind] === "R") {
      stack.push(ind);
    } else {
      while (stack.length > 0 && healths[ind] > 0) {
        const ind2 = stack.pop();

        if (healths[ind2] > healths[ind]) {
          healths[ind2] -= 1;
          healths[ind] = 0;
          stack.push(ind2);
        } else if (healths[ind2] < healths[ind]) {
          healths[ind] -= 1;
          healths[ind2] = 0;
        } else {
          healths[ind] = 0;
          healths[ind2] = 0;
        }
      }
    }
  }

  return healths.filter((health) => health > 0);
};
