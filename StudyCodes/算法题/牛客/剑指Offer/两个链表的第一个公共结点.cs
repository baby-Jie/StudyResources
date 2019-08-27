/*
两个链表的第一个公共结点
输入两个链表，找出它们的第一个公共结点。
 */

 /*
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode (int x)
    {
        val = x;
    }
}*/
using System.Collections.Generic;
class Solution
{
    public ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2)
    {
        // write code here
         var list1 = GetListNodes(pHead1);
            var list2 = GetListNodes(pHead2);

            foreach (var listNode in list1)
            {

                if (list2.Contains(listNode))
                {
                    return listNode;
                }
            }

            return null;
    }
    
     List<ListNode> GetListNodes(ListNode pHead1)
        {
            List<ListNode> list = new List<ListNode>();
            while (pHead1 != null)
            {
                list.Add(pHead1);
                pHead1 = pHead1.next;
            }

            return list;
        }
    
    
}