import Graph from "./graph.js";
import Kahn from "./kahn.js";

const edges = [
  [0, 1],
  [0, 2],
  [0, 3],
  [0, 4],
  [1, 2],
];

const n = 5;

const top_sort = Kahn.topologicalSort(edges);

console.log(top_sort);
