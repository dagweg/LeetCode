public class Solution {

    public class TrieNode {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsEnd = false;
    }

    public class Trie{
        public TrieNode Root = new TrieNode();

        public void Insert(string word){
            TrieNode node = Root;
            foreach(char c in word){
                if(node.Children[c-'a'] == null){
                    node.Children[c-'a'] = new TrieNode();
                }
                node = node.Children[c-'a'];
            }
            node.IsEnd = true;
        }

        public string GetSmallestPrefix(string word){

            TrieNode node = Root;
            StringBuilder sb = new StringBuilder();
            foreach(char c in word){
                var child = node.Children[c-'a'];
                if(child == null) return word;
                node = child;
                sb.Append(c);
                if(child.IsEnd) break;
            }
            return sb.ToString();
        }
    }

    public string ReplaceWords(IList<string> dictionary, string sentence) {
        var trie = new Trie();
        foreach(string word in dictionary) trie.Insert(word);

        var result = sentence.Split(' ');

        // Perform lookups and construct the new sentence
        for(var i = 0; i < result.Count(); i++){
            result[i] = trie.GetSmallestPrefix(result[i]);
        }

        return string.Join(' ', result);
    }
}
