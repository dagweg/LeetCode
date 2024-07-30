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
 * @param {number} startValue
 * @param {number} destValue
 * @return {string}
 */
var getDirections = function(root, startValue, destValue) {
    // To perform Optimization
    // not to perform dfs if we have already found both (just return what you have already)        
    let sourceFound = false, destFound = false 
    
    var dfs = function(node, dir){
        if(!node || (sourceFound && destFound)){
            return ["",false,false]
        }
        const left = dfs(node.left, "L")
        const right = dfs(node.right, "R")
        // Source on the left and Dest on the right exists
        if(left[1] && right[2]){
            return [left[0]+right[0], true, true]
        }
        // Source on the right and Dest on the left exists
        if(left[2] && right[1]){
            return [right[0]+left[0],true,true]
        }
        // Either both are on the left 
        if(left[1] && left[2]){
            return left
        }
        // or both are on the right 
        if(right[1] && right[2]){
            return right
        }
        // or don't exist at all in the child subtree
        // 3 cases
        // (either current node is start)
        if(node.val === startValue){
            sourceFound = true
            if(left[2]) return [left[0], true,true]
            if(right[2]) return [right[0],true,true]
            return ["U",true,false]
            
        }
        // (either current node is dest)
        if(node.val === destValue){
            destFound = true
            if(left[1]) return [left[0],true,true]
            if(right[1]) return [right[0],true,true]
            return [dir,false,true]
        }
        // (or neither so)
        if(left[1]) return [left[0]+"U",true,false]
        if(left[2]) return [dir+left[0],false,true]
        if(right[1]) return [right[0]+"U",true,false]
        if(right[2]) return [dir+right[0],false,true]

        return ["", false, false];
    }
    return dfs(root,"U")[0]
};
