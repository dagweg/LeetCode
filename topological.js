function getAdjacencyMatrix(edge_list, n) {
  const adj_mat = Array(n)
    .fill()
    .map(() => Array(n).fill(0));

  for (const [from, to] of edges) {
    adj_mat[from][to] = 1;
  }

  return adj_mat;
}

function getAdjacencyListMap(edge_list, n) {
  const adj_list = Object.fromEntries(
    Array(n)
      .fill()
      .map((_, i) => [i, Array()])
  );

  for (const [from, to] of edges) {
    adj_list[to].push(from);
  }
  return adj_list;
}

function kahnTopSort(adj_list, _n = undefined) {
  const n = _n ?? Object.keys(adj_list).length;
  console.log(n);
}

const edges = [
  [0, 3],
  [0, 4],
  [1, 3],
  [2, 4],
  [2, 7],
  [3, 5],
  [3, 6],
  [3, 7],
  [4, 6],
];

const n = 8;

const adj_list = getAdjacencyListMap(edges, n);

kahnTopSort(adj_list);

// const node_ind = Array(n)
//   .fill()
//   .map(() => 0);

// console.log(node_ind);

// for (const [u, v] of edges) {
//   node_ind[v]++;
// }

// function kahnTopSort() {
//   let sorted = [];
//   let que = [];
//   for (const node in node_ind) {
//     if (indegree === 0) {
//       que.push(node);
//     }
//   }
// }

// kahnTopSort();
