using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 背包里的物品
public class Slot : MonoBehaviour
{
    public Item slotItem; // 预制体
    public Image slotImage; // 图片
    public TMP_Text slotNum; // 数量

    // 物品被点击的方法
    public void ItemOnClick()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo); // 获得 Item 类中的 itemInfo(文本信息)
    }
}
