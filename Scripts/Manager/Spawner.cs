using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ˢ�����ű������ɹ��
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject enemy; // ���˵�Ԥ����
    public Transform[] spawnPoints; // ˢ�ֵ�λ�õļ���
    float timer = 0; // ��ʱ��
    float spawnTime = 1f; // ˢ��ʱ��

    float timerMany = 0; // Ⱥ�ּ�ʱ��
    float spawnTimeMany = 40f; // ˢȺ��ʱ��
    
    void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>(); // ��ȡ��ǰ�ӽڵ��µ�����������õ�����ˢ�ֵ�
    }

    void Update()
    {
        // �������Ѿ��������Ͳ�ˢ�¹���
        if (!GameManager.instance.isLive)
        {
            return;
        }

        // 1sˢ1ֻ��
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0;
            BrushMonsters();
        }

        // Ⱥ��
        /*timerMany += Time.deltaTime;
        if (timerMany > spawnTimeMany)
        {
            timerMany = 0;
            BrushMonstersMany();
        }*/
    }

    // ˢ����
    void BrushMonsters()
    {
        GameObject go = Instantiate(enemy); // ʵ��������
        go.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].transform.position; // ����λ�ã���1��ʼ����Ϊ�����ȡ�ڵ�λ���ǰ������ڵ�ģ���ǰ�ڵ㣩��
    }
    // ˢȺ��
    void BrushMonstersMany()
    {
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            GameObject go = Instantiate(enemy); // ʵ��������
            go.transform.position = spawnPoints[i].transform.position; // ����λ��
        }
    }
}
