using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AddText : MonoBehaviour
{
    class LinkedList1<E>
    {
        private class Node
        {
            public E e; // 自己的值
            public Node nextNode; // 下一个节点

            // 构造函数，初始化值
            public Node(E e, Node nextNode)
            {
                this.e = e;
                this.nextNode = nextNode;
            }
            public Node(E e)
            {
                this.e = e;
                this.nextNode = null;
            }

            public override string ToString()
            {
                return e.ToString();
            }
        }

        private Node headNode; // 链表的头部
        private int N; // 链表中，存储了多少个元素

        // 生成构造函数
        public LinkedList1()
        {
            // 当我们链表类在进行初始化的时候，它没有元素，所以
            this.headNode = null;
            this.N = 0;
        }

        /// <summary>
        /// 访问属性
        /// </summary>
        // 链表有多少元素
        public int Count
        {
            get { return N; }
        }
        // 链表是否为空
        public bool IsEmpty
        {
            get { return N == 0; }
        }
    }
}
