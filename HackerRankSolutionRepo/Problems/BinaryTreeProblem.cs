using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public class BSTImpl {
        private TreeNode root = null;
        public void insert(int data) {
            if(root == null) {
                root = new TreeNode(data);
                return;
            }
            root = searchAndInsert(root, data);
        }
        private TreeNode searchAndInsert(TreeNode root, int value) {
            if (root == null)
                return new TreeNode(value);
            if(root.value > value) {
                root.left = searchAndInsert(root.left, value);
            } else {
                root.right = searchAndInsert(root.right, value);
            }
            return root;
        }
        public List<int> preOrderTraversal() {
            return preOrderTraversal(root, new List<int>());
        }
        public List<int> inOrderTraversal() {
            return inOrderTraversal(root, new List<int>());
        }
        public List<int> postOrderTraversal() {
            return postOrderTraversal(root, new List<int>());
        }
        public List<int> preOrderTraversal(TreeNode t, List<int> data) {
            if (t == null)
                return data;
            data.Add(t.value);
            preOrderTraversal(t.left, data);
            preOrderTraversal(t.right, data);
            return data;
        }

        public List<int> inOrderTraversal(TreeNode t, List<int> data) {
            if (t == null)
                return data;
            inOrderTraversal(t.left, data);
            data.Add(t.value);
            inOrderTraversal(t.right, data);
            return data;
        }

        public List<int> postOrderTraversal(TreeNode t, List<int> data) {
            if (t == null)
                return data;
            postOrderTraversal(t.left, data);
            postOrderTraversal(t.right, data);
            data.Add(t.value);            
            return data;
        }

        public TreeNode searchTree(int val) {
            if (root == null)
                return null;
            return searchTree(root, val);
        }
        private TreeNode searchTree(TreeNode tree, int val) {
            if (tree == null)
                return null;
            if (tree.value == val)
                return tree;
            if (tree.value > val) {
                return searchTree(tree.left, val);
            } else {
                return searchTree(tree.right, val);
            }
        }
        public TreeNode delete(int value) {            
            return delete(root, value);
        }
        private TreeNode delete(TreeNode tree, int value) {
            if (tree == null)
                return null;
            if(tree.value == value) {
                if (tree.left != null && tree.right != null) {
                    var reshapedNode = getLeastLeaf(tree.right, value);
                    tree.setValue(reshapedNode.val);
                    tree.right = reshapedNode.nodes;
                    tree.right = delete(tree.right, value);
                } else if(tree.right != null) {
                    return tree.right;
                } else {
                    return tree.left;
                }
            } else {
                if(tree.value > value) {
                    tree.left = delete(tree.left, value);
                } else {
                    tree.right = delete(tree.right, value);
                }
            }
            return tree;
        }
        private (TreeNode nodes, int val) getLeastLeaf(TreeNode node, int valueToDelete) {
            if(node.left == null) {
                int originalValue = node.value;
                node.setValue(valueToDelete);
                return (node, originalValue);
            }
            var result = getLeastLeaf(node.left, valueToDelete);
            node.left = result.nodes;
            return (node, result.val);
        }
        
        public TreeNode getTree() {
            return root;
        }
        public long getHeight() {
            if (root == null)
                return 0;
            return getHeight(this.root);
        }
        public Dictionary<int, List<int>> getLevel() {
            long height = getHeight();
            var result = new Dictionary<int, List<int>>();
            for(int i = 1; i <= height; i++) {
                result.Add(i, getLevel(root, i, new List<int>()));
            }
            return result;
        }
        private List<int> getLevel(TreeNode node, long level, List<int> levelMembers) {
            if (node == null)
                return levelMembers;
            if(level == 1) {
                levelMembers.Add(node.value);
            }
            getLevel(node.left, level -1, levelMembers);
            getLevel(node.right, level -1, levelMembers);
            return levelMembers;
        }
        public long getHeight(TreeNode node) {
            if (node == null)
                return 0;
            long rlen = getHeight(node.right);
            long llen = getHeight(node.left);
            if (rlen > llen)
                return rlen + 1;
            return llen + 1;
        }
        public bool treeIsABinaryTree(TreeNode t, int minValue = int.MinValue, int maxValue = int.MaxValue) {
            if (t == null)
                return true;
            if (t.value < minValue || t.value > maxValue)
                return false;
            return (treeIsABinaryTree(t.left, minValue, t.value - 1) && treeIsABinaryTree(t.right, t.value + 1, maxValue));
        }
        public bool treeIsABinaryTree() {
            return treeIsABinaryTree(root);
        }
        public class TreeNode {
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public int value { get; private set; }
            public TreeNode(int value) {
                this.value = value;
            }
            public void setValue(int value) {
                this.value = value;
            }
        }
    }

}
