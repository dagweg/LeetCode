public class Solution {
    public void NextPermutation(int[] nums)
    {
        int N = nums.Length;
        int dropIndex = -1;
        for (int i = N - 1; i > 0; i--)
        {
            if (nums[i] > nums[i - 1])
            {
                dropIndex = i - 1;
                break;
            }
        }
        if (dropIndex == -1)
        {
            Array.Reverse(nums);
            return;
        }

        int leastLargestIndex = dropIndex + 1;

        for (int i = dropIndex + 1; i < N; i++)
        {
            if (nums[i] > nums[dropIndex])
                leastLargestIndex = i;
        }

        var temp = nums[leastLargestIndex];
        nums[leastLargestIndex] = nums[dropIndex];
        nums[dropIndex] = temp;

        Array.Reverse(nums, dropIndex + 1, N - dropIndex - 1);
    }
}
