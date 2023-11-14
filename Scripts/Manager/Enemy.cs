using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    public float speed = 2.5f; // �ٶ�
    public float damage = 10f; // �����˺�
    public float health = 1; // ����ֵ
    internal float expEnemy; // �������ľ���
    float fortificationTime; // ǿ���������Ե�ʱ��
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    float nowTime;
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        nowTime = 0; // ��ʼ��nowTime��ֵ
        fortificationTime = 6f;
        expEnemy = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // ������������ֱ�ӷ���
        if (!GameManager.instance.isLive)
        {
            return;
        }

        StrengthenMonster(); // ǿ������Ĵ���
        EnemyMove();
    }

    private void EnemyMove()
    {
        Vector3 inputVec = (GameManager.instance.player.transform.position - transform.position).normalized; // ������������ȣ�������Ҫ normalized �ѳ��ȹ̶�Ϊ1������ֻ��������
        this.transform.position = this.transform.position + inputVec * speed * Time.deltaTime; // �ƶ�

        // ת��
        if (inputVec.x != 0)
            spriteRenderer.flipX = inputVec.x < 0;

        animator.SetFloat("GameSpeed", inputVec.magnitude); // inputVec.magnitude���ص������ĳ��ȣ��ƶ��ĳ���
    }

    // ǿ������
    private void StrengthenMonster()
    {
        nowTime = GameManager.instance.gameTime; // ��ȡ��ǰ��Ϸʱ��
        if (nowTime == fortificationTime)
        {
            StartCoroutine(StartFortification()); // ����Э�̽���ǿ���߼�
        }
    }

    // ���������ӵ����߼�����ײ�崥����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")) return; // �����ײ�������ӵ����򷵻�

        health -= collision.GetComponent<Bullet>().damage; // �۳����˵�����ֵ�������ӵ����˺�ֵ

        if (health > 0)
        {
            animator.SetTrigger("Hit"); // ������˻�������ֵ���������˶���
        }
        else
        {
            animator.SetBool("Dead", true); // ��������Ѿ�������������������Ϊ����״̬
            Dead(); // ִ����������
            GameManager.instance.Kill(); // ��֪��Ϸ�����������ѱ�����
        }
    }

    private void Dead()
    {
        this.enabled = false; // ���õ��˽ű����
        Destroy(gameObject, 0.5f); // �ӳ�0.5������ٵ�����Ϸ����
    }

    private IEnumerator StartFortification()
    {
        // ִ��ǿ���߼�
        Debug.Log("��ʼǿ������");

        // �ȴ�һ��ʱ��
        yield return new WaitForSeconds(0f);
        health = 5;
        damage = 15;

        // ǿ�����
        Debug.Log("����ǿ�����");
    }
}
