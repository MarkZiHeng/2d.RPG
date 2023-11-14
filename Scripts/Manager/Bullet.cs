using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Bullet : MonoBehaviour
{
    public float damage; // 子弹的伤害值
    Rigidbody2D rigid; // 刚体组件引用

    public float speed = 10f; // 子弹的速度
    float destoryBulletTime = 5f;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // 获取子弹的刚体组件
    }

    // 初始化子弹，包括伤害值和飞行方向
    public void Init(float damage, Vector2 dir)
    {
        this.damage = damage;

        if (rigid)
        {
            rigid.velocity = dir * speed * (GameManager.instance.level + 1) * 1.5f; // 根据方向和速度设置子弹的初始速度
        }

        Destroy(this.gameObject, destoryBulletTime); // 在5秒后销毁子弹对象
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) // 如果碰撞对象不是敌人，则返回
            return;

        if (rigid)
        {
            rigid.velocity = Vector2.zero; // 碰撞后停止子弹的运动
        }

        Destroy(this.gameObject); // 销毁子弹对象
    }
}
