/*
输入一个链表，反转链表后，输出新链表的表头。
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
    ListNode* ReverseList(ListNode* pHead) {
        ListNode* tempHead = new ListNode(1);
        tempHead->next = NULL;
        
        ListNode* temp = pHead;
        
        while (temp)
        {
            ListNode* next = temp->next;
            temp->next = tempHead->next;
            tempHead->next = temp;
            temp = next;
        }
        return tempHead->next;
    }
};