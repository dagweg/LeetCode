public class Trie {

    public class TrieNode{
        public TrieNode(){}
        public TrieNode[] Children {get;set;} = new TrieNode[26];
        public bool IsEndOfWord {get;set;} = false;
    }

    public TrieNode Root {get;set;}

    public Trie() {
        Root = new TrieNode();
    }
    
    
    public void Insert(string word) {
        TrieNode trav = Root;
        foreach(char c in word){
            if(trav.Children[c-'a'] == null){
                trav.Children[c-'a'] = new TrieNode();
            }
            trav = trav.Children[c-'a'];
        }
        trav.IsEndOfWord = true;
    }
    
    public bool Search(string word) {
        TrieNode trav = Root;
        foreach(char c in word){
            if(trav.Children[c-'a'] == null) return false;
            trav = trav.Children[c-'a'];
        }
        return trav.IsEndOfWord;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode trav = Root;
        foreach(char c in prefix){
            if(trav.Children[c-'a'] == null) return false;
            trav = trav.Children[c-'a'];
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
