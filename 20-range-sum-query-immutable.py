class NumArray:

    def __init__(self, nums: List[int]):
        self.psum = [0] + list(accumulate(nums))

    def sumRange(self, left: int, right: int) -> int:
        return self.psum[right+1] - self.psum[left]
