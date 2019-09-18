public void PreOrder(TreeNode root)
{
    if (root == null)
    {
        return;
    }

    TreeNode currentNode = root;
    Stack<TreeNode> nodesLeftStack = new Stack<TreeNode>();
    Stack<TreeNode> nodesRightStack = new Stack<TreeNode>();
    Console.WriteLine(currentNode.val);
    nodesLeftStack.Push(currentNode);

    while (nodesLeftStack.Any())
    {
        currentNode = nodesLeftStack.Pop();
        if (currentNode.right != null)
        {
            nodesLeftStack.Push(currentNode.right);
        }

        while (currentNode.left != null)
        {
            currentNode = currentNode.left;
            Console.WriteLine(currentNode.val);
            nodesLeftStack.Push(currentNode);
        }
    }
}