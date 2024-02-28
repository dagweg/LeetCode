# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def reverseList(self,head: Optional[ListNode]) -> Optional[ListNode]:
        if not head or not head.next:
            return head

        temp = None
        slow = head
        fast = head.next


        while not fast == None :
            slow.next = temp
            temp = slow
            slow = fast
            fast = fast.next
        
        slow.next = temp
        return slow
            
