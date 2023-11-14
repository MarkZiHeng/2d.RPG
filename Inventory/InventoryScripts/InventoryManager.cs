using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// 控制 Inventory 的脚本，单例模式
// 方便直接访问其他代码
// 当 itemOnWorld 触碰的时候，通过这个脚本 来生成一个 Slot 在UI的界面上
public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance; // 单例模式

    // 控制将背包里的物品生成出来
    public Inventory myBag;
    public GameObject sloatGrid; // 背包格子
    public Slot slotPrefab; // 预制体
    public TMP_Text itemInfromation; // 详情文本

    private void Awake()
    {
        // 缩写
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfromation.text = ""; // 默认什么都不显示
    }

    // 实时更新物品描述信息的内容
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfromation.text = itemDescription;
    }

    // 创建新物品的方法
    public static void CreateNewItem(Item item)
    {
        // 先获取ItemList中的Item（物品）所有的信息，将信息传输给Slot，就可以在预制体中显示
        // 在 Unity 中，Instantiate 是一个函数，用于创建对象的实例。它接受一个要实例化的对象作为参数，并返回该对象的克隆副本。
        Slot newItem = Instantiate(instance.slotPrefab, instance.sloatGrid.transform.position, Quaternion.identity); // 角度不变，在sloatGrid中生成
        newItem.gameObject.transform.SetParent(instance.sloatGrid.transform); // 和父级挂在一起 因为Slot生成的是脚本，需要获得物体，去获得 transform

        // 传输数据
        newItem.slotItem = item; // 因为是Slot类声明的，所以可以访问Slot里面的变量
        newItem.slotImage.sprite = item.itemImage; // 图片
        newItem.slotNum.text = item.itemHeld.ToString();
    }

    // 更改数量的数字
    public static void RefreshItem()
    {
        // 使用的方法是修改 sloatGrid 下面的子集
        for (int i = 0; i < instance.sloatGrid.transform.childCount; i++)
        {
            if (instance.sloatGrid.transform.childCount == 0)
                break;
            Destroy(instance.sloatGrid.transform.GetChild(i).gameObject); // 销毁了所有子集下面的物品数量栏
        }

        // 重新生成，当前背包当中有多少物品，就重新生成
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
}
