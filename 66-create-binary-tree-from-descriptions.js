/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {number[][]} descriptions
 * @return {TreeNode}
 */
var createBinaryTree = function (descriptions) {
  let hasParent = {},
    children = {};
  for (const [parent, child, isLeft] of descriptions) {
    children[parent] = (children[parent] || []).concat([[child, isLeft === 1]]);
    hasParent[child] = true;
    hasParent[parent] = hasParent[parent] || false;
  }

  let parent = Object.entries(hasParent).find((n) => !n[1])[0];

  var dfs_construct = function (value) {
    const node = new TreeNode(value);
    if (!children[value]) return node;
    for (const [child, isLeft] of children[value]) {
      if (isLeft) {
        node.left = dfs_construct(child);
      } else {
        node.right = dfs_construct(child);
      }
    }
    return node;
  };
  return dfs_construct(parent);
};
