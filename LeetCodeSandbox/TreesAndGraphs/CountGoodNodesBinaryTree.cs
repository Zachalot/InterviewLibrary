namespace TreesAndGraphs
{
    public class CountGoodNodesBinaryTree
    {
        public int GoodNodes(TreeNode root)
        {
            return 1 + GoodNodesHelper(root, root.val);
        }

        private int GoodNodesHelper(TreeNode root, int maxSoFar)
        {
            if (root.val > maxSoFar)
            {
                maxSoFar = root.val;
            }
            if (root.left == null && root.right != null)
            {
                if (root.right.val >= maxSoFar)
                {
                    return 1 + GoodNodesHelper(root.right, maxSoFar);
                }
                else
                {

                    return GoodNodesHelper(root.right, maxSoFar);
                }
            }

            if (root.left != null && root.right == null)
            {
                if (root.left.val >= maxSoFar)
                {
                    return 1 + GoodNodesHelper(root.left, maxSoFar);
                }
                else
                {
                    return GoodNodesHelper(root.left, maxSoFar);
                }
            }

            if (root.left != null && root.right != null)
            {
                if (root.right.val >= maxSoFar && root.left.val >= maxSoFar)
                {
                    return 2 + GoodNodesHelper(root.right, maxSoFar) + GoodNodesHelper(root.left, maxSoFar);
                }
                else if (root.right.val >= maxSoFar || root.left.val >= maxSoFar)
                {
                    return 1 + GoodNodesHelper(root.right, maxSoFar) + GoodNodesHelper(root.left, maxSoFar);
                }
                else
                {
                    return GoodNodesHelper(root.left, maxSoFar) + GoodNodesHelper(root.right, maxSoFar);
                }
            }

            return 0;
        }
    }
}
