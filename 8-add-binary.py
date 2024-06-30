class Solution:
    def addBinary(self, a: str, b: str) -> str:
        # Normalize
        max_len = max(len(a),len(b))
        a = "0" * (max_len-len(a)) + a
        b = "0" * (max_len-len(b)) + b
        
        answer = ""
        carry = 0

        # Basic Adder:
        # Sum = a ^ b ^ Cin
        # Cout = a ^ b & Cin | a & b
        for i in range(max_len-1,-1,-1):
            sum = int(a[i]) ^ int(b[i])
            answer = str(sum ^ carry) + answer
            carry = sum & carry | int(a[i]) & int(b[i])

        return  "1" + answer  if carry == 1 else answer
