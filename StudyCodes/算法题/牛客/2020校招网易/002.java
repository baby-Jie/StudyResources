/*
给定一颗二叉树，每个结点有一个正整数权值，若一个二叉树，每一层的结点权值和都严格小于下一层的结点权值和，则称这颗二叉树为递增二叉树

输入描述：
    输入第一行是一个正整数T(0< T <= 50),接下来有T组样例，对于每组样例，输入的第一行是一个正整数N， 表示树的结点个数(0<N<=1000,结点编号为0到N-1)。接下来是N行，第K行表示编号为K的结点，输入格式为：Value Left Right，其中Value表示其权值，是一个不超过5000的自然数，Left和Right分别表示该结点的左子编号和右子编号，如果其不存在左子或者右子，则LEFT或Right为-1

输出样例：
对于每一组样例，输出一个字符串，如果该二叉树是一颗递增书树，则输出YES，否则输出NO

输入：
2
8
2 -1 -1
1 5 3
4 -1 6
2 -1 -1
3 0 2
2 4 7
7 -1 -1
2 -1 -1
8
21 6 -1 
52 4 -1
80 0 3
31 7 -1
21 -1 -1
59 -1 -1
50 5 -1
48 -1 1

输出：
YES
NO
*/

import java.util.ArrayList;
import java.util.Scanner;

class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	
	public int leftIndex;
	public int rightIndex;
	
	public TreeNode(int val, int leftIndex, int rightIndex)
	{
		this.val = val;
		this.leftIndex = leftIndex;
		this.rightIndex = rightIndex;
	}
}


public class TestMain2
{
	public static boolean isCeng(TreeNode root)
	{
		if (root == null) return false;
		int sumVal = root.val;
		ArrayList<TreeNode> nodes1 = new ArrayList<TreeNode>(); 
		nodes1.add(root);
		while (nodes1.size() > 0)
		{
			ArrayList<TreeNode> nodes2 = new ArrayList<TreeNode>(); 
			
			int sum = 0;
			for (TreeNode node: nodes1)
			{
				sum += node.val;
				if (node.left != null)
				{
					nodes2.add(node.left);
				}
				
				if (node.right != null)
				{
					nodes2.add(node.right);
				}
			}
			
			if (sum < sumVal)
			{
				return false;
			}
			sumVal = sum;
			nodes1 = nodes2;
		}
		
		return true;
	}
	
	public static void main(String[] args)
	{
		Scanner scanner = new Scanner(System.in);
		int N = Integer.parseInt(scanner.nextLine().trim());
		
		for (int i = 0; i < N; i++)
		{
			int T = Integer.parseInt(scanner.nextLine().trim());
			
			TreeNode root = null;
			root = null;
			ArrayList<TreeNode> nodes = new ArrayList<TreeNode>();
			ArrayList<Integer> myKey = new ArrayList<>();
			nodes.add(null);
			for (int k = 0; k < T; k++)
			{
				String str = scanner.nextLine().trim();
				String[] strs = str.split("\\s");
				int val = Integer.parseInt(strs[0]);
				int leftIndex = Integer.parseInt(strs[1]);
				int rightIndex = Integer.parseInt(strs[2]);
				
				TreeNode node1 = new TreeNode(val, leftIndex, rightIndex);
				nodes.add(node1);
			}
			// 建树
			for (int x = 1; x <= nodes.size() - 1; x++)
			{
				TreeNode node = nodes.get(x);
				if (node.leftIndex != -1)
				{
					myKey.add(node.leftIndex+1);
					node.left = nodes.get(node.leftIndex+1);
				}
				
				if (node.rightIndex != -1)
				{
					myKey.add(node.rightIndex+1);
					node.right = nodes.get(node.rightIndex+1);
				}
			}
			// 找到跟节点
			for (int x = 1; x <= nodes.size() - 1; x++)
			{
				if (!myKey.contains(x))
				{
					root = nodes.get(x);
					break;
				}
			}
			
			// 层级遍历
			if (isCeng(root))
			{
				System.out.println("YES");
			}
			else
			{
				System.out.println("NO");
			}
		}
	}
}

