class Solution:
    def kItemsWithMaximumSum(self, numOnes: int, numZeros: int, numNegOnes: int, k: int) -> int:
        if not k: return 0
        return list(accumulate([1]*numOnes +[0] * numZeros+[-1]*numNegOnes))[k-1]
