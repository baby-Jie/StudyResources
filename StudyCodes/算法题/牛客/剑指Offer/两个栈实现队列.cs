/*
用两个栈来实现一个队列，完成队列的Push和Pop操作。 队列中的元素为int类型。
 */

 using System.Collections.Generic;
class Solution
{
     Stack<int> s1 = new Stack<int>();
        Stack<int> s2 = new Stack<int>();
    public void push(int node) 
    {
         s1.Push(node);
    }
    public int pop() 
    {
     while (s1.Count > 0)
            {
                s2.Push(s1.Pop());
            }

            int ret = s2.Pop();

            while (s2.Count > 0)
            {
                s1.Push(s2.Pop());
            }

            return ret;
    }

    public int pop2()
    {
        if (s2.Count == 0)
        {
            while (s1.Count > 0)
            {
                s2.Push(s1.Pop());
            }
        }
       return  s2.Pop();
    }
}