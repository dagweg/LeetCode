public class WordDictionary {

    public TrieNode Root;

    public class TrieNode {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsEnd = false;
    }

    public WordDictionary() {
        Root = new TrieNode();
    }
    
    public void AddWord(string word) {
        TrieNode node = Root;
        var ci = 0;
        foreach(char c in word){
            ci = c - 'a';
            if(node.Children[ci] == null) 
                node.Children[ci] = new TrieNode();
            node = node.Children[ci];
        }
        node.IsEnd = true;
    }
    
    public bool Search(string word) {
        return SearchHelper(Root, word, 0);
    }

    public bool SearchHelper(TrieNode node, string word, int index) {
        if (index == word.Length) {
            return node.IsEnd;
        }

        char ch = word[index];

        if (ch == '.') {
            for (int i = 0; i < 26; i++) {
                if (node.Children[i] != null && SearchHelper(node.Children[i], word, index + 1)) 
                    return true;
            }
        } else {
            int childIndex = ch - 'a'; 
            if (node.Children[childIndex] == null)
                return false; 
            
            return SearchHelper(node.Children[childIndex], word, index + 1);
        }

        return false;
    }


}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
