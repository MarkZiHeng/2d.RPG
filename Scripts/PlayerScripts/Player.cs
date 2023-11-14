using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 玩家代码
    public Animator animator;
    public Scanner scanner; // 检测器
    public float damage = 1f; // 玩家伤害
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // 玩家接受碰撞，受伤的逻辑
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 游戏管理器的攻击方法
        if (!collision.CompareTag("Enemy")) return; // 如果碰撞对象的标签不是"Enemy"，则返回
        GameManager.instance.Hit(collision.GetComponent<Enemy>().damage); // 调用GameManager中的Hit方法，传入碰撞对象的敌人组件的伤害值

        // 检测状态是否死亡
        if (!GameManager.instance.isLive)
        {
            // 执行死亡行为
            animator.SetTrigger("Dead");
            // 禁用角色子物体中索引从2开始的所有游戏对象
            for (int index = 2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }
        }
    }
}
