/*
输入一个链表，输出该链表中倒数第k个结点。
*/


struct ListNode {
	int val;
	struct ListNode *next;
	ListNode(int x) :
			val(x), next(NULL) {
	}
};
class Solution {
public:
    int count = 0;
    ListNode* find = NULL;
    void FindNode(ListNode* node, unsigned int k)
    {
        if (node == NULL)
        {
            return ;
        }
        else
        {
            FindNode(node->next, k);
        }
        count++;
        if (count == k)
        {
            find = node;
        }
    }
    ListNode* FindKthToTail(ListNode* pListHead, unsigned int k) {
        FindNode(pListHead, k);
        return find;
    }
};