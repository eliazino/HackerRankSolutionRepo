using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public class BinaryTreeProblem {
        public static int findMaxDepth(TreeNode node) {
            if (node.left == null && node.right == null)
                return 0;
            int l =0, r =0;
            if (node.left != null) {
                l = findMaxDepth(node.left);
            }
            if (node.right != null) {
                r = findMaxDepth(node.right);
            }
            return l < r ? r+1 : l+1;
        }
        public class TreeNode {
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public int value { get; set; }
            public int depth { get; set; } = 0;
        }
    }
}
