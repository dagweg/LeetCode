class MaxHeap {
  constructor() {
    this.heap = [];
  }

  insert(value) {
    this.heap.push(value);
    this.heapifyUp(this.heap.length - 1);
  }

  heapifyUp(index) {
    let parentIndex = Math.floor((index - 1) / 2);
    while (index > 0 && this.heap[index] > this.heap[parentIndex]) {
      [this.heap[index], this.heap[parentIndex]] = [
        this.heap[parentIndex],
        this.heap[index],
      ];
      index = parentIndex;
      parentIndex = Math.floor((index - 1) / 2);
    }
  }

  getHeap() {
    return this.heap;
  }
}

let n = 8;
let edges = [
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

edges.sort((a, b) => a[0] - b[0]);

let answer = Array(n)
  .fill()
  .map(() => []);
// console.log(answer)

for (const [u, v] of edges) {
  const set = new Set([...answer[u], ...answer[v], u]);
  answer[v] = [...set].sort();
}
console.log(answer);
