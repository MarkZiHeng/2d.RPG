using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ���������Ʒ
public class Slot : MonoBehaviour
{
    public Item slotItem; // Ԥ����
    public Image slotImage; // ͼƬ
    public TMP_Text slotNum; // ����

    // ��Ʒ������ķ���
    public void ItemOnClick()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo); // ��� Item ���е� itemInfo(�ı���Ϣ)
    }
}
