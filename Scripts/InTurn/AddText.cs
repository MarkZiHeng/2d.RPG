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
            public E e; // �Լ���ֵ
            public Node nextNode; // ��һ���ڵ�

            // ���캯������ʼ��ֵ
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

        private Node headNode; // �����ͷ��
        private int N; // �����У��洢�˶��ٸ�Ԫ��

        // ���ɹ��캯��
        public LinkedList1()
        {
            // �������������ڽ��г�ʼ����ʱ����û��Ԫ�أ�����
            this.headNode = null;
            this.N = 0;
        }

        /// <summary>
        /// ��������
        /// </summary>
        // �����ж���Ԫ��
        public int Count
        {
            get { return N; }
        }
        // �����Ƿ�Ϊ��
        public bool IsEmpty
        {
            get { return N == 0; }
        }
    }
}
