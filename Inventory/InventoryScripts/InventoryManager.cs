using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// ���� Inventory �Ľű�������ģʽ
// ����ֱ�ӷ�����������
// �� itemOnWorld ������ʱ��ͨ������ű� ������һ�� Slot ��UI�Ľ�����
public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance; // ����ģʽ

    // ���ƽ����������Ʒ���ɳ���
    public Inventory myBag;
    public GameObject sloatGrid; // ��������
    public Slot slotPrefab; // Ԥ����
    public TMP_Text itemInfromation; // �����ı�

    private void Awake()
    {
        // ��д
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfromation.text = ""; // Ĭ��ʲô������ʾ
    }

    // ʵʱ������Ʒ������Ϣ������
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfromation.text = itemDescription;
    }

    // ��������Ʒ�ķ���
    public static void CreateNewItem(Item item)
    {
        // �Ȼ�ȡItemList�е�Item����Ʒ�����е���Ϣ������Ϣ�����Slot���Ϳ�����Ԥ��������ʾ
        // �� Unity �У�Instantiate ��һ�����������ڴ��������ʵ����������һ��Ҫʵ�����Ķ�����Ϊ�����������ظö���Ŀ�¡������
        Slot newItem = Instantiate(instance.slotPrefab, instance.sloatGrid.transform.position, Quaternion.identity); // �ǶȲ��䣬��sloatGrid������
        newItem.gameObject.transform.SetParent(instance.sloatGrid.transform); // �͸�������һ�� ��ΪSlot���ɵ��ǽű�����Ҫ������壬ȥ��� transform

        // ��������
        newItem.slotItem = item; // ��Ϊ��Slot�������ģ����Կ��Է���Slot����ı���
        newItem.slotImage.sprite = item.itemImage; // ͼƬ
        newItem.slotNum.text = item.itemHeld.ToString();
    }

    // ��������������
    public static void RefreshItem()
    {
        // ʹ�õķ������޸� sloatGrid ������Ӽ�
        for (int i = 0; i < instance.sloatGrid.transform.childCount; i++)
        {
            if (instance.sloatGrid.transform.childCount == 0)
                break;
            Destroy(instance.sloatGrid.transform.GetChild(i).gameObject); // �����������Ӽ��������Ʒ������
        }

        // �������ɣ���ǰ���������ж�����Ʒ������������
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
}
