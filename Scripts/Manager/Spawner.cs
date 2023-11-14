using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 刷怪器脚本（生成怪物）
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject enemy; // 敌人的预制体
    public Transform[] spawnPoints; // 刷怪点位置的集合
    float timer = 0; // 计时器
    float spawnTime = 1f; // 刷怪时间

    float timerMany = 0; // 群怪计时器
    float spawnTimeMany = 40f; // 刷群怪时间
    
    void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>(); // 获取当前子节点下的所有组件，拿到所有刷怪点
    }

    void Update()
    {
        // 如果玩家已经死亡，就不刷新怪物
        if (!GameManager.instance.isLive)
        {
            return;
        }

        // 1s刷1只怪
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0;
            BrushMonsters();
        }

        // 群怪
        /*timerMany += Time.deltaTime;
        if (timerMany > spawnTimeMany)
        {
            timerMany = 0;
            BrushMonstersMany();
        }*/
    }

    // 刷单怪
    void BrushMonsters()
    {
        GameObject go = Instantiate(enemy); // 实例化对象
        go.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].transform.position; // 生成位置，从1开始是因为上面获取节点位置是包含父节点的（当前节点），
    }
    // 刷群怪
    void BrushMonstersMany()
    {
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            GameObject go = Instantiate(enemy); // 实例化对象
            go.transform.position = spawnPoints[i].transform.position; // 生成位置
        }
    }
}
