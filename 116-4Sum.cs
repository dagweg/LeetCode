public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        Array.Sort(nums);
        var answer = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 3; i++) {
            if (i > 0 && nums[i] == nums[i - 1]) continue; // skip duplicat for i

            for (int j = i + 1; j < nums.Length - 2; j++) {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue; // skip duplicates for j

                int l = j + 1, r = nums.Length - 1;
                while (l < r) {
                    long quadSum = (long)nums[i] + nums[j] + nums[l] + nums[r];
                    if (quadSum < target) {
                        l++;
                    } else if (quadSum > target) {
                        r--;
                    } else {
                        answer.Add(new List<int> { nums[i], nums[j], nums[l], nums[r] });
                        l++;
                        r--;

                        while (l < r && nums[l] == nums[l - 1]) l++; // skip duplicates for l
                        while (l < r && nums[r] == nums[r + 1]) r--; // skip dups for r
                    }
                }
            }
        }

        return answer;
    }
}
