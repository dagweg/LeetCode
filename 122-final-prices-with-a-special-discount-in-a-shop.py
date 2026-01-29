class Solution:
    def finalPrices(self, prices: List[int]) -> List[int]:
        stack, N = [], len(prices)
        result = [0] * N      
        for i in range(-1,-N-1,-1):
            while stack and prices[i] < stack[-1]:
                stack.pop()
            result[i] = prices[i] - stack[-1] if stack else prices[i]
            stack.append(prices[i])
        return result

                

