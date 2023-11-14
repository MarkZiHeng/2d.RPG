using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem; // 获取物品属性
    public Inventory playerInventory; // 玩家的背包

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 匹配标签
        {
            AddNewItem(); // 添加物品

            Destroy(gameObject); // 销毁物品
        }
    }

    private void AddNewItem()
    {
        // 先判断，当前的这个物品，是否在背包中
        if (!playerInventory.itemList.Contains(thisItem))
        {
            // 如果背包没有则添加物品
            playerInventory.itemList.Add(thisItem);
            // InventoryManager.CreateNewItem(thisItem); // 调用方法，来在背包中生成
        }
        else
        {
            // 背包有则持有数（数量）+1
            thisItem.itemHeld += 1;
        }

        InventoryManager.RefreshItem();
    }
}
