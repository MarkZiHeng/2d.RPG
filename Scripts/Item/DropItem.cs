using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 掉落物品的功能
/// </summary>
public class DropItem : MonoBehaviour
{
    public GameObject[] dropItems; // 掉落物
    Vector2 dropPosition;
    private float range;
    // 在指定位置附近随机生成掉落物品
    public void DropRandomItem(Vector2 dropPosition, float range)
    {
        if (dropItems != null && dropItems.Length > 0)
        {
            Vector2 randomOffset = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
            Vector2 finalDropPosition = dropPosition + randomOffset;
            int randomIndex = Random.Range(0, dropItems.Length);
            GameObject randomItem = dropItems[randomIndex];
            Instantiate(randomItem, finalDropPosition, Quaternion.identity);
        }
    }

    private void Start()
    {
        // 初始化内容
        dropPosition = this.transform.position;
        range = 1;
        // 生成
        DropRandomItem(dropPosition, range);
    }
}
