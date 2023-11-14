using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物品系统
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")] // 在右键菜单当中，创建属于这个 Item 的选项
public class Item : ScriptableObject
{
    public string itemName; // 物品名字
    public Sprite itemImage; // 物品图片
    public int itemHeld; // 物品数量
    [TextArea] // 加上这个就是多行描述
    public string itemInfo; // 物品描述
    public bool equip; // 是否可以装备的
}
