public class TrieNode
{
    public TrieNode[] Children { get; set; } = new TrieNode[2];
    public bool IsEnd { get; set; }
}

public class Trie
{
    public TrieNode Root { get; set; } = new TrieNode();

    public void Insert(int num)
    {
        TrieNode node = Root;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.Children[bit] == null)
                node.Children[bit] = new TrieNode();
            node = node.Children[bit];
        }
        node.IsEnd = true;
    }

    public int FindMaxXor(int num)
    {
        TrieNode node = Root;
        int maxXor = 0;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.Children[1 - bit] != null)
            {
                maxXor |= 1 << i;
                node = node.Children[1 - bit];
            }
            else
            {
                node = node.Children[bit];
            }
        }
        return maxXor;
    }
}


public class Solution
{
    public int FindMaximumXOR(int[] nums)
    {
        var trie = new Trie();
        foreach(int num in nums) trie.Insert(num);

        var maxXor = 0;
        foreach(int num in nums) {
            maxXor = Math.Max(maxXor, trie.FindMaxXor(num));
        }
        return maxXor;
    }
}
