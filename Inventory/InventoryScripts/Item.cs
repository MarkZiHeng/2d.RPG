using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��Ʒϵͳ
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")] // ���Ҽ��˵����У������������ Item ��ѡ��
public class Item : ScriptableObject
{
    public string itemName; // ��Ʒ����
    public Sprite itemImage; // ��ƷͼƬ
    public int itemHeld; // ��Ʒ����
    [TextArea] // ����������Ƕ�������
    public string itemInfo; // ��Ʒ����
    public bool equip; // �Ƿ����װ����
}
