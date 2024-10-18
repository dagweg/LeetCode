public class Solution {
    private static Dictionary<int, string> Keypad = new Dictionary<int, string> {
        { 2, "abc" },
        { 3, "def" },
        { 4, "ghi" },
        { 5, "jkl" },
        { 6, "mno" },
        { 7, "pqrs" },
        { 8, "tuv" },
        { 9, "wxyz" }
    };

    private IList<string> Result = new List<string>();

    public IList<string> LetterCombinations(string digits) {
      if(string.IsNullOrEmpty(digits)) return [];
      var candidates = digits.Select(c => Keypad[int.Parse(c.ToString())]).ToList();
      Backtrack(candidates, 0, new StringBuilder());
      return Result;
    }

    private void Backtrack(List<string> candidates, int start, StringBuilder combination){
      if(start >= candidates.Count) {
        Result.Add(combination.ToString());
        return;
      }
      var word = candidates[start];
      for(int i = 0; i < word.Length; i++){
        combination.Append(word[i]);
        Backtrack(candidates, start + 1, combination);
        combination.Remove(combination.Length - 1, 1);
      }
    }
}
