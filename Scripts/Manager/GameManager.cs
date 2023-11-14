using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ��Ϸ��������ά����Ϸ�����й�������
    public Player player;
    public static GameManager instance; // ����ģʽ
    public bool isLive = true; // ��Ҵ��״̬

    public float health = 10; // ���Ѫ��

    public int kill; // ��ǰ��һ�ɱ��
    public int level; // ��ǰ��ҵȼ�
    public int exp; // ��ǰ��Ҿ���
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 }; // ��һ���ȼ����辭��ֵ����
    internal int maxGameTime = 180; // �����Ϸʱ��
    internal float gameTime; // ��Ϸ�ѽ���ʱ��
    float nowTime; // ��Ϸ�ѽ���ʱ�䣨Ϊ��ȥ���߼������޸ģ�������� gameTime �ǲ�ֱ�Ӳ����ģ�
    public float playerDamage = 1; // ��ҳ�ʼ�˺�ֵ

    void Awake()
    {
        instance = this; // ��ȡ��Ϸ����������
        nowTime = 0;
    }

    private void Update()
    {
        if (!isLive) return; //�����������������ٸ�����Ϸ״̬
        this.gameTime += Time.deltaTime; // ������Ϸ�ѽ���ʱ��
    }

    internal void Hit(float damage) // ��������
    {
        this.health -= damage; // Ѫ���ļ������ɹ����߾�����
        #region �����߼�
        if (this.health <= 0)
        {
            this.GameOver();
        }
        #endregion
    }

    void GameOver()
    {
        this.isLive = false;
    }

    internal void Kill()
    {
        this.kill++; // �ۼ��������������
        GetExp(); // ��þ���ֵ
    }

    private void GetExp()
    {
        nowTime = gameTime; // ��ȡ��ǰ��Ϸʱ��
        if (nowTime > 60)
        {
            this.exp += 3;
        }
        else
        {
            this.exp++; // �ۼӵ�ǰ����ֵ
        }

        // �����ǰ����ֵ������һ���ȼ�����ľ���ֵ��������
        if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++; // ���ӵȼ�
            playerDamage = level * 1.5f; // ��������˺�ֵ
            exp = 0; // ���þ���ֵ
        }
    }
}
