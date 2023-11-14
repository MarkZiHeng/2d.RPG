using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Bullet : MonoBehaviour
{
    public float damage; // �ӵ����˺�ֵ
    Rigidbody2D rigid; // �����������

    public float speed = 10f; // �ӵ����ٶ�
    float destoryBulletTime = 5f;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // ��ȡ�ӵ��ĸ������
    }

    // ��ʼ���ӵ��������˺�ֵ�ͷ��з���
    public void Init(float damage, Vector2 dir)
    {
        this.damage = damage;

        if (rigid)
        {
            rigid.velocity = dir * speed * (GameManager.instance.level + 1) * 1.5f; // ���ݷ�����ٶ������ӵ��ĳ�ʼ�ٶ�
        }

        Destroy(this.gameObject, destoryBulletTime); // ��5��������ӵ�����
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) // �����ײ�����ǵ��ˣ��򷵻�
            return;

        if (rigid)
        {
            rigid.velocity = Vector2.zero; // ��ײ��ֹͣ�ӵ����˶�
        }

        Destroy(this.gameObject); // �����ӵ�����
    }
}
