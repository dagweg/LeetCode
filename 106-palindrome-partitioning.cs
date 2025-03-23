
public class Solution {
    private IList<IList<string>> _partition = [];
    private List<string> _acc = [];

    public static bool IsPalindrome(ref string s, int l, int r){
        while(l < r)
            if(s[l++] != s[r--]) return false;
        return true;
    }
    public IList<IList<string>> Partition(string s) {
        int count = s.Count();
        void _Partition(int start){
            if(start >= count) {
                _partition.Add(_acc.ToList());
                return;
            }
            for(int i = 1; start + i <= count; i++){
                string subStr = s.Substring(start,i);
                if(IsPalindrome(ref s, start, start + i - 1)){
                    _acc.Add(subStr);
                    _Partition(start+i);
                    _acc.RemoveAt(_acc.Count-1);
                }
            }
        }

        _Partition(0);
        return _partition;
    }
}
