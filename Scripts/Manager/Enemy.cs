using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    public float speed = 2.5f; // 速度
    public float damage = 10f; // 攻击伤害
    public float health = 1; // 生命值
    internal float expEnemy; // 怪物掉落的经验
    float fortificationTime; // 强化怪物属性的时间
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    float nowTime;
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        nowTime = 0; // 初始化nowTime的值
        fortificationTime = 6f;
        expEnemy = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // 如果玩家死亡，直接返回
        if (!GameManager.instance.isLive)
        {
            return;
        }

        StrengthenMonster(); // 强化怪物的代码
        EnemyMove();
    }

    private void EnemyMove()
    {
        Vector3 inputVec = (GameManager.instance.player.transform.position - transform.position).normalized; // 这个还包含长度，所以需要 normalized 把长度固定为1，才是只包含方向
        this.transform.position = this.transform.position + inputVec * speed * Time.deltaTime; // 移动

        // 转向
        if (inputVec.x != 0)
            spriteRenderer.flipX = inputVec.x < 0;

        animator.SetFloat("GameSpeed", inputVec.magnitude); // inputVec.magnitude返回的向量的长度，移动的长度
    }

    // 强化怪物
    private void StrengthenMonster()
    {
        nowTime = GameManager.instance.gameTime; // 获取当前游戏时间
        if (nowTime == fortificationTime)
        {
            StartCoroutine(StartFortification()); // 启动协程进行强化逻辑
        }
    }

    // 怪物碰到子弹的逻辑（碰撞体触发）
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")) return; // 如果碰撞对象不是子弹，则返回

        health -= collision.GetComponent<Bullet>().damage; // 扣除敌人的生命值，根据子弹的伤害值

        if (health > 0)
        {
            animator.SetTrigger("Hit"); // 如果敌人还有生命值，播放受伤动画
        }
        else
        {
            animator.SetBool("Dead", true); // 如果敌人已经死亡，设置死亡动画为播放状态
            Dead(); // 执行死亡处理
            GameManager.instance.Kill(); // 告知游戏管理器敌人已被消灭
        }
    }

    private void Dead()
    {
        this.enabled = false; // 禁用敌人脚本组件
        Destroy(gameObject, 0.5f); // 延迟0.5秒后销毁敌人游戏对象
    }

    private IEnumerator StartFortification()
    {
        // 执行强化逻辑
        Debug.Log("开始强化怪物");

        // 等待一段时间
        yield return new WaitForSeconds(0f);
        health = 5;
        damage = 15;

        // 强化完成
        Debug.Log("怪物强化完成");
    }
}
