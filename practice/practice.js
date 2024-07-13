function findOrder(dict, N, K) {
  const graph = {};
  const indegree = Array(K).fill(0);

  for (let i = 0; i < K; i++) {
    graph[String.fromCharCode(97 + i)] = new Set();
  }

  console.log(graph);
  for (let i = 0; i < N - 1; i++) {
    const word1 = dict[i];
    const word2 = dict[i + 1];

    const min_len = Math.min(word1.length, word2.length);

    for (let j = 0; j < min_len; j++) {
      if (word1[j] !== word2[j]) {
        if (!graph[word1[j]].has(word2[j])) {
          indegree[word2.charCodeAt(j) - 97]++;
          graph[word1[j]].add(word2[j]);
        }
        break;
      }
    }
  }

  const queue = [];
  for (const [node, degree] of indegree.entries()) {
    if (degree === 0) queue.push(node);
  }

  const order = [];
  console.log(queue);
  // console.log(graph["c"]);
  // console.log(indegree);
  // for (const [key, set] of Object.entries(graph))
  //   console.log(key, Array.from(set));
  while (queue.length > 0) {
    const node = String.fromCharCode(queue.shift() + 97);
    order.push(node);

    for (const n of graph[node]) {
      indegree[n.charCodeAt(0) - 97]--;
      if (indegree[n.charCodeAt(0) - 97] === 0)
        queue.push(n.charCodeAt(0) - 97);
    }
  }

  return order;
}

const N = 3,
  K = 3;
const dict = ["caa", "aaa", "aab"];

console.log(findOrder(dict, N, K));
