/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null)
            return null;
        Dictionary<int, Node> dict = [];
        Node newNode = new Node(0);
        void Traverse(Node n)
        {
            Node trav = new Node(n.val);
            if(newNode.val == 0)
                newNode = trav;
            if(n.neighbors.Count == 0 || dict.ContainsKey(trav.val)) 
                return;
            dict[trav.val] = trav;
            foreach(var neighbor in n.neighbors){
                Traverse(neighbor);
                if(dict.TryGetValue(neighbor.val, out var existing))
                    trav.neighbors.Add(existing);                
            }
        }
        Traverse(node);
        return newNode;
    }
}
