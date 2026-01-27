class Solution:
    def operate(self,s, f, operator):
        s, f = int(s), int(f)
        return (f + s if operator == "+" 
               else f - s if operator == "-" 
               else f * s if operator == "*" 
               else f / s if operator == "/" 
               else None)

    def evalRPN(self, tokens: List[str]) -> int:
        s = []
        for token in tokens:
            if token in ['+','-','*','/']:
                s.append(self.operate(s.pop(), s.pop(), token))
            else:
                s.append(token)
        return int(s.pop())
