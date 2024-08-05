using System.Collections.Specialized;
public class Solution {
    public string KthDistinct(string[] arr, int k) {
        OrderedDictionary ordDic = new();
        foreach(string str in arr){
            if(ordDic.Contains(str)) ordDic[str] = 2; 
            else ordDic.Add(str,1);
        }
        var ans = "";
        foreach(DictionaryEntry kvp in ordDic){
            if((int)kvp.Value == 1){
                ans = (string)kvp.Key;
                k--;
            }
            if(k==0) break;
        };
        return k ==0 ?  ans: "";
    }
}
