using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ϵͳ���б���ʽ�������洢������Ʒ��
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>(); // ���ݵ����;��� ��Ʒϵͳ�� Item

}
