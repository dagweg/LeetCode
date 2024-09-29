public class TrieNode {
    public Dictionary<char, TrieNode> Children {get;set;} = [];
    public bool IsEnd = false;
}

public class Trie {
    public TrieNode Root = new TrieNode();

    public void Insert(string word){
        TrieNode current = Root;
        foreach(char c in word){
            if(!current.Children.TryGetValue(c, out var node))
                current.Children[c] = new TrieNode();
            current = current.Children[c];
        }
        current.IsEnd = true;
    }

    public string LongestWord(TrieNode node, StringBuilder prefix){
        string longest = "";

        if(node.IsEnd) longest = prefix.ToString();

        foreach(var child in node.Children){
            if(child.Value.IsEnd){
                prefix.Append(child.Key);
                var candidate = LongestWord(child.Value, prefix);
                if (candidate.Length > longest.Length || (candidate.Length == longest.Length && candidate.CompareTo(longest) < 0))
                    longest = candidate; 
                prefix.Length--;
            }
        }
        return longest;
    }    
}

public class Solution {
    public string LongestWord(string[] words) {
        var trie = new Trie();
        foreach(var word in words) trie.Insert(word);
        return trie.LongestWord(trie.Root, new StringBuilder());
    }
}
