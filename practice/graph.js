export default class Graph {
  constructor() {}

  getAdjacencyMatrix(edge_list, n) {
    const adj_mat = Array(n)
      .fill()
      .map(() => Array(n).fill(0));

    for (const [from, to] of edges) {
      adj_mat[from][to] = 1;
    }

    return adj_mat;
  }

  getAdjacencyListMap(edge_list, n) {
    const adj_list = Object.fromEntries(
      Array(n)
        .fill()
        .map((_, i) => [i, Array()])
    );

    for (const [from, to] of edges) {
      adj_list[from].push(to);
    }
    return adj_list;
  }
}
