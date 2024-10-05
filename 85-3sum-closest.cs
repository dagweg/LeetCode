public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        int closest = nums[0] + nums[1] + nums[2];

        Array.Sort(nums);

        for(int i = 0; i < nums.Length; i++){
            for(int l = i + 1, r = nums.Length - 1; l < nums.Length && r > l;){
                int sum = nums[i] + nums[l] + nums[r];
                if(Math.Abs(target-closest) > Math.Abs(target-sum)) closest = sum;
                if(sum > target) r--;
                else l++;
            }
        }
        return closest;
    }
}
