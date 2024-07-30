/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @param {number[]} to_delete
 * @return {TreeNode[]}
 */
var delNodes = function(root, to_delete) {
    let answer = []
    let deletedSet = new Set(to_delete)
    var dfs = function(node, isParDeleted){
        if(!node) return null
        if(isParDeleted === true && !deletedSet.has(node.val)) answer.push(node)
        node.left = dfs(node.left,deletedSet.has(node.val))
        node.right = dfs(node.right,deletedSet.has(node.val))
        return deletedSet.has(node.val) ? null : node
    }
    dfs(root,true)
    return answer
};
