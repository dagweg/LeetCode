export default class Kahn {
  constructor() {}
  static topologicalSort(edge_list, _n = undefined) {
    const n = _n ?? edge_list.length;

    const indegrees = new Map(); // to keep track of indegrees of each node
    const graph = new Map(); // this is adjacency list map representation of the edge_list

    // Initialize the graph and indegrees accordingly
    for (const [u, v] of edge_list) {
      if (!graph.has(u)) graph.set(u, []);
      if (!graph.has(v)) graph.set(v, []);
      graph.get(u).push(v);
      indegrees.set(v, (indegrees.get(v) ?? 0) + 1);
      if (!indegrees.has(u)) indegrees.set(u, 0);
    }

    const queue = [];
    for (const [key, val] of indegrees.entries()) {
      if (val === 0) queue.push(key);
    }

    const top_order = [];
    while (queue.length > 0) {
      const node = queue.shift();
      top_order.push(node);

      for (const neighbor of graph.get(node)) {
        indegrees.set(neighbor, indegrees.get(neighbor) - 1);
        if (indegrees.get(neighbor) === 0) queue.push(neighbor);
      }
    }

    if (top_order.length !== graph.size) {
      throw new Error(
        "Cannot create a topological order becuase the graph has a cycle"
      );
    }

    return top_order;
  }
}
