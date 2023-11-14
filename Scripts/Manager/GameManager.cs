using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 游戏管理器，维护游戏的所有规格和数据
    public Player player;
    public static GameManager instance; // 单例模式
    public bool isLive = true; // 玩家存活状态

    public float health = 10; // 玩家血量

    public int kill; // 当前玩家击杀数
    public int level; // 当前玩家等级
    public int exp; // 当前玩家经验
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 }; // 下一个等级所需经验值数组
    internal int maxGameTime = 180; // 最大游戏时间
    internal float gameTime; // 游戏已进行时间
    float nowTime; // 游戏已进行时间（为了去做逻辑，和修改，，上面的 gameTime 是不直接操作的）
    public float playerDamage = 1; // 玩家初始伤害值

    void Awake()
    {
        instance = this; // 获取游戏管理器单例
        nowTime = 0;
    }

    private void Update()
    {
        if (!isLive) return; //如果玩家已死亡，不再更新游戏状态
        this.gameTime += Time.deltaTime; // 更新游戏已进行时间
    }

    internal void Hit(float damage) // 攻击代码
    {
        this.health -= damage; // 血量的减少是由攻击者决定的
        #region 死亡逻辑
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
        this.kill++; // 累加已消灭敌人数量
        GetExp(); // 获得经验值
    }

    private void GetExp()
    {
        nowTime = gameTime; // 获取当前游戏时间
        if (nowTime > 60)
        {
            this.exp += 3;
        }
        else
        {
            this.exp++; // 累加当前经验值
        }

        // 如果当前经验值等于下一个等级所需的经验值，则升级
        if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++; // 增加等级
            playerDamage = level * 1.5f; // 更新玩家伤害值
            exp = 0; // 重置经验值
        }
    }
}
