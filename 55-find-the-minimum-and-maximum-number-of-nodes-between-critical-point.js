/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @return {number[]}
 */
var nodesBetweenCriticalPoints = function(head) {
    if(!head.next.next) return [-1,-1]

    let critPoints = 0
    let minD = 10e5, maxD = 0
    let counter = 0
    let prev = head, curr = prev.next, next = curr.next

    while(next){
        if(isCritical(prev,curr,next)){
            if(critPoints > 0){
                maxD += counter
                minD = Math.min(minD, counter)
            }
            critPoints++
            counter = 0
        }
        
        counter += 1
        prev = curr
        curr = next
        next = next.next
    }

    if(critPoints < 2) return [-1,-1]
    return [minD,maxD]
};

var isCritical = function(prev,curr,next){
    return (prev.val < curr.val && next.val < curr.val) || 
    (prev.val > curr.val && next.val > curr.val)
}
