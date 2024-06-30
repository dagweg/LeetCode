from collections import deque

class Solution:
    def floodFill(self, image: List[List[int]], sr: int, sc: int, color: int) -> List[List[int]]:
        """ Recursive Solution using DFS """

        rows, cols = len(image),len(image[0])
        original_color = image[sr][sc]

        def recursive_fill(r,c,arr):
            """ Base Case 1: Boundry Check """
            if not 0 <= r < rows or not 0 <= c < cols:
                return
            
            """ Does is satisfy image fill condition?"""
            if arr[r][c] != original_color or arr[r][c] == color:
                return
            
            arr[r][c] = color
            recursive_fill(r+1,c,arr)
            recursive_fill(r,c+1,arr)
            recursive_fill(r-1,c,arr)
            recursive_fill(r,c-1,arr)
        recursive_fill(sr,sc,image)
        return image

            
