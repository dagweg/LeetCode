public class MapSum {

    public class TrieNode{
        public Dictionary<char, TrieNode> Children {get;set;} = [];
        public bool IsEnd {get;set;} = false;
        public int Val {get;set;} 
    }

    TrieNode Root;

    public MapSum() {
        Root = new TrieNode();
    }
    
    public void Insert(string key, int val) {
        TrieNode node = Root;
        foreach(char c in key){
            if(!node.Children.ContainsKey(c)){
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        node.IsEnd = true;
        node.Val = val;
    }
    
    public int Sum(string prefix) {
        TrieNode node = Root;
        foreach(char c in prefix) {
            if(node.Children.TryGetValue(c, out var child))
                node = child;
            else return 0;
        }
        return GetSum(node);
    }

    public int GetSum(TrieNode node){
        int sum = node.Val;
        foreach(var child in node.Children)
            sum += GetSum(child.Value);
        return sum;
    }
}

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */
