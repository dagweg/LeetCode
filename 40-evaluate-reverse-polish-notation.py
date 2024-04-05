class Solution:
    def evalRPN(self, tokens: List[str]) -> int:
        stack = []

        for strs in tokens:
            if strs in ['+', '-', '*', '/']:
                y = int(stack.pop())
                x = int(stack.pop())
                if strs == '+': z = x + y
                elif strs == '-': z = x - y
                elif strs == '*': z = x * y
                else: z = int(x/y)
                stack.append(str(z))
            else:
                stack.append(strs)
                
        return int(stack.pop())
