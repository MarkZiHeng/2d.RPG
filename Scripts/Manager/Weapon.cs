using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet; // 子弹的预制体
    public GameObject dialogBox; // 说话框
    public bool say; // 说话框

    float timer; // 计时器
    float sayTime; // 间隔

    float spawnTime = 1f; // 发射子弹的时间间隔

    public float damage = 1f; // 武器的伤害值

    public Player player; // 玩家对象

    // Start is called before the first frame update
    void Start()
    {
        say = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 1; // 更新计时器(攻击的cd)

        KeyDown_J();

        sayTime += Time.deltaTime * 1; // 秒计算
        if (sayTime > 3f)
        {
            dialogBox.SetActive(false);
            sayTime = 0; // 重置
            say = false;
        }
    }

    // 攻击按键
    private void KeyDown_J()
    {
        // 如果附件有怪物就攻击
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("K");
            Debug.Log(timer);
            if (timer > spawnTime) // 如果计时器超过发射时间间隔
            {
                Debug.Log("进入");
                timer = 0; // 重置计时器
                Fire(); // 发射子弹
            }
        }
    }

    private void Fire()
    {
        Debug.LogWarning("发射");
        // 如果目标位空，则提示 dialogBox
        if (player.scanner.nearestTarget == null)
        {
            sayTime = 0; // 重置
            dialogBox.SetActive(true);
            return;
        }

        Vector3 dir = player.scanner.nearestTarget.position - transform.position; // 计算子弹飞行方向
        dir = dir.normalized; // 归一化方向向量
        GameObject go = Instantiate(bullet); // 实例化子弹预制体
        go.transform.position = transform.position; // 设置子弹的初始位置

        go.GetComponent<Bullet>().Init(GameManager.instance.playerDamage + damage, dir); // 初始化子弹的伤害和飞行方向
    }
}
