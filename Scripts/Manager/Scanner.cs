using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    // 扫描器，检测玩家附件有多少怪物，最近的敌人

    public float scanRange = 6f; // 扫描范围的初始值，攻击范围
    RaycastHit2D[] targets; // 存储了通过 CircleCastAll 方法在指定范围内与目标层（targetLayer）碰撞的结果，使用 RaycastHit2D 数组保存了所有的碰撞信息。
    public Transform nearestTarget; // 保存了最近的敌人的 Transform 组件，即最近的目标位置。

    public LayerMask targetLayer; // 表示需要进行碰撞检测的目标层。

    void FixedUpdate()
    {
        // 使用CircleCastAll方法在指定范围内进行圆形碰撞检测
        // 将结果存储在targets数组中
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);

        // 获取最近的敌人位置
        nearestTarget = GetNearest();
    }

    private Transform GetNearest()
    {
        float diff = 100f; // 初始差异值
        Transform result = null; // 最近目标的Transform组件
        foreach (RaycastHit2D t in targets) // 遍历每个碰撞结果
        {
            Vector3 myPos = transform.position; // 当前位置
            Vector3 targetPos = t.transform.position; // 目标位置

            // 计算当前目标与当前位置的距离
            float curDiff = Vector3.Distance(myPos, targetPos);
            if (curDiff < diff) // 如果距离更近
            {
                diff = curDiff; // 更新最小差异值
                result = t.transform; // 更新最近的目标位置
            }
        }
        return result; // 返回最近的目标位置
    }
}
