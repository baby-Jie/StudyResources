
#include<iostream>
#include <cmath>
#include <algorithm>
using namespace std;

class AVLTree 
{
public:
	int val;
	AVLTree* left;
	AVLTree* right;

	AVLTree(int val)
	{
		this->val = val;
		this->left = NULL;
		this->right = NULL;
	}

	 AVLTree* insertTreeNode(AVLTree* node, int val)
	{
		if (node == NULL)
		{
			node = new AVLTree(val);
		}

		if (val < node->val)
		{
			// 插入左子树 

			node->left = insertTreeNode(node->left, val);
			if (getTreeHeight(node->left) - getTreeHeight(node->right) == 2)
			{
				if (val < node->left->val)
				{
					// 左左状态   右单旋 
					node = singleRightRotate(node);
				}
				else if (val > node->left->val)
				{
					// 左右状态  左单旋 后右单旋 
					node = leftRightRotate(node);
				}
			}
		}
		else if (val > node->val)
		{
			// 插入右子树 

			node->right = insertTreeNode(node->right, val);

			if (getTreeHeight(node->right) - getTreeHeight(node->left) == 2)
			{
				if (val < node->right->val)
				{
					// 右左状态 先右单旋 后左单旋 
					node = rightLeftRotate(node);
				}
				else if (val > node->right->val)
				{
					// 右右状态 左单旋 
					node = singleLeftRotate(node);
				}
			}
		}
		return node;
	}

private:
	AVLTree* singleLeftRotate(AVLTree* node)
	{
		AVLTree* right = node->right;
		node->right = right->left;
		right->left = node;
		return right;
	}

	AVLTree* singleRightRotate(AVLTree* node)
	{
		AVLTree* left = node->left;

		node->left = left->right;

		left->right = node;

		return left;
	}

	AVLTree* leftRightRotate(AVLTree* node)
	{
		node->left = singleLeftRotate(node->left);
		node = singleRightRotate(node);
		return node;
	}

	AVLTree* rightLeftRotate(AVLTree* node)
	{
		node->right = singleRightRotate(node->right);
		node = singleLeftRotate(node);
		return node;
	}

	// 获取tree的高度 
	int getTreeHeight(AVLTree* tree)
	{
		if (tree == NULL)
		{
			return 0;
		}

		return max(getTreeHeight(tree->left), getTreeHeight(tree->right)) + 1;
	}
};

void InOrderTranverse(AVLTree* root)
{
	if (root == NULL)
	{
		return;
	}

	InOrderTranverse(root->left);

	cout << root->val << endl;

	InOrderTranverse(root->right);
}

void PreTranverse(AVLTree* root)
{
	if (root == NULL)
	{
		return;
	}

	cout << root->val << endl;
	PreTranverse(root->left);
	PreTranverse(root->right);
}

void AfterTranverse(AVLTree* root)
{
	if (root == NULL)
	{
		return;
	}

	AfterTranverse(root->left);
	AfterTranverse(root->right);
	cout << root->val << endl;
}

int main()
{
	AVLTree* root = new AVLTree(1);
	root = root->insertTreeNode(root, 2);
	root = root->insertTreeNode(root, 3);
	root = root->insertTreeNode(root, 4);
	root = root->insertTreeNode(root, 5);
	root = root->insertTreeNode(root, 6);
	root = root->insertTreeNode(root, 7);
	root = root->insertTreeNode(root, 8);
	root = root->insertTreeNode(root, 9);
	root = root->insertTreeNode(root, 10);
	root = root->insertTreeNode(root, 11);
	root = root->insertTreeNode(root, 12);
	root = root->insertTreeNode(root, 13);
	root = root->insertTreeNode(root, 14);
	root = root->insertTreeNode(root, 15);

	cout << "Pre tranverse" << endl;
	PreTranverse(root);

	cout << "InOrder tranverse" << endl;
	InOrderTranverse(root);

	cout << "After tranverse" << endl;
	AfterTranverse(root);
	return 0;
}

