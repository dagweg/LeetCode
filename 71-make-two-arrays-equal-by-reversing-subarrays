public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        int N = target.Length;
        Dictionary<int,int> countMap = target
                                       .GroupBy(x => x)
                                       .ToDictionary(g => g.Key, g => g.Count());
        foreach(int value in arr){
            if(countMap.ContainsKey(value)){
                countMap[value] --;
                if(countMap[value] < 0) return false;
            }else return false;
        }  
        
        return countMap.Values.All(v => v == 0);
    }
}
