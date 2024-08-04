public class Solution {
    private static int MOD = 1_000_000_007;
    public int RangeSum(int[] nums, int n, int left, int right) {
        int[] subArrays = GenerateAllSubArrays(nums,n);
        Array.Sort(subArrays);
        return subArrays
               .Skip(left-1)
               .Take(right-left+1)
               .Aggregate(0, (acc, cur) => (acc + cur) % MOD);
    }

    int[] GenerateAllSubArrays(int[] nums, int n){
        int[] subArray = new int[(n * (n + 1)) / 2];
        int I = 0;
        for(int i = 0; i < n; i++){
            int curSum = 0;
            for(int j = i; j < n; j++){
                curSum += nums[j];
                subArray[I++] = curSum;
            }
        }
        return subArray;
    }
}
