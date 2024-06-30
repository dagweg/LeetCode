class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
      # SNAKE CASE MADNESS: jUST FOR FUN
        strs_length = len(strs)

        if strs_length == 1: return strs[0]

        smallest_str_length = 200
        smallest_str_index = 0

        for i in range(strs_length):
            current_str_length = len(strs[i])
            if current_str_length < smallest_str_length:
                smallest_str_length = current_str_length
                smallest_str_index = i
        
        longest_common_prefix = ''
        for i in range(smallest_str_length):
            for j in range(strs_length):
                if j == smallest_str_index: continue
                if strs[j][i] != strs[smallest_str_index][i]:
                    return longest_common_prefix
            longest_common_prefix += strs[smallest_str_index][i]

        return longest_common_prefix
