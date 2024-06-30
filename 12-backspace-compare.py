class Solution:
    def backspaceCompare(self, s: str, t: str) -> bool:
        stack1 = []
        stack2 = []

        for c in s:
            if c != '#':
                stack1.append(c)
            elif stack1:
                stack1.pop()
        for c in t:
            if c != '#':
                stack2.append(c)
            elif stack2:
                stack2.pop()
        
        return stack1 == stack2
