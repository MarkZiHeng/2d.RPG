using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 背包系统，列表形式（用来存储所有物品）
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>(); // 数据的类型就是 物品系统的 Item

}
