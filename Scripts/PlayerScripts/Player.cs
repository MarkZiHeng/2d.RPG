using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ��Ҵ���
    public Animator animator;
    public Scanner scanner; // �����
    public float damage = 1f; // ����˺�
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // ��ҽ�����ײ�����˵��߼�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ϸ�������Ĺ�������
        if (!collision.CompareTag("Enemy")) return; // �����ײ����ı�ǩ����"Enemy"���򷵻�
        GameManager.instance.Hit(collision.GetComponent<Enemy>().damage); // ����GameManager�е�Hit������������ײ����ĵ���������˺�ֵ

        // ���״̬�Ƿ�����
        if (!GameManager.instance.isLive)
        {
            // ִ��������Ϊ
            animator.SetTrigger("Dead");
            // ���ý�ɫ��������������2��ʼ��������Ϸ����
            for (int index = 2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }
        }
    }
}
