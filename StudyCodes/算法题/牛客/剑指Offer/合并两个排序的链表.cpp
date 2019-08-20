/*

输入两个单调递增的链表，输出两个链表合成后的链表，当然我们需要合成后的链表满足单调不减规则。

*/
#include <iostream>
using namespace std;

struct ListNode
{
    int val;
    struct ListNode *next;
    ListNode(int x) : val(x), next(NULL)
    {
    }
};

ListNode *Merge(ListNode *pHead1, ListNode *pHead2)
{
    ListNode *pHead = new ListNode(-1);
    pHead->next = NULL;
    ListNode *t = pHead;

    while (pHead1 || pHead2)
    {
        if (!pHead1)
        {
            if (pHead2)
            {
                t->next = pHead2;
                pHead2 = pHead2->next;
                t = t->next;
                t->next = NULL;
            }
            break;
        }

        if (!pHead2)
        {
            while (pHead1)
            {
                t->next = pHead1;
                pHead1 = pHead1->next;
                t = t->next;
                t->next = NULL;
            }
            break;
        }

        if (pHead1->val < pHead2->val)
        {
            t->next = pHead1;
            pHead1 = pHead1->next;
            t = t->next;
            t->next = NULL;
        }
        else
        {
            t->next = pHead2;
            pHead2 = pHead2->next;
            t = t->next;
            t->next = NULL;
        }
    }

    return pHead->next;
}

int main()
{
    cout << "hello" << endl;
    return 0;
}
